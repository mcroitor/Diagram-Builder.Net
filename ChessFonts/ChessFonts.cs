using System.Collections.Generic;
using System.IO;

namespace Chess
{
	public class ChessFont
	{
		private string Name;
		private string FontID;
		private Dictionary<string, string> Piece;

		public ChessFont(string n, Dictionary<string, string> desc)
		{
			this.Name = n;
			this.Piece = desc;
		}
		public ChessFont(string filename)
		{
			using (StreamReader reader = new StreamReader(filename))
			{
				string line;
				Piece = new Dictionary<string, string>();
				while ((line = reader.ReadLine()) != null)
				{
					line = line.Trim();
					string[] parts = line.Split(new char[] { '=' });
					if (parts.Length == 2)
					{
						var key = parts[0].Trim();
						var value = parts[1].Trim();
						Piece.Add(key, value);
						//fix space
						if(value.Length == 0)
						{
							Piece[key] = " ";
						}
						//fix char code
						int code;
						if (int.TryParse(value, out code) && code < 256)
						{
							Piece[key] = "" + (char)code;
						}
						//extract name
						if ("NAME".Equals(key))
						{
							Name = value;
						}
						// extract ID
						if ("ID".Equals(key))
						{
							this.FontID = value;
						}
					}
				}
			}
		}
		public string GetName() { return this.Name; }
		public string GetPiece(string ID)
		{
			return this.Piece[ID];
		}

		public string GetID() { return this.FontID; }

		public static ChessFont Alpha()
		{
			return new ChessFont("Chess Alpha 2", new Dictionary<string, string>
			{
				{"TOP", "[<<<<<<<<]" },
				{"LEFT", "|" },
				{"RIGHT", "\\" },
				{"BOTTOM", "{yyyyyyyy}" },
				{"LIGHT", "'" },
				{"DARK", "#" },
				{"K0", "" + (char)200},
				{"Q0", "" + (char)198},
				{"R0", "" + (char)196},
				{"B0", "" + (char)192},
				{"N0", "" + (char)194},
				{"P0", "" + (char)202},

				{"K1", "" + (char)201},
				{"Q1", "" + (char)199},
				{"R1", "" + (char)197},
				{"B1", "" + (char)193},
				{"N1", "" + (char)195},
				{"P1", "" + (char)203},

				{"k0", "" + (char)232},
				{"q0", "" + (char)230},
				{"r0", "" + (char)228},
				{"b0", "" + (char)224},
				{"n0", "" + (char)226},
				{"p0", "" + (char)234},

				{"k1", "" + (char)233},
				{"q1", "" + (char)231},
				{"r1", "" + (char)229},
				{"b1", "" + (char)225},
				{"n1", "" + (char)227},
				{"p1", "" + (char)235}
			});
		}
	};
}
