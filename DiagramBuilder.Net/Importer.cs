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
			// Import data from Olive file
			// Olive file is a simple YAML file
			List<Olive> positions = new List<Olive>();

			// 1. open YAML file
			using (StreamReader reader = new StreamReader(path))
			{
				var deserializer = new Deserializer();
				var parser = new Parser(reader);
				while (parser.MoveNext())
				{
					if (parser.Current is MappingStart)
					{
						positions.Add(deserializer.Deserialize<Olive>(parser));
					}
				}
			}
			// 3. create list of ChessBoard objects
			List<ChessBoard> boards = new List<ChessBoard>();
			foreach (Olive olive in positions)
			{
				boards.Add(olive.ToChessBoard());
			}
			// 4. return list
			return boards;
		}
	}
}
