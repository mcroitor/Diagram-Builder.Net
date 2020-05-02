using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
		PrivateFontCollection chessFontsCollection;
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
		string outputDir = ".\\output\\";
		string fontsDir = ".\\fonts\\";
		// image properties
		int dpi = 300;
		
		public Form1()
		{
			currentPosition = 0;
			selectedFont = "Chess Alpha";
			positions = new List<ChessBoard>();
			this.positions.Add(ChessBoard.Empty());
			this.fileName = "";
			if(System.IO.Directory.Exists(this.outputDir) == false)
			{
				System.IO.Directory.CreateDirectory(this.outputDir);
			}
			InitializeFonts();
			InitializeComponent();
		}

		private void InitializeFonts()
		{
			chessFontsCollection = new PrivateFontCollection();
			string[] fontFiles = System.IO.Directory.GetFiles(this.fontsDir, "*.ttf");
			foreach(var fontFile in fontFiles) {
				chessFontsCollection.AddFontFile(fontFile);
			}
		}

		private int NrOfDigits(int number)
		{
			int result = 1;
			while(number > 9)
			{
				++result;
				number /= 10;
			}
			return result;
		}
	}
}
