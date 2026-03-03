namespace Recordadora
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialCardMenu = new MaterialSkin.Controls.MaterialCard();
            this.mcCalendario = new System.Windows.Forms.MonthCalendar();
            this.lbEstado = new MaterialSkin.Controls.MaterialLabel();
            this.cbEstado = new MaterialSkin.Controls.MaterialComboBox();
            this.materialCardDataGrid = new MaterialSkin.Controls.MaterialCard();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lbHistorial = new MaterialSkin.Controls.MaterialLabel();
            this.lbPendientes = new MaterialSkin.Controls.MaterialLabel();
            this.dgHistorial = new System.Windows.Forms.DataGridView();
            this.dgPendientes = new System.Windows.Forms.DataGridView();
            this.dgPrincipal = new System.Windows.Forms.DataGridView();
            this.mbExportarExcel = new System.Windows.Forms.Button();
            this.btnAñadir = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.txtBuscar = new MaterialSkin.Controls.MaterialTextBox2();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.materialCardMenu.SuspendLayout();
            this.materialCardDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCardMenu
            // 
            this.materialCardMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardMenu.Controls.Add(this.mbExportarExcel);
            this.materialCardMenu.Controls.Add(this.mcCalendario);
            this.materialCardMenu.Controls.Add(this.lbEstado);
            this.materialCardMenu.Controls.Add(this.btnAñadir);
            this.materialCardMenu.Controls.Add(this.cbEstado);
            this.materialCardMenu.Controls.Add(this.txtBuscar);
            this.materialCardMenu.Controls.Add(this.pictureBoxLogo);
            this.materialCardMenu.Depth = 0;
            this.materialCardMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCardMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardMenu.Location = new System.Drawing.Point(3, 64);
            this.materialCardMenu.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardMenu.Name = "materialCardMenu";
            this.materialCardMenu.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardMenu.Size = new System.Drawing.Size(1911, 178);
            this.materialCardMenu.TabIndex = 0;
            // 
            // mcCalendario
            // 
            this.mcCalendario.Location = new System.Drawing.Point(1387, 9);
            this.mcCalendario.Name = "mcCalendario";
            this.mcCalendario.TabIndex = 8;
            this.mcCalendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcCalendario_DateChanged);
            this.mcCalendario.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mcCalendario_MouseUp);
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Depth = 0;
            this.lbEstado.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbEstado.Location = new System.Drawing.Point(1677, 30);
            this.lbEstado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(50, 19);
            this.lbEstado.TabIndex = 7;
            this.lbEstado.Text = "Estado";
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
            this.cbEstado.Location = new System.Drawing.Point(1674, 63);
            this.cbEstado.MaxDropDownItems = 4;
            this.cbEstado.MouseState = MaterialSkin.MouseState.OUT;
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(220, 49);
            this.cbEstado.StartIndex = 0;
            this.cbEstado.TabIndex = 3;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // materialCardDataGrid
            // 
            this.materialCardDataGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardDataGrid.Controls.Add(this.materialDivider1);
            this.materialCardDataGrid.Controls.Add(this.lbHistorial);
            this.materialCardDataGrid.Controls.Add(this.lbPendientes);
            this.materialCardDataGrid.Controls.Add(this.dgHistorial);
            this.materialCardDataGrid.Controls.Add(this.dgPendientes);
            this.materialCardDataGrid.Controls.Add(this.dgPrincipal);
            this.materialCardDataGrid.Depth = 0;
            this.materialCardDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCardDataGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardDataGrid.Location = new System.Drawing.Point(3, 242);
            this.materialCardDataGrid.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardDataGrid.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardDataGrid.Name = "materialCardDataGrid";
            this.materialCardDataGrid.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardDataGrid.Size = new System.Drawing.Size(1911, 832);
            this.materialCardDataGrid.TabIndex = 1;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.Black;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.ForeColor = System.Drawing.Color.Black;
            this.materialDivider1.Location = new System.Drawing.Point(-2, 392);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1920, 2);
            this.materialDivider1.TabIndex = 6;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // lbHistorial
            // 
            this.lbHistorial.AutoSize = true;
            this.lbHistorial.Depth = 0;
            this.lbHistorial.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbHistorial.Location = new System.Drawing.Point(984, 407);
            this.lbHistorial.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbHistorial.Name = "lbHistorial";
            this.lbHistorial.Size = new System.Drawing.Size(60, 19);
            this.lbHistorial.TabIndex = 5;
            this.lbHistorial.Text = "Historial";
            // 
            // lbPendientes
            // 
            this.lbPendientes.AutoSize = true;
            this.lbPendientes.Depth = 0;
            this.lbPendientes.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbPendientes.Location = new System.Drawing.Point(17, 407);
            this.lbPendientes.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbPendientes.Name = "lbPendientes";
            this.lbPendientes.Size = new System.Drawing.Size(79, 19);
            this.lbPendientes.TabIndex = 4;
            this.lbPendientes.Text = "Pendientes";
            // 
            // dgHistorial
            // 
            this.dgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistorial.Location = new System.Drawing.Point(981, 429);
            this.dgHistorial.Name = "dgHistorial";
            this.dgHistorial.Size = new System.Drawing.Size(910, 344);
            this.dgHistorial.TabIndex = 3;
            this.dgHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClickGlobal);
            // 
            // dgPendientes
            // 
            this.dgPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPendientes.Location = new System.Drawing.Point(14, 429);
            this.dgPendientes.Name = "dgPendientes";
            this.dgPendientes.Size = new System.Drawing.Size(910, 344);
            this.dgPendientes.TabIndex = 2;
            this.dgPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClickGlobal);
            // 
            // dgPrincipal
            // 
            this.dgPrincipal.AllowUserToOrderColumns = true;
            this.dgPrincipal.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPrincipal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgPrincipal.EnableHeadersVisualStyles = false;
            this.dgPrincipal.Location = new System.Drawing.Point(14, 14);
            this.dgPrincipal.Name = "dgPrincipal";
            this.dgPrincipal.Size = new System.Drawing.Size(1883, 363);
            this.dgPrincipal.TabIndex = 1;
            this.dgPrincipal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClickGlobal);
            // 
            // mbExportarExcel
            // 
            this.mbExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.mbExportarExcel.FlatAppearance.BorderSize = 0;
            this.mbExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbExportarExcel.ForeColor = System.Drawing.Color.White;
            this.mbExportarExcel.Image = global::Recordadora.Properties.Resources.icons8_export_excel_32;
            this.mbExportarExcel.Location = new System.Drawing.Point(1297, 54);
            this.mbExportarExcel.Name = "mbExportarExcel";
            this.mbExportarExcel.Size = new System.Drawing.Size(62, 62);
            this.mbExportarExcel.TabIndex = 10;
            this.mbExportarExcel.UseVisualStyleBackColor = false;
            this.mbExportarExcel.Click += new System.EventHandler(this.mbExportarExcel_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Depth = 0;
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAñadir.ForeColor = System.Drawing.Color.Blue;
            this.btnAñadir.Icon = global::Recordadora.Properties.Resources.add_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.btnAñadir.Location = new System.Drawing.Point(1235, 56);
            this.btnAñadir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(56, 56);
            this.btnAñadir.TabIndex = 4;
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.AnimateReadOnly = true;
            this.txtBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.HideSelection = true;
            this.txtBuscar.Hint = "BUSCAR";
            this.txtBuscar.LeadingIcon = global::Recordadora.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscar.Location = new System.Drawing.Point(633, 62);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PrefixSuffixText = null;
            this.txtBuscar.ReadOnly = false;
            this.txtBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.ShortcutsEnabled = true;
            this.txtBuscar.Size = new System.Drawing.Size(572, 48);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TabStop = false;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscar.TrailingIcon = null;
            this.txtBuscar.UseAccent = false;
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Recordadora.Properties.Resources.Logotipo_Cruz_Roja_Horizontal_transparente_letras_negras;
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(578, 138);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.materialCardDataGrid);
            this.Controls.Add(this.materialCardMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 6, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recordadora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialCardMenu.ResumeLayout(false);
            this.materialCardMenu.PerformLayout();
            this.materialCardDataGrid.ResumeLayout(false);
            this.materialCardDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCardMenu;
        private MaterialSkin.Controls.MaterialCard materialCardDataGrid;
        private System.Windows.Forms.DataGridView dgPrincipal;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscar;
        private MaterialSkin.Controls.MaterialComboBox cbEstado;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAñadir;
        private MaterialSkin.Controls.MaterialLabel lbEstado;
        private System.Windows.Forms.MonthCalendar mcCalendario;
        private System.Windows.Forms.DataGridView dgHistorial;
        private System.Windows.Forms.DataGridView dgPendientes;
        private MaterialSkin.Controls.MaterialLabel lbHistorial;
        private MaterialSkin.Controls.MaterialLabel lbPendientes;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Button mbExportarExcel;
    }
}

