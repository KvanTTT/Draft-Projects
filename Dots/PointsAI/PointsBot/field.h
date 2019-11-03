#pragma once

#include "config.h"
#include "basic_types.h"
#include "zobrist.h"
#include "player.h"
#include <stack>
#include <list>
#include <vector>
#include <algorithm>
#include <functional>
#include <utility>

using namespace std;

class field
{
#pragma region State bits and masks
private:

	// ���, ����������� ����� ������.
	static const value player_bit = 0x1;
	// ���, ����������� �� ������� ����� � ����.
	static const value put_bit = 0x2;
	// ���, ����������� �� ������������� �����.
	static const value sur_bit = 0x4;
	// ���, ����������� �� ��, ����������� �� ���-������ ����� �� ����.
	static const value bound_bit = 0x8;
	// ���, ����������� �� ������ ����.
	static const value empty_base_bit = 0x10;
	// ��� ��� ��������� ������� �����.
	static const value tag_bit = 0x20;
	// ���, ������� ���������� ������� ����.
	static const value bad_bit = 0x40;

	// ����� ��� ����������� �������.
	static const value enable_mask = bad_bit | sur_bit | put_bit | player_bit;
	static const value bound_mask = bad_bit | bound_bit | sur_bit | put_bit | player_bit;
#pragma endregion

#pragma region Get and set state functions
public:
	// Get state functions.
	// ������� ��������� ���������.

	// �������� �� ���������� ������, ��� ����� ��� ����������.
	inline player get_player(const pos cur_pos) const { return _points[cur_pos] & player_bit; }
	// ��������� �� ����������, ���������� �� ��� �����.
	inline bool is_putted(const pos cur_pos) const { return (_points[cur_pos] & put_bit) != 0; }
	// �������� �� ����������, �������� �� ����� ���������� ����.
	inline bool is_base_bound(const pos cur_pos) const { return (_points[cur_pos] & bound_bit) != 0; }
	// ��������� �� ����������, ��������� �� ����.
	inline bool is_captured(const pos cur_pos) const { return (_points[cur_pos] & sur_bit) != 0; }
	// ��������� �� ����������, ����� �� ��� � ������ ����.
	inline bool is_in_empty_base(const pos cur_pos) const { return (_points[cur_pos] & empty_base_bit) != 0; }
	// ��������� �� ����������, �������� �� ����.
	inline bool is_tagged(const pos cur_pos) const { return (_points[cur_pos] & tag_bit) != 0; }
	// �������� ������� �� ����������.
	inline value get_enable_cond(const pos cur_pos) const { return _points[cur_pos] & enable_mask; }
	// �������� ����������� ���� �� �������.
	inline bool is_enable(const pos cur_pos, const value enable_cond) const { return (_points[cur_pos] & enable_mask) == enable_cond; }
	// �������� ��������� ���� �� �������.
	inline bool is_not_enable(const pos cur_pos, const value enable_cond) const { return (_points[cur_pos] & enable_mask) != enable_cond; }
	// �������� �� ��, ��������� �� ����.
	inline bool is_bound(const pos cur_pos, const value bound_cond) const { return (_points[cur_pos] & bound_mask) == bound_cond; }
	// �������� �� ��, �� ��������� �� ����.
	inline bool is_not_bound(const pos cur_pos, const value bound_cond) const { return (_points[cur_pos] & bound_mask) != bound_cond; }
	// ������� �� ��, �������� �� ��������� ����� � �����.
	inline bool putting_allow(const pos cur_pos) const { return !(_points[cur_pos] & (put_bit | sur_bit | bad_bit)); }

	// Set state functions.
	// ������� ��������� ���������.

