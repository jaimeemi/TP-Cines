namespace Cine_App_2.Formularios
{
    partial class frmNuevaPelicula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPelicula = new System.Windows.Forms.TextBox();
            this.txtSinopsis = new System.Windows.Forms.TextBox();
            this.lblSinopsis = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProductora = new System.Windows.Forms.Label();
            this.cbINCA = new System.Windows.Forms.ComboBox();
            this.lblInca = new System.Windows.Forms.Label();
            this.chSubtitulada = new System.Windows.Forms.CheckBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.txtProductora = new System.Windows.Forms.TextBox();
            this.cbgeneros = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPelicula
            // 
            this.txtPelicula.Location = new System.Drawing.Point(15, 24);
            this.txtPelicula.Name = "txtPelicula";
            this.txtPelicula.Size = new System.Drawing.Size(297, 20);
            this.txtPelicula.TabIndex = 0;
            // 
            // txtSinopsis
            // 
            this.txtSinopsis.Location = new System.Drawing.Point(15, 71);
            this.txtSinopsis.Multiline = true;
            this.txtSinopsis.Name = "txtSinopsis";
            this.txtSinopsis.Size = new System.Drawing.Size(307, 130);
            this.txtSinopsis.TabIndex = 1;
            // 
            // lblSinopsis
            // 
            this.lblSinopsis.AutoSize = true;
            this.lblSinopsis.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSinopsis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSinopsis.Location = new System.Drawing.Point(12, 55);
            this.lblSinopsis.Name = "lblSinopsis";
            this.lblSinopsis.Size = new System.Drawing.Size(49, 13);
            this.lblSinopsis.TabIndex = 29;
            this.lblSinopsis.Text = "Sinopsis:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(39, 13);
            this.lblTitulo.TabIndex = 30;
            this.lblTitulo.Text = "Titulo :";
            // 
            // lblProductora
            // 
            this.lblProductora.AutoSize = true;
            this.lblProductora.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProductora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProductora.Location = new System.Drawing.Point(330, 8);
            this.lblProductora.Name = "lblProductora";
            this.lblProductora.Size = new System.Drawing.Size(65, 13);
            this.lblProductora.TabIndex = 32;
            this.lblProductora.Text = "Productora: ";
            // 
            // cbINCA
            // 
            this.cbINCA.FormattingEnabled = true;
            this.cbINCA.Location = new System.Drawing.Point(333, 71);
            this.cbINCA.Name = "cbINCA";
            this.cbINCA.Size = new System.Drawing.Size(79, 21);
            this.cbINCA.TabIndex = 3;
            // 
            // lblInca
            // 
            this.lblInca.AutoSize = true;
            this.lblInca.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInca.Location = new System.Drawing.Point(330, 55);
            this.lblInca.Name = "lblInca";
            this.lblInca.Size = new System.Drawing.Size(35, 13);
            this.lblInca.TabIndex = 34;
            this.lblInca.Text = "INCA:";
            // 
            // chSubtitulada
            // 
            this.chSubtitulada.AutoSize = true;
            this.chSubtitulada.Location = new System.Drawing.Point(333, 138);
            this.chSubtitulada.Name = "chSubtitulada";
            this.chSubtitulada.Size = new System.Drawing.Size(79, 17);
            this.chSubtitulada.TabIndex = 5;
            this.chSubtitulada.Text = "Subtitulada";
            this.chSubtitulada.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGrabar.Location = new System.Drawing.Point(333, 155);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(227, 46);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cbIdioma
            // 
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(333, 111);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(227, 21);
            this.cbIdioma.TabIndex = 6;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIdioma.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIdioma.Location = new System.Drawing.Point(330, 95);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 38;
            this.lblIdioma.Text = "Idioma:";
            // 
            // txtProductora
            // 
            this.txtProductora.Location = new System.Drawing.Point(333, 24);
            this.txtProductora.Name = "txtProductora";
            this.txtProductora.Size = new System.Drawing.Size(227, 20);
            this.txtProductora.TabIndex = 2;
            // 
            // cbgeneros
            // 
            this.cbgeneros.FormattingEnabled = true;
            this.cbgeneros.Location = new System.Drawing.Point(421, 71);
            this.cbgeneros.Name = "cbgeneros";
            this.cbgeneros.Size = new System.Drawing.Size(139, 21);
            this.cbgeneros.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(418, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Genero:";
            // 
            // frmNuevaPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(572, 220);
            this.Controls.Add(this.cbgeneros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductora);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.chSubtitulada);
            this.Controls.Add(this.cbINCA);
            this.Controls.Add(this.lblInca);
            this.Controls.Add(this.lblProductora);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSinopsis);
            this.Controls.Add(this.txtSinopsis);
            this.Controls.Add(this.txtPelicula);
            this.Name = "frmNuevaPelicula";
            this.Text = "NUEVA PELICULA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPelicula;
        private System.Windows.Forms.TextBox txtSinopsis;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProductora;
        private System.Windows.Forms.ComboBox cbINCA;
        private System.Windows.Forms.Label lblInca;
        private System.Windows.Forms.CheckBox chSubtitulada;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.TextBox txtProductora;
        private System.Windows.Forms.ComboBox cbgeneros;
        private System.Windows.Forms.Label label1;
    }
}