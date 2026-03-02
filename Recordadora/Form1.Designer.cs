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
            this.btnAñadir = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.cbEstado = new MaterialSkin.Controls.MaterialComboBox();
            this.txtBuscar = new MaterialSkin.Controls.MaterialTextBox2();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.materialCardDataGrid = new MaterialSkin.Controls.MaterialCard();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialCardMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.materialCardDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCardMenu
            // 
            this.materialCardMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.materialCardMenu.Size = new System.Drawing.Size(1911, 206);
            this.materialCardMenu.TabIndex = 0;
            // 
            // mcCalendario
            // 
            this.mcCalendario.Location = new System.Drawing.Point(1338, 21);
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
            this.lbEstado.Location = new System.Drawing.Point(1624, 30);
            this.lbEstado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(50, 19);
            this.lbEstado.TabIndex = 7;
            this.lbEstado.Text = "Estado";
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
            this.cbEstado.Location = new System.Drawing.Point(1621, 63);
            this.cbEstado.MaxDropDownItems = 4;
            this.cbEstado.MouseState = MaterialSkin.MouseState.OUT;
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(220, 49);
            this.cbEstado.StartIndex = 0;
            this.cbEstado.TabIndex = 3;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
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
            // materialCardDataGrid
            // 
            this.materialCardDataGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardDataGrid.Controls.Add(this.dataGridView1);
            this.materialCardDataGrid.Depth = 0;
            this.materialCardDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCardDataGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardDataGrid.Location = new System.Drawing.Point(3, 270);
            this.materialCardDataGrid.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardDataGrid.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardDataGrid.Name = "materialCardDataGrid";
            this.materialCardDataGrid.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardDataGrid.Size = new System.Drawing.Size(1911, 804);
            this.materialCardDataGrid.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1883, 776);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            
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
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recordadora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialCardMenu.ResumeLayout(false);
            this.materialCardMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.materialCardDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCardMenu;
        private MaterialSkin.Controls.MaterialCard materialCardDataGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscar;
        private MaterialSkin.Controls.MaterialComboBox cbEstado;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAñadir;
        private MaterialSkin.Controls.MaterialLabel lbEstado;
        private System.Windows.Forms.MonthCalendar mcCalendario;
    }
}

