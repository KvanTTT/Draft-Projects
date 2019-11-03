﻿using System;
using PointsShell.Enums;

namespace PointsShell.Bots
{
	public interface IBot : IDisposable
	{
		void Init(int width, int height, SurroundCond surCond, BeginPattern beginPattern);
		void Final();
		void PutPoint(Pos pos, PlayerColor player);
		void RemoveLastPoint();
		Pos GetMove(PlayerColor player);
		Pos GetMoveWithComplexity(PlayerColor player, int complexity);
		Pos GetMoveWithTime(PlayerColor player, int time);
		string GetName();
		string GetVersion();
	}
}
