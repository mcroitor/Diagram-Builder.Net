using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Chess;

namespace fen2img
{
	class Program
	{
		static void Info()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine("\tfen2img --inputfen=<fen> [--size=<field size>] [--output=<filename>] ");
			Console.WriteLine("\tfen2img --inputfile=<fenfile> [--size=<field size>] [--folder=<foldername>]");
		}

		static Bitmap Fen2Image(ChessBoard board, ChessFont font, int size)
		{
			Bitmap diagram = new Bitmap((int)(10.5 * size), (int)(10 * size), PixelFormat.Format24bppRgb);
			Font aFont = new Font(new FontFamily(font.GetName()), size, GraphicsUnit.Pixel);
			diagram.SetResolution(300, 300);

			Graphics g = Graphics.FromImage(diagram);
			g.FillRectangle(Brushes.White, 0, 0, diagram.Width, diagram.Height);
			g.DrawString(board.ToView(font), aFont, Brushes.Black, 0, 0);
			return diagram;
		}

		static Dictionary<string, string> keys = new Dictionary<string, string>
		{
			{ "folder", ".\\"},
			{ "font", "alpha2"},
			{ "inputfile", "" },
			{ "inputfen", "" },
			{ "output", "diagram" },
			{ "size", "50" }
		};
		static void Main(string[] args)
		{
			if(args.Length == 0)
			{
				Info();
				return;
			}
			foreach(var keypair in args)
			{
				var tmp = keypair.Split('=');
				var key = tmp[0].Trim().TrimStart('-');
				var value = tmp[1].Trim();
				if (keys.ContainsKey(key))
				{
					keys[key] = value;
				}
			}
			// input fen set
			if(keys["inputfen"] != "") {
				ChessBoard board = new ChessBoard();
				board.SetBoard(keys["inputfen"]);
				ChessFont font = new ChessFont("fontdefinitions\\" + keys["font"] + ".cfg");
				Bitmap bitmap = Fen2Image(board, font, int.Parse(keys["size"]));
				bitmap.Save(keys["output"] + ".png", ImageFormat.Png);
			}
			// input file set
			else if(keys["inputfile"] != "")
			{
				using (StreamReader reader = new StreamReader(keys["inputfile"]))
				{
					string fen;
					int count = 0;
					while ((fen = reader.ReadLine()) != null)
					{
						if (fen.Trim().Length > 0)
						{
							++count;
							ChessBoard board = new ChessBoard();
							board.SetBoard(fen);
							ChessFont font = new ChessFont("fonts\\" + keys["font"] + ".cfg");
							Bitmap bitmap = Fen2Image(board, font, int.Parse(keys["size"]));
							bitmap.Save(keys["folder"] + "\\diagram" + count + ".png", ImageFormat.Png);
						}
					}
					Console.WriteLine("processed " + count + " positions");
				}
			}
			else
			{
				Info();
			}
		}
	}
}