	// �������� ���� �� ���������� ��� ���������� �����.
	inline void set_putted(const pos cur_pos) { _points[cur_pos] |= put_bit; }
	// ������ � ���� �� ���������� put_bit.
	inline void clear_put_bit(const pos cur_pos) { _points[cur_pos] &= ~put_bit; }
	// �������� ���� �� ���������� ��� ������������� ������.
	inline void set_player(const pos cur_pos, const player cur_player) { _points[cur_pos] = (_points[cur_pos] & ~player_bit) | cur_player; }
	// �������� ���� �� ���������� ��� ���������� ����� ������.
	inline void set_player_putted(const pos cur_pos, const player cur_player) { _points[cur_pos] = (_points[cur_pos] & ~player_bit) | cur_player | put_bit; }
	// �������� ����� SurBit (���������).
	inline void capture(const pos cur_pos) { _points[cur_pos] |= sur_bit; }
	// ������ ��� SurBit.
	inline void free(const pos cur_pos) { _points[cur_pos] &= ~sur_bit; }
	// �������� ����� ��� ���������� ����.
	inline void set_base_bound(const pos cur_pos) { _points[cur_pos] |= bound_bit; }
	// �������� ����� ��� �� ���������� ����.
	inline void clear_base_bound(const pos cur_pos) { _points[cur_pos] &= ~bound_bit; }
	inline void set_empty_base(const pos cur_pos) { _points[cur_pos] |= empty_base_bit; }
	inline void clear_empty_base(const pos cur_pos) { _points[cur_pos] &= ~empty_base_bit; }
	// ���������� ��� TagBit.
	inline void set_tag(const pos cur_pos) { _points[cur_pos] |= tag_bit; }
	// ������ ��� TagBit.
	inline void clear_tag(const pos cur_pos) { _points[cur_pos] &= ~tag_bit; }
	inline void set_bad(const pos cur_pos) { _points[cur_pos] |= bad_bit; }
	inline void clear_bad(const pos Pos) { _points[Pos] &= ~bad_bit; }
#pragma endregion

#pragma region Main variables
private:
	vector<board_change> _changes;

	// Main points array (game board).
	// �������� ������ ����� (������� �����).
	value* _points;

	// Real field width.
	// �������������� ������ ����.
	coord _width;
	// Real field height.
	// �������������� ������ ����.
	coord _height;

#if SURROUND_CONDITIONS
	sur_cond _sur_cond;
#endif

	// Current player color.
	// ������� ���� �������.
	player _player;

	// Capture points count.
	// ���������� ����������� �����.
	score _capture_count[2];

	zobrist* _zobrist;

