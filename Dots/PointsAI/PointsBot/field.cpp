#include "field.h"

using namespace std;

short field::get_input_points(const pos center_pos, const value enable_cond, pos inp_chain_points[], pos inp_sur_points[]) const
{
	short result = 0;

	if (is_not_enable(w(center_pos), enable_cond))
	{
		if (is_enable(nw(center_pos), enable_cond))
		{
			inp_chain_points[0] = nw(center_pos);
			inp_sur_points[0] = w(center_pos);
			result++;
		}
		else if (is_enable(n(center_pos), enable_cond))
		{
			inp_chain_points[0] = n(center_pos);
			inp_sur_points[0] = w(center_pos);
			result++;
		}
	}

	if (is_not_enable(s(center_pos), enable_cond))
	{
		if (is_enable(sw(center_pos), enable_cond))
		{
			inp_chain_points[result] = sw(center_pos);
			inp_sur_points[result] = s(center_pos);
			result++;
		}
		else if (is_enable(w(center_pos), enable_cond))
		{
			inp_chain_points[result] = w(center_pos);
			inp_sur_points[result] = s(center_pos);
			result++;
		}
	}

	if (is_not_enable(e(center_pos), enable_cond))
	{
		if (is_enable(se(center_pos), enable_cond))
		{
			inp_chain_points[result] = se(center_pos);
			inp_sur_points[result] = e(center_pos);
			result++;
		}
		else if (is_enable(s(center_pos), enable_cond)) 
		{
			inp_chain_points[result] = s(center_pos);
			inp_sur_points[result] = e(center_pos);
			result++;
		}
	}

	if (is_not_enable(n(center_pos), enable_cond))
	{
		if (is_enable(ne(center_pos), enable_cond))
		{
			inp_chain_points[result] = ne(center_pos);
			inp_sur_points[result] = n(center_pos);
			result++;
		}
		else if (is_enable(e(center_pos), enable_cond))
		{
			inp_chain_points[result] = e(center_pos);
			inp_sur_points[result] = n(center_pos);
			result++;
		}
	}

	return result;
}

void field::place_begin_pattern(begin_pattern cur_pattern)
{
	switch (cur_pattern)
	{
	case (BEGIN_PATTERN_CROSSWIRE):
		do_step(to_pos(_width / 2 - 1, _height / 2 - 1));
		do_step(to_pos(_width / 2, _height / 2 - 1));
		do_step(to_pos(_width / 2, _height / 2));
		do_step(to_pos(_width / 2 - 1, _height / 2));
		break;
	case (BEGIN_PATTERN_SQUARE):
		do_step(to_pos(_width / 2 - 1, _height / 2 - 1));
		do_step(to_pos(_width / 2, _height / 2 - 1));
		do_step(to_pos(_width / 2 - 1, _height / 2));
		do_step(to_pos(_width / 2, _height / 2));
		break;
	}
}

void field::remove_empty_base(const pos start_pos)
{
	wave(	start_pos,
			[&](pos cur_pos)->bool
			{
				if (is_in_empty_base(cur_pos))
				{
					_changes.back().changes.push(pair<pos, value>(cur_pos, _points[cur_pos] & !tag_bit));
					clear_empty_base(cur_pos);
					return true;
				}
				else
				{
					return false;
				}
			});
}

bool field::build_chain(const pos start_pos, const value enable_cond, const pos direction_pos, list<pos> &chain)
{
	chain.clear();
	chain.push_back(start_pos);
	pos cur_pos = direction_pos;
	pos center_pos = start_pos;
	// ������� ����.
	int TempSquare = square(center_pos, cur_pos);
	do
	{
		if (is_tagged(cur_pos))
		{
			while (chain.back() != cur_pos)
			{
				clear_tag(chain.back());
				chain.pop_back();
			}
		}
		else
		{
			set_tag(cur_pos);
			chain.push_back(cur_pos);
		}
		swap(cur_pos, center_pos);
		get_first_next_pos(center_pos, cur_pos);
		while (is_not_enable(cur_pos, enable_cond))
			get_next_pos(center_pos, cur_pos);
		TempSquare += square(center_pos, cur_pos);
	}
	while (cur_pos != start_pos);

	for (auto i = chain.begin(); i != chain.end(); i++)
		clear_tag(*i);

	return (TempSquare < 0 && chain.size() > 2);
}

