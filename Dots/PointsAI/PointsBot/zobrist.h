#pragma once

#include "config.h"
#include "basic_types.h"
#include <boost/random.hpp>
#include <limits>

using namespace std;
using namespace boost;

// ��� ��������.
class zobrist
{
private:
	// ������ ������� �����.
	size_t _size;
	// ����.
	hash_t *_hashes;

public:
	// �����������.
	inline zobrist(size_t size, mt* gen)
	{
		random::uniform_int_distribution<hash_t> dist(numeric_limits<hash_t>::min(), numeric_limits<hash_t>::max());
		_size = size;
		_hashes = new hash_t[size];
		for (size_t i = 0; i < size; i++)
			_hashes[i] = dist(*gen);
	}
	// ����������� �����������.
	inline zobrist(const zobrist &other)
	{
		_size = other._size;
		_hashes = new hash_t[other._size];
		copy_n(other._hashes, other._size, _hashes);
	}
	// ����������.
	inline ~zobrist()
	{
		delete _hashes;
	}
	// ���������� ��� �������� �������� num.
	inline hash_t get_hash(size_t num)
	{
		return _hashes[num];
	}
};