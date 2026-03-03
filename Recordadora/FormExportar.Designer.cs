namespace Recordadora
{
    partial class FormExportar
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
            this.cbOpcionesGrid = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAceptar = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // cbOpcionesGrid
            // 
            this.cbOpcionesGrid.AutoResize = false;
            this.cbOpcionesGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbOpcionesGrid.Depth = 0;
            this.cbOpcionesGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbOpcionesGrid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbOpcionesGrid.DropDownHeight = 174;
            this.cbOpcionesGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpcionesGrid.DropDownWidth = 121;
            this.cbOpcionesGrid.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbOpcionesGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbOpcionesGrid.FormattingEnabled = true;
            this.cbOpcionesGrid.IntegralHeight = false;
            this.cbOpcionesGrid.ItemHeight = 43;
            this.cbOpcionesGrid.Location = new System.Drawing.Point(3, 64);
            this.cbOpcionesGrid.MaxDropDownItems = 4;
            this.cbOpcionesGrid.MouseState = MaterialSkin.MouseState.OUT;
            this.cbOpcionesGrid.Name = "cbOpcionesGrid";
            this.cbOpcionesGrid.Size = new System.Drawing.Size(414, 49);
            this.cbOpcionesGrid.StartIndex = 0;
            this.cbOpcionesGrid.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAceptar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAceptar.Depth = 0;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAceptar.HighEmphasis = true;
            this.btnAceptar.Icon = null;
            this.btnAceptar.Location = new System.Drawing.Point(3, 128);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAceptar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAceptar.Size = new System.Drawing.Size(414, 36);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Exportar";
            this.btnAceptar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAceptar.UseAccentColor = false;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // FormExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 167);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbOpcionesGrid);
            this.Name = "FormExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormExportar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cbOpcionesGrid;
        private MaterialSkin.Controls.MaterialButton btnAceptar;
    }
}