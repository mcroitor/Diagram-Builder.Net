using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Chess;

namespace fen2img
{
	class Program
	{
		static void Info()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine("\tfen2img --inputfen=<fen> [--font=<font>] [--size=<field size>] [--output=<filename>] ");
			Console.WriteLine("\tfen2img --inputfile=<fenfile> [--font=<font>] [--size=<field size>] [--folder=<foldername>]");
            Console.WriteLine("\tfen2img --mapped-fonts - will print list of mapped fonts");
            Console.WriteLine("Default values: font=alpha2, size=50, output=diagram, folder=.");
       }

		static Bitmap CropImage(Bitmap img)
		{
            //get image data
            BitmapData bd = img.LockBits(new Rectangle(Point.Empty, img.Size),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int[] rgbValues = new int[img.Height * img.Width];
            Marshal.Copy(bd.Scan0, rgbValues, 0, rgbValues.Length);
            img.UnlockBits(bd);


            #region determine bounds
            int left = bd.Width;
            int top = bd.Height;
            int right = 0;
            int bottom = 0;

            //determine top
            for (int i = 0; i < rgbValues.Length; i++)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bd.Width;
                    int c = i % bd.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }
                    bottom = r;
                    top = r;
                    break;
                }
            }

            //determine bottom
            for (int i = rgbValues.Length - 1; i >= 0; i--)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bd.Width;
                    int c = i % bd.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }
                    bottom = r;
                    break;
                }
            }

            if (bottom > top)
            {
                for (int r = top + 1; r < bottom; r++)
                {
                    //determine left
                    for (int c = 0; c < left; c++)
                    {
                        int color = rgbValues[r * bd.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (left > c)
                            {
                                left = c;
                                break;
                            }
                        }
                    }

                    //determine right
                    for (int c = bd.Width - 1; c > right; c--)
                    {
                        int color = rgbValues[r * bd.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (right < c)
                            {
                                right = c;
                                break;
                            }
                        }
                    }
                }
            }

            int width = right - left + 1;
            int height = bottom - top + 1;
            #endregion

            //copy image data
            int[] imgData = new int[width * height];
            for (int r = top; r <= bottom; r++)
            {
                Array.Copy(rgbValues, r * bd.Width + left, imgData, (r - top) * width, width);
            }

            //create new image
            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData nbd
                = newImage.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(imgData, 0, nbd.Scan0, imgData.Length);
            newImage.UnlockBits(nbd);

            return newImage;
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

        static void PrintMappedFonts()
		{
            try
            {
                var maps = System.IO.Directory.GetFiles("fonts\\mapping\\", "*.map");
                System.Console.WriteLine("available maps for fonts:");
                foreach (var map in maps)
                {
                    System.Console.WriteLine("\t" + map.Replace(".map", "").Replace("fonts\\mapping\\", ""));
                }
            }
            catch(Exception ex)
			{
                Console.WriteLine("oops!");
                Console.WriteLine(ex);
			}
		}

		static Dictionary<string, string> keys = new Dictionary<string, string>
		{
			{ "folder", ".\\"},
			{ "font", "alpha2"},
			{ "inputfile", "" },
			{ "inputfen", "" },
			{ "output", "diagram" },
			{ "size", "50" },
            { "format", "jpeg"}
		};

        static Dictionary<string, ImageFormat> image_formats = new Dictionary<string, ImageFormat>
        {
            { "jpeg", ImageFormat.Jpeg },
            { "png", ImageFormat.Png },
            { "bmp", ImageFormat.Bmp }
        };

		static void Main(string[] args)
		{
			if(args.Length == 0)
			{
				Info();
				return;
			}

			if (Array.FindIndex(args, element => "--mapped-fonts".Equals(element)) > -1){
                PrintMappedFonts();
                return;
            }

            foreach (var keypair in args)
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
				ChessFont font = new ChessFont("fonts\\mapping\\" + keys["font"] + ".map");
				Bitmap bitmap = Fen2Image(board, font, int.Parse(keys["size"]));
				bitmap.Save(keys["output"] + "." + keys["format"], image_formats[keys["format"]]);
			}
			// input file set
			else if(keys["inputfile"] != "")
			{
				using (StreamReader reader = new StreamReader(keys["inputfile"]))
				{
                    string line;

					int count = 0;
					while ((line = reader.ReadLine()) != null)
					{
						if (line.Trim().Length > 0)
						{
                            char[] separators = new char[] { ';' };
                            string[] tmp = line.Split(separators, 2);
							++count;
							ChessBoard board = new ChessBoard();
							board.SetBoard(tmp[0].Trim());
                            if(tmp.Length > 1)
							{
                                board.comment = tmp[1];
                            }

							ChessFont font = new ChessFont("fonts\\mapping\\" + keys["font"] + ".map");
							Bitmap bitmap = Fen2Image(board, font, int.Parse(keys["size"]));
                            // bitmap = CropImage(bitmap);
							bitmap.Save(keys["folder"] + "\\diagram" + count + "." + keys["format"],
                                image_formats[keys["format"]]);
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
