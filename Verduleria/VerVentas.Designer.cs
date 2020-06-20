namespace Verduleria
{
    partial class VerVentas
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
            this.dgvventas = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvventas
            // 
            this.dgvventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvventas.Location = new System.Drawing.Point(36, 41);
            this.dgvventas.Name = "dgvventas";
            this.dgvventas.RowHeadersWidth = 51;
            this.dgvventas.RowTemplate.Height = 24;
            this.dgvventas.Size = new System.Drawing.Size(884, 354);
            this.dgvventas.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(379, 419);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(125, 37);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver A Ventas";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // VerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 468);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvventas);
            this.Name = "VerVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerVentas";
            this.Load += new System.EventHandler(this.VerVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvventas;
        private System.Windows.Forms.Button btnVolver;
    }
}