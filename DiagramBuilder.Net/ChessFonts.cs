using System;
using System.Collections.Generic;
using System.Text;

namespace DiagramBuilder.Net
{
	public class ChessFonts
	{
		public class ChessFont
		{
			private string Name;
			private Dictionary<string, string> Piece;

			public ChessFont( string n,  Dictionary<string, string> desc)
			{
				this.Name = n;
				this.Piece = desc;
			}
			public string GetName() { return this.Name; }
			public string GetPiece(string ID)
			{
				return this.Piece[ID];
			}
		};

		public static ChessFont Alpha = new ChessFont("Chess Alpha 2", new Dictionary<string, string>
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

		public static ChessFont Berlin = new ChessFont("Chess Berlin", new Dictionary<string, string>
			{
				{"TOP", "1222222223" },
				{"LEFT", "4" },
				{"RIGHT", "5" },
				{"BOTTOM", "7888888889" },
				{"LIGHT", " " },
				{"DARK", "+" },
				{"K0", "k"},
				{"Q0", "q"},
				{"R0", "r"},
				{"B0", "b"},
				{"N0", "h"},
				{"P0", "p"},

				{"K1", "K"},
				{"Q1", "Q"},
				{"R1", "R"},
				{"B1", "B"},
				{"N1", "H"},
				{"P1", "P"},

				{"k0", "l"},
				{"q0", "w"},
				{"r0", "t"},
				{"b0", "n"},
				{"n0", "j"},
				{"p0", "o"},

				{"k1", "L"},
				{"q1", "W"},
				{"r1", "T"},
				{"b1", "N"},
				{"n1", "J"},
				{"p1", "O"}
			});

		public static ChessFont Cases = new ChessFont("Chess Cases", new Dictionary<string, string>
			{
				{"TOP", "A\"\"\"\"\"\"\"\"S" },
				{"LEFT", "$" },
				{"RIGHT", "%" },
				{"BOTTOM", "D((((((((F" },
				{"LIGHT", " " },
				{"DARK", "+" },
				{"K0", "k"},
				{"Q0", "q"},
				{"R0", "r"},
				{"B0", "b"},
				{"N0", "n"},
				{"P0", "p"},

				{"K1", "K"},
				{"Q1", "Q"},
				{"R1", "R"},
				{"B1", "B"},
				{"N1", "N"},
				{"P1", "P"},

				{"k0", "l"},
				{"q0", "w"},
				{"r0", "t"},
				{"b0", "v"},
				{"n0", "m"},
				{"p0", "o"},

				{"k1", "L"},
				{"q1", "W"},
				{"r1", "T"},
				{"b1", "V"},
				{"n1", "M"},
				{"p1", "O"}
			});

		public static ChessFont Kingdom = new ChessFont("Chess Kingdom", new Dictionary<string, string>
			{
				{"TOP", "A\"\"\"\"\"\"\"\"S" },
				{"LEFT", "$" },
				{"RIGHT", "%" },
				{"BOTTOM", "D((((((((F" },
				{"LIGHT", " " },
				{"DARK", "+" },
				{"K0", "k"},
				{"Q0", "q"},
				{"R0", "r"},
				{"B0", "b"},
				{"N0", "n"},
				{"P0", "p"},

				{"K1", "K"},
				{"Q1", "Q"},
				{"R1", "R"},
				{"B1", "B"},
				{"N1", "N"},
				{"P1", "P"},

				{"k0", "l"},
				{"q0", "w"},
				{"r0", "t"},
				{"b0", "v"},
				{"n0", "m"},
				{"p0", "o"},

				{"k1", "L"},
				{"q1", "W"},
				{"r1", "T"},
				{"b1", "V"},
				{"n1", "M"},
				{"p1", "O"}
			});

		public static ChessFont Merida = new ChessFont("Chess Merida", new Dictionary<string, string>
			{
				{"TOP", "A\"\"\"\"\"\"\"\"S" },
				{"LEFT", "$" },
				{"RIGHT", "%" },
				{"BOTTOM", "D((((((((F" },
				{"LIGHT", " " },
				{"DARK", "+" },
				{"K0", "k"},
				{"Q0", "q"},
				{"R0", "r"},
				{"B0", "b"},
				{"N0", "n"},
				{"P0", "p"},

				{"K1", "K"},
				{"Q1", "Q"},
				{"R1", "R"},
				{"B1", "B"},
				{"N1", "N"},
				{"P1", "P"},

				{"k0", "l"},
				{"q0", "w"},
				{"r0", "t"},
				{"b0", "v"},
				{"n0", "m"},
				{"p0", "o"},

				{"k1", "L"},
				{"q1", "W"},
				{"r1", "T"},
				{"b1", "V"},
				{"n1", "M"},
				{"p1", "O"}
			});
	}
}
