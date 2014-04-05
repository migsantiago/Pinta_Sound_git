namespace Pinta_Sound
{
    partial class Preview_Form
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
            this.pctPreviewImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreviewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pctPreviewImage
            // 
            this.pctPreviewImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreviewImage.Location = new System.Drawing.Point(0, 0);
            this.pctPreviewImage.Name = "pctPreviewImage";
            this.pctPreviewImage.Size = new System.Drawing.Size(837, 442);
            this.pctPreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctPreviewImage.TabIndex = 0;
            this.pctPreviewImage.TabStop = false;
            // 
            // Preview_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 442);
            this.Controls.Add(this.pctPreviewImage);
            this.Name = "Preview_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preview";
            ((System.ComponentModel.ISupportInitialize)(this.pctPreviewImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pctPreviewImage;

    }
}