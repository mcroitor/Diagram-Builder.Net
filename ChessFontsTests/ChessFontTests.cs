using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessFonts.Tests
{
	[TestClass()]
	public class ChessFontTests
	{
		[TestMethod()]
		public void GetNameTest()
		{
			try
			{
				ChessFont font = new ChessFont(".\\fonts\\chessalpha2.cfg");
				Console.WriteLine(font.GetName());
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				Assert.Fail();
			}
		}
	}
}