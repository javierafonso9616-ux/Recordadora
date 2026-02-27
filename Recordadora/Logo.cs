using MaterialSkin.Controls;

namespace Recordadora
{
    public partial class Logo : MaterialForm
    {
        public Logo()
        {
            InitializeComponent();
            // Creamos un timer que se dispare a los 5000ms (5 segundos)
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 4500;
            timer1.Tick += (s, e) =>
            {
                timer1.Stop();
                this.Close(); // Cierra el logo automáticamente
            };
            timer1.Start();
        }
    }
}
