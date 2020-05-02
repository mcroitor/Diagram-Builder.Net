using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagramBuilder.Net
{
	public partial class Form1 : Form
	{
		// UI
		MenuStrip menu;
		ListView fensList;
		Label boardView;
		ComboBox fontSelect;
		ComboBox fontSize;
		Panel panel;

		// structures
		Dictionary<string, ChessFonts.ChessFont> fonts = new Dictionary<string, ChessFonts.ChessFont>
		{
			{ "Chess Alpha", ChessFonts.ChessAlpha},
			{"Chess Berlin", ChessFonts.ChessBerlin}, 
			{"Chess Cases", ChessFonts.ChessCases}, 
			{"Chess Kingdom", ChessFonts.ChessKingdom} 
		};
		string selectedFont;
		int selectedSize = 40;
		int fieldSize = 40;
		List<ChessBoard> positions;
		int currentPosition;
		string fileName;
		string currentPiece = "";
		// image properties
		int dpi = 300;
		
		public Form1()
		{
			currentPosition = 0;
			selectedFont = "Chess Alpha";
			positions = new List<ChessBoard>();
			this.positions.Add(ChessBoard.Empty());
			this.fileName = "";
			InitializeComponent();
		}

		//conversion pixel -> millimeter at 72 dpi
		private double px2mm(double px)
		{
			return px * 25.4 / this.dpi;
		}

		//conversion millimeter at 72 dpi -> pixel
		private double mm2px(double mm)
		{
			return mm * this.dpi / 25.4;
		}

		//conversion pixel -> point
		private double px2pt(double px)
		{
			return px * 3 / 4;
		}

		//conversion point -> pixel
		private double pt2px(double pt)
		{
			return pt * 4 / 3;
		}
	}
}
