#include "config.h"
#include "minimax.h"
#include "field.h"
#include "trajectories.h"
#include <omp.h>
#include <algorithm>
#include <limits>
#include <math.h>

using namespace std;

// ����������� ������� ���������.
// CurField - ����, �� ������� ������� ����� ������� ����.
// TrajectoriesBoard - �����, �� ������� ������������ ����������. ������ ���� ��������� ������. ����� ��� �����������.
// Depth - ������� ��������.
// Pos - ��������� ���������, �� �� ��������� ���.
// alpha, beta - �������� ������, ��� �������� ������ ��� ������.
// �� ������ ������ ������� ��� CurPlayer (�� ���� Pos).
score alphabeta(field* cur_field, size_t depth, pos cur_pos, trajectories* last, score alpha, score beta, int* empty_board)
{
	trajectories cur_trajectories(cur_field, empty_board);

	// ������ ���, ��������� �� ���������� ������ ��������, ����� ���� ���� ��� ���������� ���������.
	cur_field->do_unsafe_step(cur_pos);

	if (depth == 0)
	{
		score best_estimate = cur_field->get_score(cur_field->get_player());
		cur_field->undo_step();
		return -best_estimate;
	}

	if (cur_field->get_d_score() < 0) // ���� ����� ���������� � ���������.
	{
		cur_field->undo_step();
		return -SCORE_INFINITY; // ��� CurPlayer ��� ������, �� ���� ������ Infinity.
	}

	cur_trajectories.build_trajectories(last, cur_pos);
	
	list<pos>* moves = cur_trajectories.get_points();

	if (moves->size() == 0)
	{
		score best_estimate = cur_field->get_score(cur_field->get_player());
		cur_field->undo_step();
		return -best_estimate;
	}

#if CALCULATE_BOUNDARIES
	alpha = max(alpha, -cur_trajectories.get_max_score(next_player(cur_field->get_player())));
	beta = min(beta, cur_trajectories.get_max_score(cur_field->get_player()));
	if (alpha < beta)
#endif
		for (auto i = moves->begin(); i != moves->end(); i++)
		{
#if NEGASCOUT
			score cur_estimate = alphabeta(cur_field, depth - 1, *i, &cur_trajectories, -alpha - 1, -alpha, empty_board);
			if (cur_estimate > alpha && cur_estimate < beta)
				cur_estimate = alphabeta(cur_field, depth - 1, *i, &cur_trajectories, -beta, -cur_estimate, empty_board);
#else
			score cur_estimate = alphabeta(cur_field, depth - 1, *i, &cur_trajectories, -beta, -alpha, empty_board);
#endif
			if (cur_estimate > alpha)
			{
				alpha = cur_estimate;
				if (alpha >= beta)
					break;
			}
		}

	cur_field->undo_step();
	return -alpha;
}

score get_enemy_estimate(field* cur_field, trajectories* last, size_t depth)
{
	vector<pos> moves;
	trajectories cur_trajectories(cur_field);
	score result;

	cur_field->set_next_player();
	cur_trajectories.build_trajectories(last);

	moves.assign(cur_trajectories.get_points()->begin(), cur_trajectories.get_points()->end());
	if (moves.size() == 0)
	{
		result = cur_field->get_score(cur_field->get_player());
	}
	else
	{
		score alpha = -cur_trajectories.get_max_score(next_player(cur_field->get_player()));
		score beta = cur_trajectories.get_max_score(cur_field->get_player());
		#pragma omp parallel
		{
			field* local_field = new field(*cur_field);
			int* empty_board = new int[cur_field->length()];

			#pragma omp for schedule(dynamic, 1)
			for (ptrdiff_t i = 0; i < static_cast<ptrdiff_t>(moves.size()); i++)
			{
				if (alpha < beta)
				{
#if NEGASCOUT
					score cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -alpha - 1, -alpha, empty_board);
					if (cur_estimate > alpha && cur_estimate < beta)
						cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -beta, -cur_estimate, empty_board);
#else
					score cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -beta, -alpha, empty_board);
#endif
					#pragma omp critical
					{
						if (cur_estimate > alpha) // ��������� ������ �������.
							alpha = cur_estimate;
					}
				}
			}

			delete empty_board;
			delete local_field;
		}
		result = alpha;
	}

	cur_field->set_next_player();
	return -result;
}

// CurField - ����, �� ������� ������������ ������.
// Depth - ������� ������.
// Moves - �� ����� ��������� ����, �� ������ ������ �� ���.
pos minimax(field* cur_field, size_t depth)
{
	// ������� ���������� - ���� � ���������.
	trajectories cur_trajectories(cur_field, NULL, depth);
	vector<pos> moves;
	pos result;

	// ������ ���-�� ������ ����� ������� �������� ������������� � ����������� ��������� ����� �� ����� �� ����� 0.
	if (depth <= 0)
		return -1;

	// �������� ���� �� ���������� (������� ����� ����� �������������), � ������� ����������� �� �������� ���������� �������.
	cur_trajectories.build_trajectories();
	moves.assign(cur_trajectories.get_points()->begin(), cur_trajectories.get_points()->end());
	// ���� ��� ��������� �����, �������� � ���������� - �������.
	if (moves.size() == 0)
		return -1;
	// ��� ����� ���� ��������� �����, �� �������� � ���������� ������ ����� ����� ��, ��� ���� �� ����� CurPlayer ��������� ���.
	//int enemy_estimate = get_enemy_estimate(cur_field, Trajectories[cur_field.get_player()], Trajectories[next_player(cur_field.get_player())], depth);

	score alpha = -cur_trajectories.get_max_score(next_player(cur_field->get_player()));
	score beta = cur_trajectories.get_max_score(cur_field->get_player());
	#pragma omp parallel
	{
		field* local_field = new field(*cur_field);
		int* empty_board = new int[cur_field->length()];

		#pragma omp for schedule(dynamic, 1)
		for (ptrdiff_t i = 0; i < static_cast<ptrdiff_t>(moves.size()); i++)
		{
			if (alpha < beta)
			{
#if NEGASCOUT
				score cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -alpha - 1, -alpha, empty_board);
				if (cur_estimate > alpha && cur_estimate < beta)
					cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -beta, -cur_estimate, empty_board);
#else
				score cur_estimate = alphabeta(local_field, depth - 1, moves[i], &cur_trajectories, -beta, -alpha, empty_board);
#endif
				#pragma omp critical
				{
					if (cur_estimate > alpha) // ��������� ������ �������.
					{
						alpha = cur_estimate;
						result = moves[i];
					}
				}
			}
		}

		delete empty_board;
		delete local_field;
	}
	return alpha == get_enemy_estimate(cur_field, &cur_trajectories, depth - 1) ? -1 : result;
}