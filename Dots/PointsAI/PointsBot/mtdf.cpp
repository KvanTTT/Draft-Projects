#include "config.h"
#include "mtdf.h"
#include "minimax.h"
#include "field.h"
#include "trajectories.h"
#include <omp.h>
#include <algorithm>
#include <limits>

using namespace std;

score mtdf_alphabeta(field* cur_field, vector<pos>* moves, size_t depth, trajectories* last, score alpha, score beta, int* empty_board, pos* best)
{
	for (auto i = moves->begin(); i != moves->end(); i++)
	{
		score cur_estimate = alphabeta(cur_field, depth - 1, *i, last, -beta, -alpha, empty_board);
		if (cur_estimate > alpha)
		{
			alpha = cur_estimate;
			*best = *i;
			if (alpha >= beta)
				break;
		}
	}

	return alpha;
}

// CurField - ����, �� ������� ������������ ������.
// Depth - ������� ������.
pos mtdf(field* cur_field, size_t depth)
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

	score alpha = -cur_trajectories.get_max_score(next_player(cur_field->get_player()));
	score beta = cur_trajectories.get_max_score(cur_field->get_player());

	int* empty_board = new int[cur_field->length()];

	do
	{
		int center = (alpha + beta) / 2;
		score cur_estimate = mtdf_alphabeta(cur_field, &moves, depth, &cur_trajectories, center, center + 1, empty_board, &result);
		if (cur_estimate > center)
			alpha = cur_estimate;
		else
			beta = cur_estimate;
	}
	while (beta - alpha > 1);

	delete empty_board;

	return result;
}