using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Windows.Forms;
using Chess;

namespace DiagramBuilder.Net
{
	public partial class Form1 : Form
	{
		// UI
		private ListView fensList;
		private Label boardView;
		private ComboBox fontSelect;
		private NumericUpDown fontSize;
		private Panel panel;
		private ToolStripMenuItem recentFileMenuItem;

		// structures
		PrivateFontCollection chessFontsCollection;
		private Dictionary<string, ChessFont> fonts = new Dictionary<string, ChessFont>
		{
			{"Chess Alpha 2", new ChessFont("fonts\\mapping\\alpha2.map")},
			{"Chess Berlin", new ChessFont("fonts\\mapping\\berlin.map")},
			{"Chess Cases", new ChessFont("fonts\\mapping\\cases.map")},
			{"Chess Condal", new ChessFont("fonts\\mapping\\condal.map")},
			{"Chess Kingdom", new ChessFont("fonts\\mapping\\kingdom.map")},
			{"Chess Leipzig", new ChessFont("fonts\\mapping\\leipzig.map")},
			{"Chess Merida", new ChessFont("fonts\\mapping\\merida.map")}
		};
		int fieldSize = 40;
		List<ChessBoard> positions;
		int currentPosition;
		string fileName;
		string currentPiece = "";
		string fontsDir = ".\\fonts\\";
		bool MovePiece = false;
		int colMovedPiece = -1;
		int rowMovedPiece = -1;
		string recentFiles = ".\\recent.ini";
		// image properties
		int dpi = 300;

		//configurable options
		string selectedFont;
		int selectedSize = 40;
		string outputDir = ".\\output\\";
		string workDir;
		bool alwaysOnTop = false;

		public Form1()
		{
			currentPosition = 0;
			// selectedFont = "Chess Alpha 2";
			selectedFont = ConfigurationManager.AppSettings["DefaultFont"] ?? "Chess Alpha 2";
			if(ConfigurationManager.AppSettings["DefaultSize"] != null)
			{
				selectedSize = int.Parse(ConfigurationManager.AppSettings["DefaultSize"]);
			}
			outputDir = ConfigurationManager.AppSettings["OutputDir"] ?? ".\\output\\";
			workDir = ConfigurationManager.AppSettings["WorkDir"] ?? ".\\fens\\";
			if (ConfigurationManager.AppSettings["OnTop"] != null)
			{
				alwaysOnTop = bool.Parse(ConfigurationManager.AppSettings["OnTop"]);
			}

			positions = new List<ChessBoard>();
			this.positions.Add(ChessBoard.Empty());
			this.fileName = "";
			if (!System.IO.File.Exists(this.recentFiles))
			{
				System.IO.File.Create(this.recentFiles);
			}

			CheckIntegrity();
			InitializeFonts();
			InitializeComponent();
			this.TopMost = alwaysOnTop;
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
