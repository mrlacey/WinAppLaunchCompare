﻿namespace WinFormsApp
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
			label1 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 96F);
			label1.Location = new Point(115, 139);
			label1.Name = "label1";
			label1.Size = new Size(821, 254);
			label1.TabIndex = 0;
			label1.Text = "LOADED";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1054, 538);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			Shown += Form1_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
	}
}
