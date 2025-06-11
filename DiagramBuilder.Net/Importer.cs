using System;
using System.Collections.Generic;
using System.IO;
using Chess;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace DiagramBuilder.Net
{
	// Class for importing data from different type of files
	internal class Importer
	{
		public List<ChessBoard> FromOlive(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			var boards = new List<ChessBoard>();
			try
			{
				using (var reader = new StreamReader(path))
				{
					var deserializer = new Deserializer();
					var parser = new Parser(reader);

					while (parser.MoveNext())
					{
						if (parser.Current is MappingStart)
						{
							var olive = deserializer.Deserialize<Olive>(parser);
							if (olive != null)
							{
								boards.Add(olive.ToChessBoard());
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidDataException("Olive file import error", ex);
			}
			return boards;
		}

		public List<ChessBoard> FromPgn(string path)
		{
			// PGN files are typically text files that contain a number of chess games.
			// Chess game can be imported only if it contains FEN tag.
			// In this case we extract all FEN strings and create a ChessBoard for each.
			if (!File.Exists(path))
				throw new FileNotFoundException($"File not found: {path}");

			var boards = new List<ChessBoard>();

			try
			{
				using (var reader = new StreamReader(path))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						if (line.StartsWith("[FEN "))
						{
							var fen = line.Substring(5).TrimEnd(']');
							var board = ChessBoard.FromFen(fen);
							if (board != null)
							{
								boards.Add(board);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidDataException("PGN file import error", ex);
			}

			return boards;
		}
	}
}
