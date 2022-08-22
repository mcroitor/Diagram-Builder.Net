namespace Chess
{
	public class ChessBoard
	{
		public class Piece
		{
			public static string NoPiece = " ";
			public static string WhiteKing = "K";
			public static string WhiteQueen = "Q";
			public static string WhiteRook = "R";
			public static string WhiteBishop = "B";
			public static string WhiteKnight = "N";
			public static string WhitePawn = "P";

			public static string BlackKing = "k";
			public static string BlackQueen = "q";
			public static string BlackRook = "r";
			public static string BlackBishop = "b";
			public static string BlackKnight = "n";
			public static string BlackPawn = "p";
		}
		private static string[,] EMPTY_BOARD =
		{
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " }
		};
		private static string[,] INIT_BOARD =
		{
			{"r", "p", " ", " ", " ", " ", "P", "R" },
			{"n", "p", " ", " ", " ", " ", "P", "N" },
			{"b", "p", " ", " ", " ", " ", "P", "B" },
			{"k", "p", " ", " ", " ", " ", "P", "K" },
			{"q", "p", " ", " ", " ", " ", "P", "Q" },
			{"b", "p", " ", " ", " ", " ", "P", "B" },
			{"n", "p", " ", " ", " ", " ", "P", "N" },
			{"r", "p", " ", " ", " ", " ", "P", "R" }
		};

		private string[,] brd;
		public string comment { get; set; }
		public ChessBoard()
		{
			brd = new string[8, 8];
			for (int i = 0; i < 8; ++i)
			{
				for (int j = 0; j < 8; ++j)
				{
					brd[i, j] = " ";
				}
			}
			comment = "";
		}

		public static ChessBoard Empty()
		{
			ChessBoard board = new ChessBoard();
			for (int column = 0; column < 8; ++column)
			{
				for (int row = 0; row < 8; ++row)
				{
					board.SetField(column, row, ChessBoard.EMPTY_BOARD[row, column]);
				}
			}
			return board;
		}
		public static ChessBoard Initial()
		{
			ChessBoard board = new ChessBoard();
			for (int column = 0; column < 8; ++column)
			{
				for (int row = 0; row < 8; ++row)
				{
					board.SetField(column, row, ChessBoard.INIT_BOARD[row, column]);
				}
			}
			return board;
		}

		public string ToFen()
		{
			string fen = "";
			for (int row = 0; row < 8; ++row)
			{
				int countEmpty = 0;
				for (int column = 7; column >= 0; --column)
				{
					if (brd[column, row] == " ")
					{
						++countEmpty;
					}
					else
					{
						if (countEmpty > 0)
						{
							fen += countEmpty.ToString();
						}
						fen += brd[column, row];
						countEmpty = 0;
					}
				}
				if (countEmpty != 0)
				{
					fen += countEmpty.ToString();
				}
				if (row != 7)
				{
					fen += "/";
				}
			}

			return fen;
		}

		public string ToView(ChessFont font)
		{
			string view = font.GetPiece("TOP") + "\n";
			for (int row = 0; row < 8; ++row)
			{
				view += font.GetPiece("LEFT");
				for (int column = 7; column >= 0; --column)
				{
					if (brd[column, row] == " ")
					{
						view += font.GetPiece((column + row) % 2 == 1 ? "LIGHT" : "DARK");
					}
					else
					{
						view += font.GetPiece(brd[column, row] + (column + row + 1) % 2);
					}
				}
				view += font.GetPiece("RIGHT") + "\n";
			}
			view += font.GetPiece("BOTTOM");
			return view;
		}

		public void SetField(int column, int row, string piece)
		{
			brd[row, column] = piece;
		}
		public void SetBoard(string fen)
		{
			int countFields = 0;
			for (int i = 0; i < 8; ++i)
			{
				for (int j = 0; j < 8; ++j)
				{
					brd[i, j] = " ";
				}
			}
			foreach (char chr in fen)
			{
				switch (chr)
				{
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
						countFields += (chr - '0');
						break;
					case '/':
						break;
					default:
						int column = countFields / 8;
						int row = countFields % 8;
						brd[7 - row, column] = chr.ToString();
						++countFields;
						break;
				}
				if (countFields > 63)
				{
					return;
				}
			}
		}

		public string GetPiece(int colMovedPiece, int rowMovedPiece)
		{
			return brd[rowMovedPiece, colMovedPiece];
		}

	}
}
