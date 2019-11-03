#pragma once

#include "config.h"
#include "basic_types.h"

using namespace std;

// �������� ���� ������� ������.
const player player_red = 0x0;
// �������� ���� ������� ������.
const player player_black = 0x1;

// �������� �� ������ ���������� ������.
inline player next_player(const player cur_player)
{
	return cur_player ^ 1;
}