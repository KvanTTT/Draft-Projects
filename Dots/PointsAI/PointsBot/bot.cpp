#include "config.h"
#include "basic_types.h"
#include "bot.h"
#include "time.h"
#include "field.h"
#include "minimax.h"
#include "uct.h"
#include "position_estimate.h"
#include "zobrist.h"
#include <list>
#include "mtdf.h"

using namespace std;

bot::bot(const coord width, const coord height, const begin_pattern begin_pattern, ptrdiff_t seed)
{
	_gen = new mt(seed);
	_zobrist = new zobrist((width + 2) * (height + 2), _gen);
	_field = new field(width, height, begin_pattern, _zobrist);
}

bot::~bot()
{
	delete _field;
	delete _zobrist;
	delete _gen;
}

size_t bot::get_minimax_depth(size_t complexity)
{
	return (complexity - MIN_COMPLEXITY) * (MAX_MINIMAX_DEPTH - MIN_MINIMAX_DEPTH) / (MAX_COMPLEXITY - MIN_COMPLEXITY) + MIN_MINIMAX_DEPTH;
}

size_t bot::get_mtdf_depth(size_t complexity)
{
	return (complexity - MIN_COMPLEXITY) * (MAX_MTDF_DEPTH - MIN_MTDF_DEPTH) / (MAX_COMPLEXITY - MIN_COMPLEXITY) + MIN_MTDF_DEPTH;
}

size_t bot::get_uct_iterations(size_t complexity)
{
	return (complexity - MIN_COMPLEXITY) * (MAX_UCT_ITERATIONS - MIN_UCT_ITERATIONS) / (MAX_COMPLEXITY - MIN_COMPLEXITY) + MIN_UCT_ITERATIONS;
}

bool bot::do_step(coord x, coord y, player cur_player)
{
	return _field->do_step(_field->to_pos(static_cast<coord>(x), static_cast<coord>(y)), cur_player);
}

bool bot::undo_step()
{
	if (_field->points_seq.size() == 0)
		return false;
	_field->undo_step();
	return true;
}

void bot::set_player(player cur_player)
{
	_field->set_player(cur_player);
}

bool bot::is_field_occupied() const
{
	for (pos i = _field->min_pos(); i <= _field->max_pos(); i++)
		if (_field->putting_allow(i))
			return false;
	return true;
}

bool bot::boundary_check(coord& x, coord& y) const
{
	if (_field->points_seq.size() == 0)
	{
		x = _field->width() / 2;
		y = _field->height() / 2;
		return true;
	}
	if (is_field_occupied())
	{
		x = -1;
		y = -1;
		return true;
	}
	return false;
}

void bot::get(coord& x, coord& y)
{
	if (boundary_check(x, y))
		return;
#if SEARCH_TYPE == 0 // position estimate
	pos result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_TYPE == 1 // minimax
	pos result =  minimax(_field, DEFAULT_MINIMAX_DEPTH);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_TYPE == 2 // uct
	pos result = uct(_field, _gen, DEFAULT_UCT_ITERATIONS);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_TYPE == 3 // minimax with uct
	pos result =  minimax(_field, DEFAULT_MINIMAX_DEPTH);
	if (result == -1)
		result = uct(_field, _gen, DEFAULT_UCT_ITERATIONS);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_TYPE == 4 // MTD(f)
	pos result =  mtdf(_field, DEFAULT_MTDF_DEPTH);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_TYPE == 5 // MTD(f) with uct
	pos result =  mtdf(_field, DEFAULT_MTDF_DEPTH);
	if (result == -1)
		result = uct(_field, _gen, DEFAULT_UCT_ITERATIONS);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#else
#error Invalid SEARCH_TYPE.
#endif
}

void bot::get_with_complexity(coord& x, coord& y, size_t complexity)
{
	if (boundary_check(x, y))
		return;
#if SEARCH_WITH_COMPLEXITY_TYPE == 0 // positon estimate
	pos result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_COMPLEXITY_TYPE == 1 // minimax
	pos result =  minimax(_field, get_minimax_depth(complexity));
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_COMPLEXITY_TYPE == 2 // uct
	pos result = uct(_field, _gen, get_uct_iterations(complexity));
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_COMPLEXITY_TYPE == 3 // minimax with uct
	pos result =  minimax(_field, get_minimax_depth(complexity));
	if (result == -1)
		result = uct(_field, _gen, get_uct_iterations(complexity));
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_COMPLEXITY_TYPE == 4 // MTD(f)
	pos result =  mtdf(_field, get_mtdf_depth(complexity));
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_COMPLEXITY_TYPE == 5 // MTD(f) with uct
	pos result =  mtdf(_field, get_mtdf_depth(complexity));
	if (result == -1)
		result = uct(_field, _gen, get_uct_iterations(complexity));
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#else
#error Invalid SEARCH_WITH_COMPLEXITY_TYPE.
#endif
}

void bot::get_with_time(coord& x, coord& y, size_t time)
{
	if (boundary_check(x, y))
		return;
#if SEARCH_WITH_TIME_TYPE == 0 // position estimate
	pos result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_TIME_TYPE == 1 // minimax
#error Invalid SEARCH_WITH_TIME_TYPE.
#elif SEARCH_WITH_TIME_TYPE == 2 // uct
	pos result = uct_with_time(_field, _gen, time);
	if (result == -1)
		result = position_estimate(_field);
	x = _field->to_x(result);
	y = _field->to_y(result);
#elif SEARCH_WITH_TIME_TYPE == 3 // minimax with uct
#error Invalid SEARCH_WITH_TIME_TYPE.
#elif SEARCH_WITH_TIME_TYPE == 4 // MTD(f)
#error Invalid SEARCH_WITH_TIME_TYPE.
#elif SEARCH_WITH_TIME_TYPE == 5 // MTD(f) with uct
#error Invalid SEARCH_WITH_TIME_TYPE.
#else
#error Invalid SEARCH_WITH_TIME_TYPE.
#endif
}