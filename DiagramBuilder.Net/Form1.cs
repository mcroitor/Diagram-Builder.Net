using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;

namespace DiagramBuilder.Net
{
	public partial class Form1 : Form
	{
		// UI
		private ListView fensList;
		private Label boardView;
		private ComboBox fontSelect;
		private ComboBox fontSize;
		private Panel panel;

		// structures
		PrivateFontCollection chessFontsCollection;
		private Dictionary<string, ChessFonts.ChessFont> fonts = new Dictionary<string, ChessFonts.ChessFont>
		{
			{"Chess Alpha 2", ChessFonts.Alpha},
			{"Chess Berlin", ChessFonts.Berlin}, 
			{"Chess Cases", ChessFonts.Cases}, 
			{"Chess Kingdom", ChessFonts.Kingdom},
			{"Chess Merida", ChessFonts.Merida}
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
		bool MovePiece = false;
		int colMovedPiece = -1;
		int rowMovedPiece = -1;
		// image properties
		int dpi = 300;
		
		public Form1()
		{
			currentPosition = 0;
			selectedFont = "Chess Alpha 2";
			positions = new List<ChessBoard>();
			this.positions.Add(ChessBoard.Empty());
			this.fileName = "";

			CheckIntegrity();
			InitializeFonts();
			InitializeComponent();
		}

		private void CheckIntegrity()
		{
			if (System.IO.Directory.Exists(this.outputDir) == false)
			{
				System.IO.Directory.CreateDirectory(this.outputDir);
			}
			if (System.IO.Directory.Exists(this.fontsDir) == false)
			{
				System.IO.Directory.CreateDirectory(this.fontsDir);
			}
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
