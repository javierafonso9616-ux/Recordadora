namespace Recordadora
{
    partial class FormEdicion
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
            this.txtTitulo = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtDescripcion = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtSolucion = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbEstado = new MaterialSkin.Controls.MaterialComboBox();
            this.btEliminar = new MaterialSkin.Controls.MaterialButton();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.lbTItuloFormEdicion = new MaterialSkin.Controls.MaterialLabel();
            this.lbSolucionFormEdicion = new MaterialSkin.Controls.MaterialLabel();
            this.lbDescripcionFormEdicion = new MaterialSkin.Controls.MaterialLabel();
            this.lbFechaFormEdicion = new MaterialSkin.Controls.MaterialLabel();
            this.lbEstadoFormEdicion = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.AnimateReadOnly = false;
            this.txtTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTitulo.Depth = 0;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTitulo.HideSelection = true;
            this.txtTitulo.LeadingIcon = null;
            this.txtTitulo.Location = new System.Drawing.Point(22, 36);
            this.txtTitulo.MaxLength = 32767;
            this.txtTitulo.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.PasswordChar = '\0';
            this.txtTitulo.PrefixSuffixText = null;
            this.txtTitulo.ReadOnly = false;
            this.txtTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTitulo.SelectedText = "";
            this.txtTitulo.SelectionLength = 0;
            this.txtTitulo.SelectionStart = 0;
            this.txtTitulo.ShortcutsEnabled = true;
            this.txtTitulo.Size = new System.Drawing.Size(250, 48);
            this.txtTitulo.TabIndex = 0;
            this.txtTitulo.TabStop = false;
            this.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTitulo.TrailingIcon = null;
            this.txtTitulo.UseSystemPasswordChar = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AnimateReadOnly = false;
            this.txtDescripcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.Depth = 0;
            this.txtDescripcion.HideSelection = true;
            this.txtDescripcion.Location = new System.Drawing.Point(397, 36);
            this.txtDescripcion.MaxLength = 32767;
            this.txtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.ReadOnly = false;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.SelectionLength = 0;
            this.txtDescripcion.SelectionStart = 0;
            this.txtDescripcion.ShortcutsEnabled = true;
            this.txtDescripcion.Size = new System.Drawing.Size(538, 170);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TabStop = false;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescripcion.UseSystemPasswordChar = false;
            // 
            // txtSolucion
            // 
            this.txtSolucion.AnimateReadOnly = false;
            this.txtSolucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolucion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSolucion.Depth = 0;
            this.txtSolucion.HideSelection = true;
            this.txtSolucion.Location = new System.Drawing.Point(397, 246);
            this.txtSolucion.MaxLength = 32767;
            this.txtSolucion.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.PasswordChar = '\0';
            this.txtSolucion.ReadOnly = false;
            this.txtSolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSolucion.SelectedText = "";
            this.txtSolucion.SelectionLength = 0;
            this.txtSolucion.SelectionStart = 0;
            this.txtSolucion.ShortcutsEnabled = true;
            this.txtSolucion.Size = new System.Drawing.Size(538, 170);
            this.txtSolucion.TabIndex = 2;
            this.txtSolucion.TabStop = false;
            this.txtSolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSolucion.UseSystemPasswordChar = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(22, 122);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(250, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // cbEstado
            // 
            this.cbEstado.AutoResize = false;
            this.cbEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbEstado.Depth = 0;
            this.cbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbEstado.DropDownHeight = 174;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.DropDownWidth = 121;
            this.cbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.IntegralHeight = false;
            this.cbEstado.ItemHeight = 43;
            this.cbEstado.Items.AddRange(new object[] {
            "(Seleccione un estado)",
            "PENDIENTE",
            "REALIZADO",
            "CANCELADO"});
            this.cbEstado.Location = new System.Drawing.Point(22, 184);
            this.cbEstado.MaxDropDownItems = 4;
            this.cbEstado.MouseState = MaterialSkin.MouseState.OUT;
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(250, 49);
            this.cbEstado.StartIndex = 0;
            this.cbEstado.TabIndex = 4;
            // 
            // btEliminar
            // 
            this.btEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btEliminar.Depth = 0;
            this.btEliminar.HighEmphasis = true;
            this.btEliminar.Icon = null;
            this.btEliminar.Location = new System.Drawing.Point(719, 516);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btEliminar.Size = new System.Drawing.Size(88, 36);
            this.btEliminar.TabIndex = 6;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btEliminar.UseAccentColor = false;
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(853, 516);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(88, 36);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.lbTItuloFormEdicion);
            this.materialCard1.Controls.Add(this.lbSolucionFormEdicion);
            this.materialCard1.Controls.Add(this.cbEstado);
            this.materialCard1.Controls.Add(this.lbDescripcionFormEdicion);
            this.materialCard1.Controls.Add(this.dtpFecha);
            this.materialCard1.Controls.Add(this.lbFechaFormEdicion);
            this.materialCard1.Controls.Add(this.txtTitulo);
            this.materialCard1.Controls.Add(this.txtDescripcion);
            this.materialCard1.Controls.Add(this.lbEstadoFormEdicion);
            this.materialCard1.Controls.Add(this.txtSolucion);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 64);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(960, 505);
            this.materialCard1.TabIndex = 13;
            // 
            // lbTItuloFormEdicion
            // 
            this.lbTItuloFormEdicion.AutoSize = true;
            this.lbTItuloFormEdicion.Depth = 0;
            this.lbTItuloFormEdicion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbTItuloFormEdicion.Location = new System.Drawing.Point(19, 14);
            this.lbTItuloFormEdicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbTItuloFormEdicion.Name = "lbTItuloFormEdicion";
            this.lbTItuloFormEdicion.Size = new System.Drawing.Size(42, 19);
            this.lbTItuloFormEdicion.TabIndex = 13;
            this.lbTItuloFormEdicion.Text = "Título";
            // 
            // lbSolucionFormEdicion
            // 
            this.lbSolucionFormEdicion.AutoSize = true;
            this.lbSolucionFormEdicion.Depth = 0;
            this.lbSolucionFormEdicion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbSolucionFormEdicion.Location = new System.Drawing.Point(394, 224);
            this.lbSolucionFormEdicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbSolucionFormEdicion.Name = "lbSolucionFormEdicion";
            this.lbSolucionFormEdicion.Size = new System.Drawing.Size(63, 19);
            this.lbSolucionFormEdicion.TabIndex = 12;
            this.lbSolucionFormEdicion.Text = "Solución";
            // 
            // lbDescripcionFormEdicion
            // 
            this.lbDescripcionFormEdicion.AutoSize = true;
            this.lbDescripcionFormEdicion.Depth = 0;
            this.lbDescripcionFormEdicion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbDescripcionFormEdicion.Location = new System.Drawing.Point(394, 14);
            this.lbDescripcionFormEdicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbDescripcionFormEdicion.Name = "lbDescripcionFormEdicion";
            this.lbDescripcionFormEdicion.Size = new System.Drawing.Size(84, 19);
            this.lbDescripcionFormEdicion.TabIndex = 11;
            this.lbDescripcionFormEdicion.Text = "Descripción";
            // 
            // lbFechaFormEdicion
            // 
            this.lbFechaFormEdicion.AutoSize = true;
            this.lbFechaFormEdicion.Depth = 0;
            this.lbFechaFormEdicion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbFechaFormEdicion.Location = new System.Drawing.Point(19, 100);
            this.lbFechaFormEdicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbFechaFormEdicion.Name = "lbFechaFormEdicion";
            this.lbFechaFormEdicion.Size = new System.Drawing.Size(44, 19);
            this.lbFechaFormEdicion.TabIndex = 9;
            this.lbFechaFormEdicion.Text = "Fecha";
            // 
            // lbEstadoFormEdicion
            // 
            this.lbEstadoFormEdicion.AutoSize = true;
            this.lbEstadoFormEdicion.Depth = 0;
            this.lbEstadoFormEdicion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbEstadoFormEdicion.Location = new System.Drawing.Point(19, 162);
            this.lbEstadoFormEdicion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbEstadoFormEdicion.Name = "lbEstadoFormEdicion";
            this.lbEstadoFormEdicion.Size = new System.Drawing.Size(50, 19);
            this.lbEstadoFormEdicion.TabIndex = 8;
            this.lbEstadoFormEdicion.Text = "Estado";
            // 
            // FormEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(966, 572);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.materialCard1);
            this.Name = "FormEdicion";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar recordatorio";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtTitulo;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtDescripcion;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtSolucion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private MaterialSkin.Controls.MaterialComboBox cbEstado;
        private MaterialSkin.Controls.MaterialButton btEliminar;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel lbEstadoFormEdicion;
        private MaterialSkin.Controls.MaterialLabel lbSolucionFormEdicion;
        private MaterialSkin.Controls.MaterialLabel lbDescripcionFormEdicion;
        
        private MaterialSkin.Controls.MaterialLabel lbFechaFormEdicion;
        private MaterialSkin.Controls.MaterialLabel lbTItuloFormEdicion;
    }
}