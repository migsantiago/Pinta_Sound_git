namespace Pinta_Sound
{
    partial class Main_Form
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnParsePinta = new System.Windows.Forms.Button();
            this.pctPinta = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.zedParsedPlot = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepeatWave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnLoadPinta = new System.Windows.Forms.Button();
            this.btnSavePinta = new System.Windows.Forms.Button();
            this.cmbSampleFreq = new System.Windows.Forms.ComboBox();
            this.btnParseImage = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openDlgPreview = new System.Windows.Forms.OpenFileDialog();
            this.btnPlay = new System.Windows.Forms.Button();
            this.chkShowUpperLine = new System.Windows.Forms.CheckBox();
            this.chkPlotLowerLine = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctPinta)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(857, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnParsePinta
            // 
            this.btnParsePinta.BackColor = System.Drawing.SystemColors.Control;
            this.btnParsePinta.Location = new System.Drawing.Point(857, 307);
            this.btnParsePinta.Name = "btnParsePinta";
            this.btnParsePinta.Size = new System.Drawing.Size(115, 46);
            this.btnParsePinta.TabIndex = 2;
            this.btnParsePinta.Text = "Parse audio from Pinta!";
            this.btnParsePinta.UseVisualStyleBackColor = true;
            this.btnParsePinta.Click += new System.EventHandler(this.btnParsePinta_Click);
            // 
            // pctPinta
            // 
            this.pctPinta.BackColor = System.Drawing.Color.White;
            this.pctPinta.Location = new System.Drawing.Point(12, 12);
            this.pctPinta.Name = "pctPinta";
            this.pctPinta.Size = new System.Drawing.Size(839, 164);
            this.pctPinta.TabIndex = 3;
            this.pctPinta.TabStop = false;
            this.pctPinta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctPinta_MouseMove);
            this.pctPinta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctPinta_MouseDown);
            this.pctPinta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctPinta_MouseUp);
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.SystemColors.Control;
            this.btnDraw.Location = new System.Drawing.Point(857, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(54, 23);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnErase
            // 
            this.btnErase.BackColor = System.Drawing.SystemColors.Control;
            this.btnErase.Location = new System.Drawing.Point(917, 12);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(55, 23);
            this.btnErase.TabIndex = 4;
            this.btnErase.Text = "Erase";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // zedParsedPlot
            // 
            this.zedParsedPlot.Location = new System.Drawing.Point(12, 182);
            this.zedParsedPlot.Name = "zedParsedPlot";
            this.zedParsedPlot.ScrollGrace = 0;
            this.zedParsedPlot.ScrollMaxX = 0;
            this.zedParsedPlot.ScrollMaxY = 0;
            this.zedParsedPlot.ScrollMaxY2 = 0;
            this.zedParsedPlot.ScrollMinX = 0;
            this.zedParsedPlot.ScrollMinY = 0;
            this.zedParsedPlot.ScrollMinY2 = 0;
            this.zedParsedPlot.Size = new System.Drawing.Size(839, 276);
            this.zedParsedPlot.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(857, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Repeat wave";
            // 
            // txtRepeatWave
            // 
            this.txtRepeatWave.BackColor = System.Drawing.SystemColors.Control;
            this.txtRepeatWave.Location = new System.Drawing.Point(860, 232);
            this.txtRepeatWave.Name = "txtRepeatWave";
            this.txtRepeatWave.Size = new System.Drawing.Size(68, 20);
            this.txtRepeatWave.TabIndex = 7;
            this.txtRepeatWave.Text = "45";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(934, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "times";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(857, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sample rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(934, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hz";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.chkPlotLowerLine);
            this.panel1.Controls.Add(this.chkShowUpperLine);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.btnLoadImage);
            this.panel1.Controls.Add(this.btnLoadPinta);
            this.panel1.Controls.Add(this.btnSavePinta);
            this.panel1.Controls.Add(this.cmbSampleFreq);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnDraw);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnParseImage);
            this.panel1.Controls.Add(this.btnParsePinta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnErase);
            this.panel1.Controls.Add(this.txtRepeatWave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 484);
            this.panel1.TabIndex = 12;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(857, 182);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(115, 23);
            this.btnLoadImage.TabIndex = 14;
            this.btnLoadImage.Text = "Load Image...";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnLoadPinta
            // 
            this.btnLoadPinta.Location = new System.Drawing.Point(857, 99);
            this.btnLoadPinta.Name = "btnLoadPinta";
            this.btnLoadPinta.Size = new System.Drawing.Size(115, 23);
            this.btnLoadPinta.TabIndex = 14;
            this.btnLoadPinta.Text = "Load Pinta...";
            this.btnLoadPinta.UseVisualStyleBackColor = true;
            this.btnLoadPinta.Click += new System.EventHandler(this.btnLoadPinta_Click);
            // 
            // btnSavePinta
            // 
            this.btnSavePinta.Location = new System.Drawing.Point(857, 70);
            this.btnSavePinta.Name = "btnSavePinta";
            this.btnSavePinta.Size = new System.Drawing.Size(115, 23);
            this.btnSavePinta.TabIndex = 13;
            this.btnSavePinta.Text = "Save Pinta...";
            this.btnSavePinta.UseVisualStyleBackColor = true;
            this.btnSavePinta.Click += new System.EventHandler(this.btnSavePinta_Click);
            // 
            // cmbSampleFreq
            // 
            this.cmbSampleFreq.BackColor = System.Drawing.SystemColors.Control;
            this.cmbSampleFreq.FormattingEnabled = true;
            this.cmbSampleFreq.Items.AddRange(new object[] {
            "8000",
            "11025",
            "16000",
            "18900",
            "22050",
            "32000",
            "37800",
            "44056",
            "44100",
            "48000"});
            this.cmbSampleFreq.Location = new System.Drawing.Point(860, 271);
            this.cmbSampleFreq.Name = "cmbSampleFreq";
            this.cmbSampleFreq.Size = new System.Drawing.Size(68, 21);
            this.cmbSampleFreq.TabIndex = 12;
            // 
            // btnParseImage
            // 
            this.btnParseImage.BackColor = System.Drawing.SystemColors.Control;
            this.btnParseImage.Enabled = false;
            this.btnParseImage.Location = new System.Drawing.Point(857, 359);
            this.btnParseImage.Name = "btnParseImage";
            this.btnParseImage.Size = new System.Drawing.Size(115, 46);
            this.btnParseImage.TabIndex = 2;
            this.btnParseImage.Text = "Parse audio from loaded Image!";
            this.btnParseImage.UseVisualStyleBackColor = true;
            this.btnParseImage.Click += new System.EventHandler(this.btnParseImage_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(857, 449);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(115, 23);
            this.btnPlay.TabIndex = 15;
            this.btnPlay.Text = "Play!";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // chkShowUpperLine
            // 
            this.chkShowUpperLine.AutoSize = true;
            this.chkShowUpperLine.Location = new System.Drawing.Point(12, 464);
            this.chkShowUpperLine.Name = "chkShowUpperLine";
            this.chkShowUpperLine.Size = new System.Drawing.Size(76, 17);
            this.chkShowUpperLine.TabIndex = 16;
            this.chkShowUpperLine.Text = "Plot Upper";
            this.chkShowUpperLine.UseVisualStyleBackColor = true;
            // 
            // chkPlotLowerLine
            // 
            this.chkPlotLowerLine.AutoSize = true;
            this.chkPlotLowerLine.Location = new System.Drawing.Point(94, 464);
            this.chkPlotLowerLine.Name = "chkPlotLowerLine";
            this.chkPlotLowerLine.Size = new System.Drawing.Size(76, 17);
            this.chkPlotLowerLine.TabIndex = 17;
            this.chkPlotLowerLine.Text = "Plot Lower";
            this.chkPlotLowerLine.UseVisualStyleBackColor = true;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 484);
            this.Controls.Add(this.zedParsedPlot);
            this.Controls.Add(this.pctPinta);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pinta Sound - www.migsantiago.com";
            this.TransparencyKey = System.Drawing.Color.LightGray;
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctPinta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnParsePinta;
        private System.Windows.Forms.PictureBox pctPinta;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnErase;
        private ZedGraph.ZedGraphControl zedParsedPlot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepeatWave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSampleFreq;
        private System.Windows.Forms.Button btnSavePinta;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openDlgPreview;
        private System.Windows.Forms.Button btnLoadPinta;
        private System.Windows.Forms.Button btnParseImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.CheckBox chkPlotLowerLine;
        private System.Windows.Forms.CheckBox chkShowUpperLine;
    }
}

