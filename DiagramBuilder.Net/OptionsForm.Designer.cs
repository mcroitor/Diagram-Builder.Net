using System;

namespace Diagram_Builder.Net
{
	partial class OptionsForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.workDir = new System.Windows.Forms.TextBox();
			this.outputDir = new System.Windows.Forms.TextBox();
			this.fonts = new System.Windows.Forms.ComboBox();
			this.size = new System.Windows.Forms.NumericUpDown();
			this.onTop = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(12, 190);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(235, 190);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(69, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 17);
			this.label1.TabIndex = 18;
			this.label1.Text = "Default Font";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 17);
			this.label2.TabIndex = 17;
			this.label2.Text = "Default Size";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(52, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 17);
			this.label3.TabIndex = 16;
			this.label3.Text = "Work Directory";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(42, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "Output Directory";
			// 
			// workDir
			// 
			this.workDir.Location = new System.Drawing.Point(160, 78);
			this.workDir.Name = "workDir";
			this.workDir.Size = new System.Drawing.Size(150, 22);
			this.workDir.TabIndex = 8;
			// 
			// outputDir
			// 
			this.outputDir.Location = new System.Drawing.Point(160, 106);
			this.outputDir.Name = "outputDir";
			this.outputDir.Size = new System.Drawing.Size(150, 22);
			this.outputDir.TabIndex = 9;
			// 
			// fonts
			// 
			this.fonts.FormattingEnabled = true;
			this.fonts.Items.AddRange(new object[] {
            "Chess Alpha 2",
            "Chess Berlin",
            "Chess Cases",
            "Chess Condal",
            "Chess Hastings",
            "Chess Kingdom",
            "Chess Merida"});
			this.fonts.Location = new System.Drawing.Point(160, 18);
			this.fonts.Name = "fonts";
			this.fonts.Size = new System.Drawing.Size(150, 24);
			this.fonts.TabIndex = 12;
			// 
			// size
			// 
			this.size.Location = new System.Drawing.Point(190, 50);
			this.size.Name = "size";
			this.size.Size = new System.Drawing.Size(120, 22);
			this.size.TabIndex = 13;
			this.size.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			// 
			// onTop
			// 
			this.onTop.AutoSize = true;
			this.onTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.onTop.Location = new System.Drawing.Point(55, 134);
			this.onTop.Name = "onTop";
			this.onTop.Size = new System.Drawing.Size(122, 21);
			this.onTop.TabIndex = 14;
			this.onTop.Text = "Always on Top";
			this.onTop.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.ClientSize = new System.Drawing.Size(322, 225);
			this.Controls.Add(this.onTop);
			this.Controls.Add(this.size);
			this.Controls.Add(this.fonts);
			this.Controls.Add(this.outputDir);
			this.Controls.Add(this.workDir);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "OptionsForm";
			this.Text = "Options";
			((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox workDir;
		private System.Windows.Forms.TextBox outputDir;
		private System.Windows.Forms.ComboBox fonts;
		private System.Windows.Forms.NumericUpDown size;
		private System.Windows.Forms.CheckBox onTop;
	}
}
