#include "config.h"
#include "field_serializer.h"
#include "basic_types.h"
#include "player.h"
#include "field.h"
#include <string>
#include <fstream>

using namespace std;

bool field_serializer::to_xt(field &cur_field, string file_name)
{
	if (cur_field.width() != 39 || cur_field.height() != 32 || cur_field.points_seq.size() == 0)
		return false;

	ofstream stream(file_name, ios::binary | ios::out | ios::trunc);

	if (!stream)
		return false;

	// ������ ���� - ������ �������.
	stream << static_cast<char>(121);
	// ��������� 2 ����� - ���������� ������������ ����� - 1.
	stream << static_cast<char>((cur_field.points_seq.size() - 1) & 0xFF); stream << static_cast<char>(((cur_field.points_seq.size() - 1) >> 8) & 0xFF);
	// ����� 2 �����, ����������� �� ���� ���������� ������, ���������� ���.
	if (cur_field.get_player(cur_field.points_seq.back()) == player_red)
	{
		stream << static_cast<char>(0xFF); stream << static_cast<char>(0xFF);
	}
	else
	{
		stream << static_cast<char>(0xFF);
	}
	// ???
	stream << static_cast<char>(0x00); stream << static_cast<char>(0x00);
	stream << static_cast<char>(0x00); stream << static_cast<char>(0x00);
	stream << static_cast<char>(0x00); stream << static_cast<char>(0x00);
	// ����� ���� ����� ���� ������� �� 9 ����.
	stream << "                  ";
	// ������, ����� � ������ ������� ������ ���� ����� ���������� ������ ��� �� �����������������, ������ ����.
	for (ushort i = 0; i < 29; i++)
		stream << static_cast<char>(0x00);
	for (auto i = cur_field.points_seq.begin(); i < cur_field.points_seq.end(); i++)
	{
		// ����� ���������� ���� - X, Y.
		stream << static_cast<char>(cur_field.to_x(*i));
		stream << static_cast<char>(cur_field.to_y(*i));
		// � ���� ����� ���������� ������������������ �����, �� ������� ������� ������� ����� ��� �������� ��������� (������� ���� � �������� ���� ���������). �� �������, ���� ����� �������� ���.
		stream << static_cast<char>(1);
		// ����� ���� ������, ������������ �����.
		if (cur_field.get_player(*i) == player_red)
		{
			stream << static_cast<char>(0xFF); stream << static_cast<char>(0xFF);
		}
		else
		{
			stream << static_cast<char>(0x00); stream << static_cast<char>(0x00);
		}
		// ???
		for (short j = 0; j < 8; j++)
			stream << static_cast<char>(0x00);
	}

	return true;
}