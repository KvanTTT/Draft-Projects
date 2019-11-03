﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using PointsShell.Enums;

namespace PointsShell.Bots
{
	public class ConsoleBot : IBot
	{
		const string BotName = "PointsBot.exe";

		private Process _bot;

		private Random _random;

		private HashSet<string> _commands;

		public void Init(int width, int height, SurroundCond surCond, BeginPattern beginPattern)
		{
			if (_bot != null)
				Final();
			_random = new Random();
			_commands = new HashSet<string>();
			_bot = new Process
			      	{
			      		EnableRaisingEvents = false,
			      		StartInfo =
			      			{
			      				UseShellExecute = false,
								RedirectStandardInput = true,
			      				RedirectStandardOutput = true,
			      				RedirectStandardError = true,
			      				CreateNoWindow = true,
			      				FileName = BotName
			      			}
			      	};
			if (!_bot.Start())
				throw new Exception("Error while starting.");
			_bot.PriorityClass = ProcessPriorityClass.Idle;
			// list_commands
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} list_commands", id);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("list_commands: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "list_commands")
				throw new Exception("list_commands: Error while executing.");
			if (splittedAnswer.Length < 4 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "list_commands")
				throw new Exception("list_commands: Invalid answer.");
			for (var i = 3; i < splittedAnswer.Length; i++)
				_commands.Add(splittedAnswer[i]);
			// init.
			if (!_commands.Contains("init"))
				throw new Exception("init: Not supported.");
			id = _random.Next();
			_bot.StandardInput.WriteLine("{0} init {1} {2} {3}", id, width, height, 78526081);
			answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("init: Answer is null.");
			splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "init")
				throw new Exception("init: Error while executing.");
			if (splittedAnswer.Length != 3 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "init")
				throw new Exception("init: Invalid answer.");
		}

		public void Final()
		{
			if (_bot == null)
				return;
			try
			{
				if (!_bot.HasExited && _commands.Contains("quit"))
				{
					_bot.StandardInput.WriteLine("{0} quit", _random.Next());
					_bot.WaitForExit(100);
				}
				if (!_bot.HasExited)
					_bot.Kill();
			}
			finally
			{
				_bot = null;
			}
		}

		public void PutPoint(Pos pos, PlayerColor player)
		{
			if (_bot == null)
				throw new Exception("play: Not initialized.");
			if (!_commands.Contains("play"))
				throw new Exception("play: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} play {1} {2} {3}", id, pos.X - 1, pos.Y - 1, (int)player);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("play: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "play")
				throw new Exception("play: Error while executing.");
			if (splittedAnswer.Length != 6 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "play" || splittedAnswer[3] != (pos.X - 1).ToString() || splittedAnswer[4] != (pos.Y - 1).ToString() || splittedAnswer[5] != ((int)player).ToString())
				throw new Exception("play: Invalid answer.");
		}

		public void RemoveLastPoint()
		{
			if (_bot == null)
				throw new Exception("undo: Not initialized.");
			if (!_commands.Contains("undo"))
				throw new Exception("undo: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} undo", id);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("undo: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "undo")
				throw new Exception("undo: Error while executing.");
			if (splittedAnswer.Length != 3 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "undo")
				throw new Exception("undo: Invalid answer.");
		}

		public Pos GetMove(PlayerColor player)
		{
			int x, y;
			if (_bot == null)
				throw new Exception("gen_move: Not initialized.");
			if (!_commands.Contains("gen_move"))
				throw new Exception("gen_move: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} gen_move {1}", id, (int)player);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("gen_move: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "gen_move")
				throw new Exception("gen_move: Error while executing.");
			if (splittedAnswer.Length != 6 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "gen_move" || !int.TryParse(splittedAnswer[3], out x) || !int.TryParse(splittedAnswer[4], out y) || splittedAnswer[5] != ((int)player).ToString())
				throw new Exception("gen_move: Error while executing.");
			return new Pos(x + 1, y + 1);
		}

		public Pos GetMoveWithComplexity(PlayerColor player, int complexity)
		{
			int x, y;
			if (_bot == null)
				throw new Exception("gen_move_with_complexity: Not initialized.");
			if (!_commands.Contains("gen_move_with_complexity"))
				throw new Exception("gen_move_with_complexity: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} gen_move_with_complexity {1} {2}", id, (int)player, complexity);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("gen_move_with_complexity: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "gen_move_with_complexity")
				throw new Exception("gen_move_with_complexity: Error while executing.");
			if (splittedAnswer.Length != 6 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "gen_move_with_complexity" || !int.TryParse(splittedAnswer[3], out x) || !int.TryParse(splittedAnswer[4], out y) || splittedAnswer[5] != ((int)player).ToString())
				throw new Exception("gen_move_with_complexity: Error while executing.");
			return new Pos(x + 1, y + 1);
		}

		public Pos GetMoveWithTime(PlayerColor player, int time)
		{
			int x, y;
			if (_bot == null)
				throw new Exception("gen_move_with_time: Not initialized.");
			if (!_commands.Contains("gen_move_with_time"))
				throw new Exception("gen_move_with_time: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} gen_move_with_time {1} {2}", id, (int)player, time);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("gen_move_with_time: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "gen_move_with_time")
				throw new Exception("gen_move_with_time: Error while executing.");
			if (splittedAnswer.Length != 6 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "gen_move_with_time" || !int.TryParse(splittedAnswer[3], out x) || !int.TryParse(splittedAnswer[4], out y) || splittedAnswer[5] != ((int)player).ToString())
				throw new Exception("gen_move_with_time: Error while executing.");
			return new Pos(x + 1, y + 1);
		}

		public string GetName()
		{
			if (_bot == null)
				throw new Exception("name: Not initialized.");
			if (!_commands.Contains("name"))
				throw new Exception("name: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} name", id);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("name: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "version")
				throw new Exception("name: Error while executing.");
			if (splittedAnswer.Length != 4 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "name")
				throw new Exception("name: Invalid answer.");
			return splittedAnswer[3];
		}

		public string GetVersion()
		{
			if (_bot == null)
				throw new Exception("version: Not initialized.");
			if (!_commands.Contains("version"))
				throw new Exception("version: Not supported.");
			var id = _random.Next();
			_bot.StandardInput.WriteLine("{0} version", id);
			var answer = _bot.StandardOutput.ReadLine();
			if (answer == null)
				throw new Exception("version: Answer is null.");
			var splittedAnswer = answer.Split();
			if (splittedAnswer.Length == 3 && splittedAnswer[0] == "?" && splittedAnswer[1] == id.ToString() && splittedAnswer[2] == "version")
				throw new Exception("version: Error while executing.");
			if (splittedAnswer.Length != 4 || splittedAnswer[0] != "=" || splittedAnswer[1] != id.ToString() || splittedAnswer[2] != "version")
				throw new Exception("version: Invalid answer.");
			return splittedAnswer[3];
		}

		public void Dispose()
		{
			Final();
		}
	}
}