	size_t _hash;

public:
	// History points sequance.
	// ������������������ ������������ �����.
	vector<pos> points_seq;
#pragma endregion

private:
	// ���������� ����� ������������ �������� Pos1 � Pos2.
	inline int square(const pos pos1, const pos pos2) const { return to_x(pos1) * to_y(pos2) - to_y(pos1) * to_x(pos2); }
	//  * . .   x . *   . x x   . . .
	//  . o .   x o .   . o .   . o x
	//  x x .   . . .   . . *   * . x
	//  o - center pos
	//  x - pos
	//  * - result
	inline void get_first_next_pos(const pos center_pos, pos &cur_pos) const
	{
		if (cur_pos < center_pos)
		{
			if ((cur_pos == nw(center_pos)) || (cur_pos == center_pos - 1))
				cur_pos = ne(center_pos); 
			else
				cur_pos = se(center_pos);
		}
		else
		{
			if ((cur_pos == center_pos + 1) || (cur_pos == se(center_pos)))
				cur_pos = sw(center_pos);
			else
				cur_pos = nw(center_pos);
		}
	}
	//  . . .   * . .   x * .   . x *   . . x   . . .   . . .   . . .
	//  * o .   x o .   . o .   . o .   . o *   . o x   . o .   . o .
	//  x . .   . . .   . . .   . . .   . . .   . . *   . * x   * x .
	//  o - center pos
	//  x - pos
	//  * - result
	inline void get_next_pos(const pos center_pos, pos &cur_pos) const
	{
		if (cur_pos < center_pos)
		{
			if (cur_pos == nw(center_pos))
				cur_pos = n(center_pos);
			else if (cur_pos == n(center_pos))
				cur_pos = ne(center_pos);
			else if (cur_pos == ne(center_pos))
				cur_pos = e(center_pos);
			else
				cur_pos = nw(center_pos);
		}
		else
		{
			if (cur_pos == e(center_pos))
				cur_pos = se(center_pos);
			else if (cur_pos == se(center_pos))
				cur_pos = s(center_pos);
			else if (cur_pos == s(center_pos))
				cur_pos = sw(center_pos);
			else
				cur_pos = w(center_pos);
		}
	}
	// ���������� ���������� ����� ����� ����� � CenterPos.
	// InpChainPoints - ��������� ����� �����, InpSurPoints - ��������� ���������� �����.
	short get_input_points(const pos center_pos, const value enable_cond, pos inp_chain_points[], pos inp_sur_points[]) const;
	// ��������� ��������� �����.
	void place_begin_pattern(begin_pattern cur_pattern);
	// ��������� ����� �������.
	inline void add_sub_captured_freed(const player cur_player, const score captured, const score freed)
	{
		if (captured == -1)
		{
			_capture_count[next_player(cur_player)]++;
		}
		else
		{
			_capture_count[cur_player] += captured;
			_capture_count[next_player(cur_player)] -= freed;
		}
	}
	// �������� Captured/Free � ����������� �� ����, ��������� ��� �������� �����.
	inline void check_captured_and_freed(const pos cur_pos, const player cur_player, score &captured, score &freed)
	{
		if (is_putted(cur_pos))
		{
			if (get_player(cur_pos) != cur_player)
				captured++;
			else if (is_captured(cur_pos))
				freed++;
		}
	}
	// �����������/����������� ���������� �����.
	inline void set_capture_free_state(const pos cur_pos, const player cur_player)
	{
		if (is_putted(cur_pos))
		{
			if (get_player(cur_pos) != cur_player)
				capture(cur_pos);
			else
				free(cur_pos);
		}
		else
			capture(cur_pos);
	}
	// ������� ������� ������ ���� � ���� �����, ������� � ������� StartPos.
	void remove_empty_base(const pos StartPos);
	bool build_chain(const pos start_pos, const value enable_cond, const pos direction_pos, list<pos> &chain);
	void find_surround(list<pos> &chain, pos inside_point, player cur_player);
	inline void update_hash(player cur_player, pos cur_pos) { _hash ^= _zobrist->get_hash((cur_player + 1) * cur_pos); }
	inline intersection_state get_intersection_state(const pos cur_pos, const pos next_pos) const
	{
		point a, b;
		to_xy(cur_pos, a.x, a.y);
		to_xy(next_pos, b.x, b.y);

		if (b.x <= a.x)
			switch (b.y - a.y)
			{
				case (1):
					return INTERSECTION_STATE_UP;
				case (0):
					return INTERSECTION_STATE_TARGET;
				case (-1):
					return INTERSECTION_STATE_DOWN;
				default:
					return INTERSECTION_STATE_NONE;
			}
		else
			return INTERSECTION_STATE_NONE;
	}

public:
	// �����������.
#if SURROUND_CONDITIONS
	field(const coord width, const coord height, const sur_cond sur_cond, const begin_pattern begin_pattern, zobrist* zobr);
#else
	field(const coord width, const coord height, const begin_pattern begin_pattern, zobrist* zobr);
#endif
	// ����������� �����������.
	field(const field &orig);
	// ����������.
	~field();

