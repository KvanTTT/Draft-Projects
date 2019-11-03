#pragma once

// ������� ��������� ������ ���.
// STANDART = 0 - ���� PlayerRed ������ � ������ ���� � ������ �� �������, �� PlayerBlack ������� ��� ����������.
// ALWAYS = 1 - �������� ����, ���� ���� ��� ��������� ����� ������.
// ALWAYS_ENEMY = 2 - ������� ������ PlayerBlack, ���� PlayerRed �������� ����� � ������ ����.
#define SUR_COND 0

// �������� ���������� �� ������������ ��� ��������� ���������-���������.
#define ALPHABETA_SORT 1

// ���������� �� ������� � ����������� alphabeta ��� ��������� alpha � beta.
#define CALCULATE_BOUNDARIES 1

#define NEGASCOUT 1

// Larger values give uniform search.
// Smaller values give very selective search.
#define UCTK 1

// ������, ������ �������� ���������� ������ UCT.
#define UCT_RADIUS 2

// ���������� �������� uct ����� ��������� �������.
#define UCT_ITERATIONS_BEFORE_CHECK_TIME 100

// ������ ������ ������� ����.
// 0 - position estimate
// 1 - minimax
// 2 - uct
// 3 - minimax with uct
// 4 - MTD(f)
// 5 - MTD(f) with uct
#define SEARCH_TYPE 3
#define SEARCH_WITH_COMPLEXITY_TYPE 3
#define SEARCH_WITH_TIME_TYPE 2

#define MIN_MINIMAX_DEPTH 0
#define MAX_MINIMAX_DEPTH 10
#define DEFAULT_MINIMAX_DEPTH 8
#define MIN_MTDF_DEPTH 0
#define MAX_MTDF_DEPTH 10
#define DEFAULT_MTDF_DEPTH 8
#define MIN_UCT_ITERATIONS 0
#define MAX_UCT_ITERATIONS 250000
#define DEFAULT_UCT_ITERATIONS 200000
#define MIN_COMPLEXITY 0
#define MAX_COMPLEXITY 100