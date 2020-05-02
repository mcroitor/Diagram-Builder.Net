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

		public static ChessFont ChessAlpha = new ChessFont("Chess Alpha", new Dictionary<string, string>
			{
				{"TOP", "1222222223" },
				{"LEFT", "4" },
				{"RIGHT", "5" },
				{"BOTTOM", "6777777778" },
				{"LIGHT", "-" },
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

		public static ChessFont ChessBerlin = new ChessFont("Chess Berlin", new Dictionary<string, string>
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

		public static ChessFont ChessCases = new ChessFont("Chess Cases", new Dictionary<string, string>
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

		public static ChessFont ChessKingdom = new ChessFont("Chess Kingdom", new Dictionary<string, string>
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
