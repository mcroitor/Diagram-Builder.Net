using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DiagramBuilder.Net
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Text = "DiagramBuilder.Net";

			// menu
			menu = new MenuStrip();
			{
				ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("File");
				menu.Items.Add(fileMenuItem);
				var newFileMenuItem = new ToolStripMenuItem("New");
				newFileMenuItem.Click += NewFileMenuItem_Click;
				newFileMenuItem.ShortcutKeys = Keys.Control | Keys.N;
				fileMenuItem.DropDownItems.Add(newFileMenuItem);
				var openFileMenuItem = new ToolStripMenuItem("Open");
				openFileMenuItem.Click += OpenFileMenuItem_Click;
				openFileMenuItem.ShortcutKeys = Keys.Control | Keys.O;
				fileMenuItem.DropDownItems.Add(openFileMenuItem);
				var saveFileMenuItem = new ToolStripMenuItem("Save");
				saveFileMenuItem.Click += SaveFileMenuItem_Click;
				saveFileMenuItem.ShortcutKeys = Keys.Control | Keys.S;
				fileMenuItem.DropDownItems.Add(saveFileMenuItem);
				fileMenuItem.DropDownItems.Add("-");
				var exportFileMenuItem = new ToolStripMenuItem("Export");
				exportFileMenuItem.Click += ExportFileMenuItem_Click;
				exportFileMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
				fileMenuItem.DropDownItems.Add(exportFileMenuItem);
				var exportAllFileMenuItem = new ToolStripMenuItem("Export All");
				exportAllFileMenuItem.Click += ExportAllFileMenuItem_Click;
				exportAllFileMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
				fileMenuItem.DropDownItems.Add(exportAllFileMenuItem);
				fileMenuItem.DropDownItems.Add("-");
				var exitFileMenuItem = new ToolStripMenuItem("Exit");
				exitFileMenuItem.Click += ExitFileMenuItem_Click;
				exitFileMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
				fileMenuItem.DropDownItems.Add(exitFileMenuItem);
			}
			{
				ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
				var copyEditMenuItem = new ToolStripMenuItem("Copy");
				copyEditMenuItem.ShortcutKeys = Keys.Control | Keys.C;
				copyEditMenuItem.Click += CopyEditMenuItem_Click;
				editMenuItem.DropDownItems.Add(copyEditMenuItem);
				var pasteEditMenuItem = new ToolStripMenuItem("Paste");
				pasteEditMenuItem.ShortcutKeys = Keys.Control | Keys.V;
				pasteEditMenuItem.Click += PasteEditMenuItem_Click;
				editMenuItem.DropDownItems.Add(pasteEditMenuItem);
				editMenuItem.DropDownItems.Add("-");
				var addEditMenuItem = new ToolStripMenuItem("Add position");
				addEditMenuItem.Click += AddEditMenuItem_Click;
				addEditMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
				editMenuItem.DropDownItems.Add(addEditMenuItem);
				var removeEditMenuItem = new ToolStripMenuItem("Remove position");
				removeEditMenuItem.Click += RemoveEditMenuItem_Click;
				removeEditMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.R;
				editMenuItem.DropDownItems.Add(removeEditMenuItem);
				editMenuItem.DropDownItems.Add("-");
				var optionsEditMenuItem = new ToolStripMenuItem("Options");
				optionsEditMenuItem.Click += OptionsEditMenuItem_Click;
				editMenuItem.DropDownItems.Add(optionsEditMenuItem);
				menu.Items.Add(editMenuItem);
			}
			{
				ToolStripMenuItem helpMenuItem = new ToolStripMenuItem("Help");
				menu.Items.Add(helpMenuItem);
			}
						
			this.Controls.Add(menu);

			// set panel
			{
				this.panel = new System.Windows.Forms.Panel();

				this.panel.Location = new System.Drawing.Point(10, 30);
				this.panel.Width = 420;
				this.panel.Height = 84;
				this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

				// white pieces
				Button wk = new System.Windows.Forms.Button();
				wk.Location = new System.Drawing.Point(0, 0);
				wk.Width = this.fieldSize;
				wk.Height = this.fieldSize;
				wk.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wk.Padding = new System.Windows.Forms.Padding(0);
				wk.Text = fonts[this.selectedFont].GetPiece("K0");
				wk.Name = "K";
				wk.Click += PieceClicked;
				this.panel.Controls.Add(wk);

				Button wq = new System.Windows.Forms.Button();
				wq.Location = new System.Drawing.Point(this.fieldSize, 0);
				wq.Width = this.fieldSize;
				wq.Height = this.fieldSize;
				wq.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wq.Text = fonts[this.selectedFont].GetPiece("Q0");
				wq.Name = "Q";
				wq.Click += PieceClicked;
				this.panel.Controls.Add(wq);

				Button wr = new System.Windows.Forms.Button();
				wr.Location = new System.Drawing.Point(2 * this.fieldSize, 0);
				wr.Width = this.fieldSize;
				wr.Height = this.fieldSize;
				wr.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wr.Text = fonts[this.selectedFont].GetPiece("R0");
				wr.Name = "R";
				wr.Click += PieceClicked;
				this.panel.Controls.Add(wr);

				Button wb = new System.Windows.Forms.Button();
				wb.Location = new System.Drawing.Point(3 * this.fieldSize, 0);
				wb.Width = this.fieldSize;
				wb.Height = this.fieldSize;
				wb.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wb.Text = fonts[this.selectedFont].GetPiece("B0");
				wb.Name = "B";
				wb.Click += PieceClicked;
				this.panel.Controls.Add(wb);

				Button wn = new System.Windows.Forms.Button();
				wn.Location = new System.Drawing.Point(4 * this.fieldSize, 0);
				wn.Width = this.fieldSize;
				wn.Height = this.fieldSize;
				wn.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wn.Text = fonts[this.selectedFont].GetPiece("N0");
				wn.Name = "N";
				wn.Click += PieceClicked;
				this.panel.Controls.Add(wn);

				Button wp = new System.Windows.Forms.Button();
				wp.Location = new System.Drawing.Point(5 * this.fieldSize, 0);
				wp.Width = this.fieldSize;
				wp.Height = this.fieldSize;
				wp.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				wp.Text = fonts[this.selectedFont].GetPiece("P0");
				wp.Name = "P";
				wp.Click += PieceClicked;
				this.panel.Controls.Add(wp);

				// black pieces
				Button bk = new System.Windows.Forms.Button();
				bk.Location = new System.Drawing.Point(0, this.fieldSize);
				bk.Width = this.fieldSize;
				bk.Height = this.fieldSize;
				bk.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				bk.Text = fonts[this.selectedFont].GetPiece("k0");
				bk.Name = "k";
				bk.Click += PieceClicked;
				this.panel.Controls.Add(bk);

				Button bq = new System.Windows.Forms.Button();
				bq.Location = new System.Drawing.Point(this.fieldSize, this.fieldSize);
				bq.Width = this.fieldSize;
				bq.Height = this.fieldSize;
				bq.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				bq.Text = fonts[this.selectedFont].GetPiece("q0");
				bq.Name = "q";
				bq.Click += PieceClicked;
				this.panel.Controls.Add(bq);

				Button br = new System.Windows.Forms.Button();
				br.Location = new System.Drawing.Point(2 * this.fieldSize, this.fieldSize);
				br.Width = this.fieldSize;
				br.Height = this.fieldSize;
				br.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				br.Text = fonts[this.selectedFont].GetPiece("r0");
				br.Name = "r";
				br.Click += PieceClicked;
				this.panel.Controls.Add(br);

				Button bb = new System.Windows.Forms.Button();
				bb.Location = new System.Drawing.Point(3 * this.fieldSize, this.fieldSize);
				bb.Width = this.fieldSize;
				bb.Height = this.fieldSize;
				bb.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				bb.Text = fonts[this.selectedFont].GetPiece("b0");
				bb.Name = "b";
				bb.Click += PieceClicked;
				this.panel.Controls.Add(bb);

				Button bn = new System.Windows.Forms.Button();
				bn.Location = new System.Drawing.Point(4 * this.fieldSize, this.fieldSize);
				bn.Width = this.fieldSize;
				bn.Height = this.fieldSize;
				bn.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				bn.Text = fonts[this.selectedFont].GetPiece("n0");
				bn.Name = "n";
				bn.Click += PieceClicked;
				this.panel.Controls.Add(bn);

				Button bp = new System.Windows.Forms.Button();
				bp.Location = new System.Drawing.Point(5 * this.fieldSize, this.fieldSize);
				bp.Width = this.fieldSize;
				bp.Height = this.fieldSize;
				bp.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				bp.Text = fonts[this.selectedFont].GetPiece("p0");
				bp.Name = "p";
				bp.Click += PieceClicked;
				this.panel.Controls.Add(bp);

				// additional
				Button clear = new System.Windows.Forms.Button();
				clear.Location = new System.Drawing.Point(6 * this.fieldSize, 0);
				clear.Width = this.fieldSize;
				clear.Height = this.fieldSize;
				clear.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				clear.Text = fonts[this.selectedFont].GetPiece("LIGHT");
				clear.Name = " ";
				clear.Click += PieceClicked;
				this.panel.Controls.Add(clear);

				Button move = new System.Windows.Forms.Button();
				move.Location = new System.Drawing.Point(6 * this.fieldSize, this.fieldSize);
				move.Width = this.fieldSize;
				move.Height = this.fieldSize;
				move.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize - 8, GraphicsUnit.Pixel);
				move.Text = "";
				move.Image = Image.FromFile(".\\images\\arrow.png");
				move.Name = " ";
				move.Click += PieceMove;
				this.panel.Controls.Add(move);
			}

			this.boardView = new System.Windows.Forms.Label();
			this.boardView.Location = new System.Drawing.Point(10, 120);
			this.boardView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.boardView.Width = 420;
			this.boardView.Height = 400;
			this.boardView.Padding = new System.Windows.Forms.Padding(0);
			this.boardView.TextAlign = ContentAlignment.TopLeft;
			this.boardView.Font = new System.Drawing.Font(new FontFamily(this.selectedFont, chessFontsCollection), this.fieldSize, GraphicsUnit.Pixel);
			this.boardView.Text = this.positions[this.currentPosition].ToView(fonts[this.selectedFont]);
			this.boardView.MouseClick += SetPiece;

			this.fontSelect = new ComboBox();
			this.fontSelect.Items.AddRange(new string[] { "Chess Alpha", "Chess Berlin", "Chess Cases", "Chess Kingdom"});
			this.fontSelect.Location = new Point(10, 530);
			this.fontSelect.SelectedIndex = 0;
			this.fontSelect.Width = 200;
			this.fontSelect.SelectedIndexChanged += FontSelect_SelectedIndexChanged;
			this.Controls.Add(this.fontSelect);

			this.fontSize = new ComboBox();
			this.fontSize.Items.AddRange(new string[] { "20", "30", "40", "50", "60", "70", "80", "90" });
			this.fontSize.Location = new Point(220, 530);
			this.fontSize.SelectedIndex = 0;
			this.fontSize.Width = 200;
			this.fontSize.SelectedIndexChanged += FontSize_SelectedIndexChanged;
			this.Controls.Add(this.fontSize);

			// fen list panel
			this.fensList = new ListView();
			this.fensList.Location = new Point(440, 30);
			this.fensList.View = View.Details;
			this.fensList.GridLines = true;
			this.fensList.FullRowSelect = true;
			this.fensList.Width = 360;
			this.fensList.Height = 580;
			this.fensList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
			this.AutoScroll = true;
			this.AutoSizeMode = AutoSizeMode.GrowOnly;
			this.fensList.Enabled = true;
			this.fensList.BorderStyle = BorderStyle.FixedSingle;
			this.fensList.Columns.Add("positions");
			this.fensList.Columns[0].Width = 300;
			this.fensList.MultiSelect = false;
			this.fensList.SelectedIndexChanged += FensListSelectIndex;

			this.Controls.Add(this.boardView);
			this.Controls.Add(this.panel);
			//this.Controls.Add(this.fen);
			this.Controls.Add(this.fensList);
			this.UpdateView();
		}

		private void PieceMove(object sender, EventArgs e)
		{
			this.MovePiece = true;
			foreach (Button btn in this.panel.Controls)
			{
				btn.BackColor = default(Color);
			}
			((Button)sender).BackColor = Color.Coral;
		}

		private void FontSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.selectedFont = ((ComboBox)(sender)).SelectedItem.ToString();
			this.boardView.Font = new System.Drawing.Font(new FontFamily(this.selectedFont), this.fieldSize, GraphicsUnit.Pixel);
			this.UpdateView();
		}

		private void FontSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.selectedSize = Int32.Parse(((ComboBox)(sender)).SelectedItem.ToString());
		}

		private void PasteEditMenuItem_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsText()) {
				this.positions[currentPosition].SetBoard(Clipboard.GetText());

			}
			//MessageBox.Show("not implemented yet");
		}

		private void CopyEditMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.positions[currentPosition].ToFen());
			//MessageBox.Show("not implemented yet");
		}

		private void RemoveEditMenuItem_Click(object sender, EventArgs e)
		{
			this.positions.RemoveAt(currentPosition);
			if(this.positions.Count == 0)
			{
				this.positions.Add(ChessBoard.Empty());
			}
			if (this.currentPosition >= this.positions.Count) { 
				--this.currentPosition;
			}
			
			this.UpdateView();
		}

		private void AddEditMenuItem_Click(object sender, EventArgs e)
		{
			this.positions.Add(ChessBoard.Empty());
			++this.currentPosition;
			this.UpdateView();
		}

		private void OptionsEditMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("not implemented yet");
		}

		private void ExportAllFileMenuItem_Click(object sender, EventArgs e)
		{
			string format = new string('0', this.NrOfDigits(positions.Count));
			var aFont = new Font(new FontFamily(this.selectedFont), this.selectedSize, GraphicsUnit.Pixel);

			for (int i = 0; i < positions.Count; ++i)
			{
				Bitmap diagram = new Bitmap((int)(10.5 * this.selectedSize), (int)(10 * this.selectedSize), PixelFormat.Format24bppRgb);
				diagram.SetResolution(this.dpi, this.dpi);

				Graphics g = Graphics.FromImage(diagram);
				g.FillRectangle(Brushes.White, 0, 0, diagram.Width, diagram.Height);
				g.DrawString(this.positions[i].ToView(fonts[this.selectedFont]), aFont, Brushes.Black, 0, 0);
				diagram.Save(this.outputDir + "diagram" + (i+1).ToString(format) + ".png", ImageFormat.Png);
			}
			
			MessageBox.Show("Export done");
		}

		private void ExportFileMenuItem_Click(object sender, EventArgs e)
		{
			var aFont = new Font(new FontFamily(this.selectedFont), this.selectedSize, GraphicsUnit.Pixel);

			Bitmap diagram = new Bitmap((int)(10.5 * this.selectedSize), (int)(10 * this.selectedSize), PixelFormat.Format24bppRgb);
			diagram.SetResolution(this.dpi, this.dpi);

			Graphics g = Graphics.FromImage(diagram);
			g.FillRectangle(Brushes.White, 0, 0, diagram.Width, diagram.Height);
			g.DrawString(this.positions[this.currentPosition].ToView(this.fonts[this.selectedFont]), aFont, Brushes.Black, 0, 0);
			diagram.Save(this.outputDir + "diagram.png", ImageFormat.Png);
			MessageBox.Show("Export done");
		}

		private void FensListSelectIndex(object sender, EventArgs e)
		{
			if(((ListView)sender).SelectedIndices.Count == 0 || this.currentPosition == ((ListView)sender).SelectedIndices[0])
			{
				return;
			}
			this.currentPosition = ((ListView)sender).SelectedIndices[0];
			this.UpdateView();
		}

		private void ExitFileMenuItem_Click(object sender, EventArgs e)
		{
			SavePositions();
			Application.Exit();
		}

		private void SavePositions()
		{
			if (this.fileName == "")
			{
				return;
			}
			StreamWriter writer = new StreamWriter(fileName);
			foreach (ChessBoard board in this.positions)
			{
				writer.Write(board.ToFen() + "\n");
			}
			writer.Close();
		}

		private void SaveFileMenuItem_Click(object sender, EventArgs e)
		{
			// Open SaveFileDialog
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "epd|*.epd|fen|*.fen|All files|*.*";
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileName = saveFileDialog.FileName;
			}
			SavePositions();
		}

		private void OpenFileMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "epd|*.epd|fen|*.fen|All files|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.fileName = openFileDialog.FileName;
				this.positions.Clear();
				this.currentPosition = 0;
				StreamReader reader = new StreamReader(this.fileName);
				while(reader.EndOfStream == false)
				{
					string line = reader.ReadLine();
					ChessBoard board = ChessBoard.Empty();
					board.SetBoard(line);
					this.positions.Add(board);
				}
				this.UpdateView();
			}
		}

		private void UpdateView()
		{
			this.boardView.Text = this.positions[this.currentPosition].ToView(this.fonts[this.selectedFont]);
			this.fensList.Items.Clear();
			for (int i = 0; i < this.positions.Count; ++i)
			{
				this.fensList.Items.Add(this.positions[i].ToFen());
			}
			this.fensList.Items[this.currentPosition].Selected = true;
			this.fensList.Select();
		}

		private void NewFileMenuItem_Click(object sender, EventArgs e)
		{
			this.fileName = "";
			this.positions.Clear();
			this.positions.Add(ChessBoard.Empty());
			this.currentPosition = 0;
		}

		private void PieceClicked(object sender, EventArgs e)
		{
			this.MovePiece = false;
			this.currentPiece = ((System.Windows.Forms.Button)(sender)).Name;
			foreach(Button btn in this.panel.Controls)
			{
				btn.BackColor = default(Color);
			}
			((Button)sender).BackColor = Color.Coral;
		}

		private void SetPiece(Object sender, MouseEventArgs args)
		{
			int col = 9 - args.X / this.fieldSize - 1;
			int row = args.Y / this.fieldSize - 1;
			if (row > 7 || row < 0 || col > 7 || col < 0) return;
			if(this.MovePiece == true)
			{
				// select
				if(this.colMovedPiece == -1)
				{
					this.colMovedPiece = col;
					this.rowMovedPiece = row;
				}
				//release
				else
				{
					currentPiece = this.positions[this.currentPosition].GetPiece(this.rowMovedPiece, this.colMovedPiece);
					this.positions[this.currentPosition].SetField(this.rowMovedPiece, this.colMovedPiece, " ");
					this.positions[this.currentPosition].SetField(row, col, currentPiece);
					this.MovePiece = false;
				}
			}
			else
			{
				if (this.currentPiece != "")
				{
					this.positions[this.currentPosition].SetField(row, col, currentPiece);
				}
			}
			this.UpdateView();
		}
		#endregion
	}
}

