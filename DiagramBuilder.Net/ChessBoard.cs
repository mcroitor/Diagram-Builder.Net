using System;
using System.Collections.Generic;
using System.Text;

namespace DiagramBuilder.Net
{
	public class ChessBoard
	{
		private static string[,] EMPTY_BOARD =
		{
		//	  A    B    C    D    E    F    G    H
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 1 <-- row
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 2
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 3
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 4
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 5
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 6
			{" ", " ", " ", " ", " ", " ", " ", " " }, // 7
			{" ", " ", " ", " ", " ", " ", " ", " " }  // 8
		};
		private static string[,] INIT_BOARD =
		{
			{"R", "N", "B", "Q", "K", "B", "N", "R" },
			{"P", "P", "P", "P", "P", "P", "P", "P" },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{" ", " ", " ", " ", " ", " ", " ", " " },
			{"p", "p", "p", "p", "p", "p", "p", "p" },
			{"r", "n", "b", "q", "k", "b", "n", "r" }
		};

		private string[,] brd;
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
			for (int row = 7; row >= 0; --row)
			{
				int countEmpty = 0;
				for (int column = 0; column < 8; ++column)
				{
					if (brd[row, column] == " ")
					{
						++countEmpty;
					}
					else
					{
						if (countEmpty > 0)
						{
							fen += countEmpty.ToString();
						}
						fen += brd[row, column];
					}
				}
				if (countEmpty != 0)
				{
					fen += countEmpty.ToString();
				}
				if (row != 0)
				{
					fen += "/";
				}
			}

			return fen;
		}

		public string ToView(ChessFonts.ChessFont font)
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
		public string[] GetRows(ChessFonts.ChessFont font)
		{
			string[] view = new string[8];
			for (int row = 0; row < 8; ++row)
			{
				for (int column = 7; column >= 0; --column)
				{
					if (brd[column, row] == " ")
					{
						view[row] += font.GetPiece((column + row) % 2 == 1 ? "LIGHT" : "DARK");
					}
					else
					{
						view[row] += font.GetPiece(brd[column, row] + (column + row + 1) % 2);
					}
				}
			}
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
	}
}