	inline score get_score(player cur_player) const { return _capture_count[cur_player] - _capture_count[next_player(cur_player)]; }
	inline score get_prev_score(player cur_player) const { return _changes.back().capture_count[cur_player] - _changes.back().capture_count[next_player(cur_player)]; }
	inline player get_last_player() const { return get_player(points_seq.back()); }
	inline score get_d_score(player cur_player) const { return get_score(cur_player) - get_prev_score(cur_player); }
	inline score get_d_score() const { return get_d_score(get_last_player()); }
	inline player get_player() const { return _player; }
#if SURROUND_CONDITIONS
	inline sur_cond get_sur_cond() const { return _sur_cond; }
#endif
	inline size_t get_hash() const { return _hash; }
	inline size_t get_hash(pos cur_pos) const { return _zobrist->get_hash(cur_pos); }
	inline zobrist& get_zobrist() const { return *_zobrist; };
	inline coord width() const { return _width; }
	inline coord height() const { return _height; }
	inline pos length() const { return (_width + 2) * (_height + 2); }
	inline pos min_pos() const { return to_pos(0, 0); }
	inline pos max_pos() const { return to_pos(_width - 1, _height - 1); }
	inline pos n(pos cur_pos) const { return cur_pos - (_width + 2); }
	inline pos s(pos cur_pos) const { return cur_pos + (_width + 2); }
	inline pos w(pos cur_pos) const { return cur_pos - 1; }
	inline pos e(pos cur_pos) const { return cur_pos + 1; }
	inline pos nw(pos cur_pos) const { return cur_pos - (_width + 2) - 1; }
	inline pos ne(pos cur_pos) const { return cur_pos - (_width + 2) + 1; }
	inline pos sw(pos cur_pos) const { return cur_pos + (_width + 2) - 1; }
	inline pos se(pos cur_pos) const { return cur_pos + (_width + 2) + 1; }
	inline pos to_pos(const coord x, const coord y) const { return (y + 1) * (_width + 2) + x + 1; }
	inline coord to_x(const pos cur_pos) const { return static_cast<coord>(cur_pos % (_width + 2) - 1); }
	inline coord to_y(const pos cur_pos) const { return static_cast<coord>(cur_pos / (_width + 2) - 1); }
	// ����������� �� Pos � XY.
	inline void to_xy(const pos cur_pos, coord &x, coord &y) const { x = to_x(cur_pos); y = to_y(cur_pos); }
	inline void set_player(const player cur_player) { _player = cur_player; }
	// ���������� ���������� ������ ��� ��������.
	inline void set_next_player() { set_player(next_player(_player)); }
	// ��������� ����� �� ���� ���������� �� ������� ������.
	inline bool do_step(const pos cur_pos)
	{
		if (putting_allow(cur_pos))
		{
			do_unsafe_step(cur_pos);
			return true;
		}
		return false;
	}
	// ��������� ����� �� ����.
	inline bool do_step(const pos cur_pos, const player cur_player)
	{
		if (putting_allow(cur_pos))
		{
			do_unsafe_step(cur_pos, cur_player);
			return true;
		}
		return false;
	}
	// ��������� ����� �� ���� ����������� ������ (��� �������������� ��������).
	inline void do_unsafe_step(const pos cur_pos)
	{
		_changes.push_back(board_change());
		_changes.back().capture_count[0] = _capture_count[0];
		_changes.back().capture_count[1] = _capture_count[1];
		_changes.back().last_player = _player;

		// ��������� � ��������� ������������ �����.
		_changes.back().changes.push(pair<pos, value>(cur_pos, _points[cur_pos]));

		set_player_putted(cur_pos, _player);

		points_seq.push_back(cur_pos);

		check_closure(cur_pos, _player);

		set_next_player();
	}
	// ��������� ����� �� ���� ���������� �� ������� ������ ����������� ������ (��� �������������� ��������).
	inline void do_unsafe_step(const pos cur_pos, const player cur_player)
	{
		_changes.push_back(board_change());
		_changes.back().capture_count[0] = _capture_count[0];
		_changes.back().capture_count[1] = _capture_count[1];
		_changes.back().last_player = _player;

		// ��������� � ��������� ������������ �����.
		_changes.back().changes.push(pair<pos, value>(cur_pos, _points[cur_pos]));

		set_player_putted(cur_pos, cur_player);

		points_seq.push_back(cur_pos);

		check_closure(cur_pos, cur_player);
	}
	// ������ ��� � ��������� �� ������������ ������ ����� CheckedPos.
	inline bool do_unsafe_step_and_check_point(const pos cur_pos, const player cur_player, const pos checked_pos)
	{
		_changes.push_back(board_change());
		_changes.back().capture_count[0] = _capture_count[0];
		_changes.back().capture_count[1] = _capture_count[1];
		_changes.back().last_player = _player;

		// ��������� � ��������� ������������ �����.
		_changes.back().changes.push(pair<pos, value>(cur_pos, _points[cur_pos]));

		set_player(cur_pos, cur_player);
		set_putted(cur_pos);

		points_seq.push_back(cur_pos);
		
		return check_closure(cur_pos, checked_pos, cur_player);
	}
	// ����� ����.
	inline void undo_step()
	{
		points_seq.pop_back();
		while (!_changes.back().changes.empty())
		{
			_points[_changes.back().changes.top().first] = _changes.back().changes.top().second;
			_changes.back().changes.pop();
		}
		_player = _changes.back().last_player;
		_capture_count[0] = _changes.back().capture_count[0];
		_capture_count[1] = _changes.back().capture_count[1];
		_changes.pop_back();
	}
	// ���������, ��������� �� ��� ����� �����.
	inline bool is_near(const pos pos1, const pos pos2) const
	{
		if (n(pos1) == pos2  ||
			s(pos1) == pos2  ||
			w(pos1) == pos2  ||
			e(pos1) == pos2  ||
			nw(pos1) == pos2 ||
			ne(pos1) == pos2 ||
			sw(pos1) == pos2 ||
			se(pos1) == pos2)
			return true;
		else
			return false;
	}
	// ���������, ���� �� ����� � center_pos ����� ����� cur_player.
	inline bool is_near_points(const pos center_pos, const player cur_player) const
	{
		if (is_enable(n(center_pos), put_bit | cur_player)  ||
			is_enable(s(center_pos), put_bit | cur_player)  ||
			is_enable(w(center_pos), put_bit | cur_player)  ||
			is_enable(e(center_pos), put_bit | cur_player)  ||
			is_enable(nw(center_pos), put_bit | cur_player) ||
			is_enable(ne(center_pos), put_bit | cur_player) ||
			is_enable(sw(center_pos), put_bit | cur_player) ||
			is_enable(se(center_pos), put_bit | cur_player))
			return true;
		else
			return false;
	}
	// ���������� ���������� ����� ����� � center_pos ����� cur_player.
	inline short number_near_points(const pos center_pos, const player cur_player) const
	{
		short result = 0;
		if (is_enable(n(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(s(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(w(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(e(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(nw(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(ne(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(sw(center_pos), put_bit | cur_player))
			result++;
		if (is_enable(se(center_pos), put_bit | cur_player))
			result++;
		return result;
	}
	// ���������� ���������� ����� ����� ����� � CenterPos.
	inline short number_near_groups(const pos center_pos, const player cur_player) const
	{
		short result = 0;
		if (is_not_enable(w(center_pos), cur_player | put_bit) && (is_enable(nw(center_pos), cur_player | put_bit) || is_enable(n(center_pos), cur_player | put_bit)))
			result++;
		if (is_not_enable(s(center_pos), cur_player | put_bit) && (is_enable(sw(center_pos), cur_player | put_bit) || is_enable(w(center_pos), cur_player | put_bit)))
			result++;
		if (is_not_enable(e(center_pos), cur_player | put_bit) && (is_enable(se(center_pos), cur_player | put_bit) || is_enable(s(center_pos), cur_player | put_bit)))
			result++;
		if (is_not_enable(n(center_pos), cur_player | put_bit) && (is_enable(ne(center_pos), cur_player | put_bit) || is_enable(e(center_pos), cur_player | put_bit)))
			result++;
		return result;
	}
	void wave(pos start_pos, function<bool(pos)> cond);
	bool is_point_inside_ring(const pos cur_pos, const list<pos> &ring) const;
	// ��������� ������������ ����� �� ������� ��������� �� ���������, � ��������, ���� ��� ����.
	void check_closure(const pos start_pos, player cur_player);
	// ��������� ������������ �����, �� �������� �� ��� ������� checked_pos.
	bool check_closure(const pos start_pos, const pos checked_pos, player cur_player);
};
