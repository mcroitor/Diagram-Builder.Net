using System;
using System.Configuration;
using System.Windows.Forms;

namespace Diagram_Builder.Net
{
	public partial class OptionsForm : Form
	{
		public KeyValueConfigurationCollection defaultOptions;
		public OptionsForm(KeyValueConfigurationCollection options)
		{
			defaultOptions = options;
			InitializeComponent();
			this.fonts.SelectedItem = defaultOptions["DefaultFont"].Value;
			this.size.Value = decimal.Parse(defaultOptions["DefaultSize"].Value);
			this.onTop.Checked = bool.Parse(defaultOptions["OnTop"].Value);
			this.workDir.Text = defaultOptions["WorkDir"].Value;
			this.outputDir.Text = defaultOptions["OutputDir"].Value;
			this.cropImage.Checked = bool.Parse(defaultOptions["CropImage"].Value);
		}

		public string[] LoadFonts()
		{
			var mapping = "fonts\\mapping\\";
			var mapped_fonts = System.IO.Directory.GetFiles(mapping, "*.map");
			string[] result = new string[mapped_fonts.Length];
			for (int i = 0; i < mapped_fonts.Length; ++i)
			{
				Chess.ChessFont font = new Chess.ChessFont(mapped_fonts[i]);
				result[i] = font.GetID();
			}
			return result;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (defaultOptions["DefaultFont"] == null)
				{
					defaultOptions.Add("DefaultFont", fonts.SelectedItem.ToString());
				}
				else
				{
					defaultOptions["DefaultFont"].Value = fonts.SelectedItem.ToString();
				}
				if (defaultOptions["DefaultSize"] == null)
				{
					defaultOptions.Add("DefaultSize", size.Value.ToString());
				}
				else
				{
					defaultOptions["DefaultSize"].Value = size.Value.ToString();
				}
				if (defaultOptions["OutputDir"] == null)
				{
					defaultOptions.Add("OutputDir", outputDir.Text);
				}
				else
				{
					defaultOptions["OutputDir"].Value = outputDir.Text;
				}
				if (defaultOptions["WorkDir"] == null)
				{
					defaultOptions.Add("WorkDir", workDir.Text);
				}
				else
				{
					defaultOptions["WorkDir"].Value = workDir.Text;
				}
				if (defaultOptions["OnTop"] == null)
				{
					defaultOptions.Add("OnTop", onTop.Checked.ToString());
				}
				else
				{
					defaultOptions["OnTop"].Value = onTop.Checked.ToString();
				}
				if (defaultOptions["CropImage"] == null)
				{
					defaultOptions.Add("CropImage", onTop.Checked.ToString());
				}
				else
				{
					defaultOptions["CropImage"].Value = onTop.Checked.ToString();
				}
			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error writing app settings");
			}
		}
	}
}