void field::find_surround(list<pos> &chain, pos inside_point, player cur_player)
{
	// ���������� ����������� �����.
	int cur_capture_count = 0;
	// ���������� ����������� ������ �����.
	int cur_freed_count = 0;

	list<pos> sur_points;

	// �������� ����� �������.
	for (auto i = chain.begin(); i != chain.end(); i++)
		set_tag(*i);

	wave(	inside_point,
			[&, cur_player](pos cur_pos)->bool
			{
				if (is_not_bound(cur_pos, cur_player | put_bit | bound_bit))
				{
					check_captured_and_freed(cur_pos, cur_player, cur_capture_count, cur_freed_count);
					sur_points.push_back(cur_pos);
					return true;
				}
				else
				{
					return false;
				}
			});
	// ��������� ����� �������.
	add_sub_captured_freed(cur_player, cur_capture_count, cur_freed_count);

#if SUR_COND != 1
	if (cur_capture_count != 0) // ���� ��������� �����.
#endif
	{
		for (auto i = chain.begin(); i != chain.end(); i++)
		{
			clear_tag(*i);
			// ��������� � ������ ��������� ����� �������.
			_changes.back().changes.push(pair<pos, value>(*i, _points[*i]));
			// �������� ����� �������.
			set_base_bound(*i);
		}

		for (auto i = sur_points.begin(); i != sur_points.end(); i++)
		{
			_changes.back().changes.push(pair<pos, value>(*i, _points[*i]));

			set_capture_free_state(*i, cur_player);
		}
	}
	else // ���� ������ �� ���������.
	{
		for (auto i = chain.begin(); i != chain.end(); i++)
			clear_tag(*i);

		for (auto i = sur_points.begin(); i != sur_points.end(); i++)
		{
			_changes.back().changes.push(pair<pos, value>(*i, _points[*i]));

			if (!is_putted(*i))
				set_empty_base(*i);
		}
	}
}

field::field(const coord width, const coord height, const begin_pattern begin_pattern, zobrist* zobr)
{
	_width = width;
	_height = height;
	_player = player_red;
	_capture_count[player_red] = 0;
	_capture_count[player_black] = 0;

	_points = new value[length()];
	fill_n(_points, length(), 0);

	for (coord x = -1; x <= width; x++)
	{
		set_bad(to_pos(x, -1));
		set_bad(to_pos(x, height));
	}
	for (coord y = -1; y <= height; y++)
	{
		set_bad(to_pos(-1, y));
		set_bad(to_pos(width, y));
	}

	_changes.reserve(length());
	points_seq.reserve(length());

	_zobrist = zobr;
	_hash = 0;

	place_begin_pattern(begin_pattern);
}

field::field(const field &orig)
{
	_width = orig._width;
	_height = orig._height;
	_player = orig._player;
	_capture_count[player_red] = orig._capture_count[player_red];
	_capture_count[player_black] = orig._capture_count[player_black];

	_points = new value[length()];
	copy_n(orig._points, length(), _points);

	_changes.reserve(length());
	points_seq.reserve(length());

	_changes.assign(orig._changes.begin(), orig._changes.end());
	points_seq.assign(orig.points_seq.begin(), orig.points_seq.end());

	_zobrist = orig._zobrist;
	_hash = orig._hash;
}

field::~field()
{
	delete _points;
}

void field::wave(pos start_pos, function<bool(pos)> cond)
{
	// ������� ��� ��������� ��������� (������ � ������).
	list<pos> q;

	if (!cond(start_pos))
		return;

	q.push_back(start_pos);
	set_tag(start_pos);
	auto it = q.begin();
	while (it != q.end())
	{
		if (!is_tagged(w(*it)) && cond(w(*it)))
		{
			q.push_back(w(*it));
			set_tag(w(*it));
		}
		if (!is_tagged(n(*it)) && cond(n(*it)))
		{
			q.push_back(n(*it));
			set_tag(n(*it));
		}
		if (!is_tagged(e(*it)) && cond(e(*it)))
		{
			q.push_back(e(*it));
			set_tag(e(*it));
		}
		if (!is_tagged(s(*it)) && cond(s(*it)))
		{
			q.push_back(s(*it));
			set_tag(s(*it));
		}
		it++;
	}

	for (it = q.begin(); it != q.end(); it++)
		clear_tag(*it);
}

