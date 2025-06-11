using Chess;

namespace DiagramBuilder.Net
{
	internal class Algebraic
	{
		public string[] white { get; set; }
		public string[] black { get; set; }
	}
	internal class Olive
	{
		public Algebraic algebraic { get; set; }
		public string authors { get; set; }
		public string comments { get; set; }
		public string date { get; set; }
		public string distinction { get; set; }
		public string[] keywords { get; set; }
		public string[] options { get; set; }
		public string solution { get; set; }
		public object source { get; set; }
		public string stipulation { get; set; }
		public ChessBoard ToChessBoard()
		{
			ChessBoard board = new ChessBoard();
			// 1. set board properties
			// 2. return board
			foreach (var item in algebraic.white)
			{
				// fix knight problem
				var piece = item.Replace("S", "N");
				board.SetField(piece[1] - 'a', piece[2] - '1', piece[0].ToString().ToUpper());
			}
			foreach (var item in algebraic.black)
			{
				// fix knight problem
				var piece = item.Replace("S", "N");
				board.SetField(piece[1] - 'a', piece[2] - '1', piece[0].ToString().ToLower());
			}
			board.comment = stipulation;
			return board;
		}
	}

}
