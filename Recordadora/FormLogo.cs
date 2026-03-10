using MaterialSkin.Controls;

namespace Recordadora
{
    public partial class FormLogo : MaterialForm
    {
        public FormLogo()
        {
            InitializeComponent();

            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 4400;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Stop();
                this.Close(); // Cierra el logo automáticamente
            };

        }
    }
}
