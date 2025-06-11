using System;
using System.Collections.Generic;
// Add reference to System.Configuration in your project if not already present
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
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
		PrivateFontCollection chessFontsCollection = new PrivateFontCollection();
		private Dictionary<string, ChessFont> fonts = new Dictionary<string, ChessFont>();
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
		bool cropImage = false;
		string outputDir = ".\\output\\";
		string workDir;
		bool alwaysOnTop = false;

		public Form1()
		{
			currentPosition = 0;
			LoadFonts();
			var e = this.fonts.GetEnumerator();
			e.MoveNext();
			try
			{
				selectedFont = ConfigurationManager.AppSettings["DefaultFont"] ??
	this.fonts.Values.FirstOrDefault()?.GetID();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading default font: {ex.Message}");
				selectedFont = e.Current.Value.GetID(); // Fallback to first font
			}
			if (ConfigurationManager.AppSettings["DefaultSize"] != null)
			{
				selectedSize = int.Parse(ConfigurationManager.AppSettings["DefaultSize"]);
			}
			outputDir = ConfigurationManager.AppSettings["OutputDir"] ?? ".\\output\\";
			workDir = ConfigurationManager.AppSettings["WorkDir"] ?? ".\\fens\\";

			if (ConfigurationManager.AppSettings["CropImage"] != null)
			{
				this.cropImage = bool.Parse(ConfigurationManager.AppSettings["CropImage"]);
			}
			if (ConfigurationManager.AppSettings["OnTop"] != null)
			{
				alwaysOnTop = bool.Parse(ConfigurationManager.AppSettings["OnTop"]);
			}

			positions = new List<ChessBoard>();
			this.positions.Add(ChessBoard.Empty());
			this.fileName = "";

			var recent = RecentFiles();
			if (recent.Count > 0)
			{
				load(recent[0]);
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
			if (System.IO.File.Exists(this.recentFiles) == false)
			{
				using (System.IO.File.Create(this.recentFiles)) { }
			}

		}

		public void LoadFonts()
		{
			var mapping = this.fontsDir + "\\mapping";
			var mapped_fonts = System.IO.Directory.GetFiles(mapping, "*.map");
			foreach (var item in mapped_fonts)
			{
				var chess_font = new ChessFont(item);
				var id = chess_font.GetID();
				if (!this.fonts.ContainsKey(id))
				{
					this.fonts.Add(id, chess_font);
				}
				else
				{
					Console.WriteLine($"Warning: Font {id} already exists in the collection.");
				}
			}
		}

		private void InitializeFonts()
		{
			chessFontsCollection = new PrivateFontCollection();
			string[] fontFiles = System.IO.Directory.GetFiles(this.fontsDir, "*.ttf");
			foreach (var fontFile in fontFiles)
			{
				chessFontsCollection.AddFontFile(fontFile);
			}
		}

		private int NrOfDigits(int number)
		{
			int result = 1;
			while (number > 9)
			{
				++result;
				number /= 10;
			}
			return result;
		}
	}
}
