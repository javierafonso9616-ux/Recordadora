using ClosedXML.Excel; // Importante añadir esto aquí
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Recordadora
{
    public partial class FormExportar : MaterialForm
    {
        // Variables internas para guardar los grids que nos pasen desde Form1
        private DataGridView gridPrincipal;
        private DataGridView gridPendientes;
        private DataGridView gridHistorial;

        // Modificamos el constructor para que exija que le pasen los 3 grids
        public FormExportar(DataGridView principal, DataGridView pendientes, DataGridView historial)
        {
            InitializeComponent();

            // Guardamos los grids en la memoria de este formulario
            this.gridPrincipal = principal;
            this.gridPendientes = pendientes;
            this.gridHistorial = historial;

            // Configuración visual
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900, Primary.Blue900, Primary.Blue200, Accent.Blue700, TextShade.WHITE);

            this.Text = "Exportar";

            cbOpcionesGrid.Items.Add("Tabla Principal (Filtros actuales)");
            cbOpcionesGrid.Items.Add("Tabla de Pendientes");
            cbOpcionesGrid.Items.Add("Historial Completo");

            cbOpcionesGrid.SelectedIndex = 0;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            // Ocultamos la ventanita mientras genera el Excel para que parezca más fluido
            this.Hide();

            // Dependiendo de lo que elijan, llamamos a nuestro método exportador con el grid correcto
            switch (cbOpcionesGrid.SelectedIndex)
            {
                case 0:
                    ExportarGridAExcel(gridPrincipal, "Principal");
                    break;
                case 1:
                    ExportarGridAExcel(gridPendientes, "Pendientes");
                    break;
                case 2:
                    ExportarGridAExcel(gridHistorial, "Historial");
                    break;
            }

            // Al terminar la exportación (o si cancelan el guardado), cerramos la ventana del todo
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- MÉTODOS PRIVADOS DE EXPORTACIÓN ---
        private void ExportarGridAExcel(DataGridView grid, string nombreHoja)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en esta tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo de Excel|*.xlsx";
            sfd.Title = "Guardar exportación";
            sfd.FileName = $"Recordadora_{nombreHoja}_{DateTime.Now:yyyyMMdd}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(nombreHoja);

                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            var celda = worksheet.Cell(1, i + 1);
                            celda.Value = grid.Columns[i].HeaderText;
                            celda.Style.Fill.BackgroundColor = XLColor.FromHtml("#0D47A1");
                            celda.Style.Font.FontColor = XLColor.White;
                            celda.Style.Font.Bold = true;
                        }

                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            for (int j = 0; j < grid.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = grid.Rows[i].Cells[j].Value?.ToString() ?? "";
                            }
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    if (MessageBox.Show("¡Exportación completada!\n\n¿Quieres abrir el archivo?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}