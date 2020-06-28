using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Diagram_Builder.Net
{
	public partial class OptionsForm : System.Windows.Forms.Form
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

			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error writing app settings");
			}
		}
	}
}