bool field::is_point_inside_ring(const pos cur_pos, const list<pos> &ring) const
{
	uint intersections = 0;

	intersection_state state = INTERSECTION_STATE_NONE;

	for (auto i = ring.begin(); i != ring.end(); i++)
	{
		switch (get_intersection_state(cur_pos, *i))
		{
		case (INTERSECTION_STATE_NONE):
			state = INTERSECTION_STATE_NONE;
			break;
		case (INTERSECTION_STATE_UP):
			if (state == INTERSECTION_STATE_DOWN)
				intersections++;
			state = INTERSECTION_STATE_UP;
			break;
		case (INTERSECTION_STATE_DOWN):
			if (state == INTERSECTION_STATE_UP)
				intersections++;
			state = INTERSECTION_STATE_DOWN;
			break;
		}
	}
	if (state == INTERSECTION_STATE_UP || state == INTERSECTION_STATE_DOWN)
	{
		auto i = ring.begin();
		intersection_state TempState = get_intersection_state(cur_pos, *i);
		while (TempState == state || TempState == INTERSECTION_STATE_TARGET)
		{
			i++;
			TempState = get_intersection_state(cur_pos, *i);
		}
		if (TempState != INTERSECTION_STATE_NONE)
			intersections++;
	}

	return intersections % 2 == 1;
}

void field::check_closure(const pos start_pos, player cur_player)
{
	short inp_points_count;
	pos inp_chain_points[4], inp_sur_points[4];

	list<pos> chain;

	if (is_in_empty_base(start_pos)) // ���� ����� ���������� � ������ ����.
	{
		// ���������, � ��� ������ ���� ���������� �����.
		pos Pos = start_pos - 1;
		while (!is_putted(Pos))
			Pos--;

		if (get_player(Pos) == get_player(start_pos)) // ���� ��������� � ���� ������ ����.
		{
			clear_empty_base(start_pos);
			return;
		}

#if SUR_COND != 2 // ���� ��������� �� ������ � �����.
		inp_points_count = get_input_points(start_pos, cur_player | put_bit, inp_chain_points, inp_sur_points);
		if (inp_points_count > 1)
		{
			short chains_count = 0;
			for (short i = 0; i < inp_points_count; i++)
				if (build_chain(start_pos, get_player(start_pos) | put_bit, inp_chain_points[i], chain))
				{
					find_surround(chain, inp_sur_points[i], cur_player);
					chains_count++;
					if (chains_count == inp_points_count - 1)
						break;
				}
				if (is_base_bound(start_pos))
				{
					remove_empty_base(start_pos);
					return;
				}
		}
#endif

		Pos++;
		do
		{
			Pos--;
			while (!is_enable(Pos, next_player(cur_player) | put_bit))
				Pos--;
			inp_points_count = get_input_points(Pos, next_player(cur_player) | put_bit, inp_chain_points, inp_sur_points);
			for (short i = 0; i < inp_points_count; i++)
				if (build_chain(Pos, next_player(cur_player) | put_bit, inp_chain_points[i], chain))
					if (is_point_inside_ring(start_pos, chain))
					{
						find_surround(chain, inp_sur_points[i], next_player(cur_player));
						break;
					}
		} while (!is_captured(start_pos));
	}
	else
	{
		inp_points_count = get_input_points(start_pos, cur_player | put_bit, inp_chain_points, inp_sur_points);
		if (inp_points_count > 1)
		{
			short chains_count = 0;
			for (short i = 0; i < inp_points_count; i++)
				if (build_chain(start_pos, cur_player | put_bit, inp_chain_points[i], chain))
				{
					find_surround(chain, inp_sur_points[i], cur_player);
					chains_count++;
					if (chains_count == inp_points_count - 1)
						break;
				}
		}
	}
}

bool field::check_closure(const pos start_pos, const pos checked_pos, player cur_player)
{
	pos InpChainPoints[4], InpSurPoints[4];

	list<pos> chain;

	short InpPointsCount = get_input_points(start_pos, cur_player | put_bit, InpChainPoints, InpSurPoints);
	if (InpPointsCount > 1)
	{
		for (ushort i = 0; i < InpPointsCount; i++)
			if (build_chain(start_pos, get_player(start_pos) | put_bit, InpChainPoints[i], chain))
				if (is_point_inside_ring(checked_pos, chain))
				{
					for (auto j = chain.begin(); j != chain.end(); j++)
					{
						// ��������� � ������ ��������� ����� �������.
						_changes.back().changes.push(pair<pos, value>(*j, _points[*j]));
						// �������� ����� �������.
						set_base_bound(*j);
					}
					return true;
				}
	}

	return false;
}