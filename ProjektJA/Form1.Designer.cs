namespace ProjektJA
{
    partial class MyForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadPB = new System.Windows.Forms.PictureBox();
            this.ResultPB = new System.Windows.Forms.PictureBox();
            this.LeftPabel = new System.Windows.Forms.Panel();
            this.ThreadPanel = new System.Windows.Forms.Panel();
            this.TNumberValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ChooseThreadLabel = new System.Windows.Forms.Label();
            this.TimePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ASMTime = new System.Windows.Forms.Label();
            this.CTime = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MakeButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LibPanel = new System.Windows.Forms.Panel();
            this.ASMLibrary = new System.Windows.Forms.RadioButton();
            this.CLibrary = new System.Windows.Forms.RadioButton();
            this.LibLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPB)).BeginInit();
            this.LeftPabel.SuspendLayout();
            this.ThreadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.TimePanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LibPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadPB
            // 
            this.LoadPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LoadPB.Location = new System.Drawing.Point(12, 12);
            this.LoadPB.Name = "LoadPB";
            this.LoadPB.Size = new System.Drawing.Size(440, 280);
            this.LoadPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadPB.TabIndex = 0;
            this.LoadPB.TabStop = false;
            // 
            // ResultPB
            // 
            this.ResultPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultPB.Location = new System.Drawing.Point(468, 12);
            this.ResultPB.Name = "ResultPB";
            this.ResultPB.Size = new System.Drawing.Size(440, 280);
            this.ResultPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ResultPB.TabIndex = 1;
            this.ResultPB.TabStop = false;
            // 
            // LeftPabel
            // 
            this.LeftPabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPabel.Controls.Add(this.ThreadPanel);
            this.LeftPabel.Controls.Add(this.TimePanel);
            this.LeftPabel.Location = new System.Drawing.Point(12, 310);
            this.LeftPabel.Name = "LeftPabel";
            this.LeftPabel.Size = new System.Drawing.Size(440, 180);
            this.LeftPabel.TabIndex = 2;
            // 
            // ThreadPanel
            // 
            this.ThreadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThreadPanel.Controls.Add(this.TNumberValue);
            this.ThreadPanel.Controls.Add(this.label1);
            this.ThreadPanel.Controls.Add(this.trackBar1);
            this.ThreadPanel.Controls.Add(this.ChooseThreadLabel);
            this.ThreadPanel.Location = new System.Drawing.Point(20, 100);
            this.ThreadPanel.Name = "ThreadPanel";
            this.ThreadPanel.Size = new System.Drawing.Size(400, 70);
            this.ThreadPanel.TabIndex = 1;
            // 
            // TNumberValue
            // 
            this.TNumberValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TNumberValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TNumberValue.Location = new System.Drawing.Point(268, 30);
            this.TNumberValue.Name = "TNumberValue";
            this.TNumberValue.Size = new System.Drawing.Size(127, 30);
            this.TNumberValue.TabIndex = 3;
            this.TNumberValue.Text = "1";
            this.TNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(265, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybrano wątków:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(-1, 25);
            this.trackBar1.Maximum = 64;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(265, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.Threads_number_trackbar_Scroll);
            // 
            // ChooseThreadLabel
            // 
            this.ChooseThreadLabel.AutoSize = true;
            this.ChooseThreadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChooseThreadLabel.Location = new System.Drawing.Point(10, 6);
            this.ChooseThreadLabel.Name = "ChooseThreadLabel";
            this.ChooseThreadLabel.Size = new System.Drawing.Size(132, 16);
            this.ChooseThreadLabel.TabIndex = 0;
            this.ChooseThreadLabel.Text = "Ustaw liczbę wątków:";
            // 
            // TimePanel
            // 
            this.TimePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimePanel.Controls.Add(this.label3);
            this.TimePanel.Controls.Add(this.label2);
            this.TimePanel.Controls.Add(this.ASMTime);
            this.TimePanel.Controls.Add(this.CTime);
            this.TimePanel.Controls.Add(this.TimeLabel);
            this.TimePanel.Location = new System.Drawing.Point(20, 10);
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Size = new System.Drawing.Size(400, 70);
            this.TimePanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(254, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ASM time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(122, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "C# time:";
            // 
            // ASMTime
            // 
            this.ASMTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ASMTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ASMTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ASMTime.Location = new System.Drawing.Point(257, 20);
            this.ASMTime.Name = "ASMTime";
            this.ASMTime.Size = new System.Drawing.Size(100, 30);
            this.ASMTime.TabIndex = 2;
            // 
            // CTime
            // 
            this.CTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CTime.Location = new System.Drawing.Point(125, 20);
            this.CTime.Name = "CTime";
            this.CTime.Size = new System.Drawing.Size(100, 30);
            this.CTime.TabIndex = 1;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimeLabel.Location = new System.Drawing.Point(10, 25);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(107, 16);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "Czas wykonania:";
            // 
            // RightPanel
            // 
            this.RightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightPanel.Controls.Add(this.panel1);
            this.RightPanel.Controls.Add(this.LibPanel);
            this.RightPanel.Location = new System.Drawing.Point(468, 310);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(440, 180);
            this.RightPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.MakeButton);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Location = new System.Drawing.Point(244, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 160);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(3, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Raport";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveButton.Location = new System.Drawing.Point(3, 83);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 30);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MakeButton
            // 
            this.MakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MakeButton.Location = new System.Drawing.Point(3, 43);
            this.MakeButton.Name = "MakeButton";
            this.MakeButton.Size = new System.Drawing.Size(150, 30);
            this.MakeButton.TabIndex = 1;
            this.MakeButton.Text = "Wykonaj";
            this.MakeButton.UseVisualStyleBackColor = true;
            this.MakeButton.Click += new System.EventHandler(this.MakeButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadButton.Location = new System.Drawing.Point(3, 3);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(150, 30);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Załaduj obraz";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // LibPanel
            // 
            this.LibPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LibPanel.Controls.Add(this.ASMLibrary);
            this.LibPanel.Controls.Add(this.CLibrary);
            this.LibPanel.Controls.Add(this.LibLabel);
            this.LibPanel.Location = new System.Drawing.Point(40, 10);
            this.LibPanel.Name = "LibPanel";
            this.LibPanel.Size = new System.Drawing.Size(156, 160);
            this.LibPanel.TabIndex = 0;
            // 
            // ASMLibrary
            // 
            this.ASMLibrary.AutoSize = true;
            this.ASMLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ASMLibrary.Location = new System.Drawing.Point(25, 81);
            this.ASMLibrary.Name = "ASMLibrary";
            this.ASMLibrary.Size = new System.Drawing.Size(54, 20);
            this.ASMLibrary.TabIndex = 2;
            this.ASMLibrary.TabStop = true;
            this.ASMLibrary.Text = "ASM";
            this.ASMLibrary.UseVisualStyleBackColor = true;
            this.ASMLibrary.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // CLibrary
            // 
            this.CLibrary.AutoSize = true;
            this.CLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CLibrary.Location = new System.Drawing.Point(26, 47);
            this.CLibrary.Name = "CLibrary";
            this.CLibrary.Size = new System.Drawing.Size(41, 20);
            this.CLibrary.TabIndex = 1;
            this.CLibrary.TabStop = true;
            this.CLibrary.Text = "C#";
            this.CLibrary.UseVisualStyleBackColor = true;
            // 
            // LibLabel
            // 
            this.LibLabel.AutoSize = true;
            this.LibLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LibLabel.Location = new System.Drawing.Point(22, 17);
            this.LibLabel.Name = "LibLabel";
            this.LibLabel.Size = new System.Drawing.Size(107, 16);
            this.LibLabel.TabIndex = 0;
            this.LibLabel.Text = "Wybór biblioteki:";
            // 
            // MyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(920, 504);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPabel);
            this.Controls.Add(this.ResultPB);
            this.Controls.Add(this.LoadPB);
            this.Name = "MyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JA Projekt";
            ((System.ComponentModel.ISupportInitialize)(this.LoadPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPB)).EndInit();
            this.LeftPabel.ResumeLayout(false);
            this.ThreadPanel.ResumeLayout(false);
            this.ThreadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.TimePanel.ResumeLayout(false);
            this.TimePanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.LibPanel.ResumeLayout(false);
            this.LibPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LoadPB;
        private System.Windows.Forms.PictureBox ResultPB;
        private System.Windows.Forms.Panel LeftPabel;
        private System.Windows.Forms.Panel ThreadPanel;
        private System.Windows.Forms.Panel TimePanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button MakeButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Panel LibPanel;
        private System.Windows.Forms.RadioButton ASMLibrary;
        private System.Windows.Forms.RadioButton CLibrary;
        private System.Windows.Forms.Label LibLabel;
        private System.Windows.Forms.Label TNumberValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label ChooseThreadLabel;
        private System.Windows.Forms.Label CTime;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label ASMTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

