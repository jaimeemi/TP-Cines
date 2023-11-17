namespace Cine_App_2.Formularios.FormsConsultas
{
    partial class frmNuevaFuncion
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
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cbPelicula = new System.Windows.Forms.ComboBox();
            this.lblInca = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(252, 29);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(89, 21);
            this.cbSala.TabIndex = 42;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Red;
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(252, 56);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(89, 36);
            this.btnGrabar.TabIndex = 40;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cbPelicula
            // 
            this.cbPelicula.FormattingEnabled = true;
            this.cbPelicula.Location = new System.Drawing.Point(15, 29);
            this.cbPelicula.Name = "cbPelicula";
            this.cbPelicula.Size = new System.Drawing.Size(227, 21);
            this.cbPelicula.TabIndex = 39;
            // 
            // lblInca
            // 
            this.lblInca.AutoSize = true;
            this.lblInca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblInca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInca.Location = new System.Drawing.Point(12, 9);
            this.lblInca.Name = "lblInca";
            this.lblInca.Size = new System.Drawing.Size(57, 17);
            this.lblInca.TabIndex = 41;
            this.lblInca.Text = "Pelicula";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Sala";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(15, 72);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(227, 20);
            this.dtpDesde.TabIndex = 47;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFecha.Location = new System.Drawing.Point(12, 53);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 48;
            this.lblFecha.Text = "Fecha";
            // 
            // frmNuevaFuncion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 108);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSala);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cbPelicula);
            this.Controls.Add(this.lblInca);
            this.Name = "frmNuevaFuncion";
            this.Text = "frmNuevaFuncion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cbPelicula;
        private System.Windows.Forms.Label lblInca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblFecha;
    }
}