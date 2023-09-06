using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hattertar_szamolas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KapacitasComboBoxFeltoltes();
            AtvitelComboBoxFeltoltes();
            boxKapacitas.SelectedIndex = 0;
            boxAtvitel.SelectedIndex = 0;

            var bc = new BrushConverter();
            lblKapacitas.Foreground = (Brush)bc.ConvertFrom("#00ff0d");
            lblAtvitel.Foreground = (Brush)bc.ConvertFrom("#00ff0d");
            lblTen.Foreground = (Brush)bc.ConvertFrom("#00ff0d");
            lblFiveTh.Foreground = (Brush)bc.ConvertFrom("#00ff0d");
            lblAtviteliSeb.Foreground = (Brush)bc.ConvertFrom("Red");
            window.Background = (Brush)bc.ConvertFrom("Black");
            btnSzamol.Foreground = (Brush)bc.ConvertFrom("#ff9717");
            btnSzamol.Background = (Brush)bc.ConvertFrom("Black");
            btnSzamol.BorderBrush = (Brush)bc.ConvertFrom("#ff9717");

            

        }

        private void KapacitasComboBoxFeltoltes()
        {
            boxKapacitas.Items.Add("KB");
            boxKapacitas.Items.Add("MB");
            boxKapacitas.Items.Add("GB");
            boxKapacitas.Items.Add("TB");
        }

        private void AtvitelComboBoxFeltoltes()
        {
            boxAtvitel.Items.Add("KBps");
            boxAtvitel.Items.Add("MBps");
            boxAtvitel.Items.Add("GBps");
            boxAtvitel.Items.Add("TBps");
        }


        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            //  atvitel / kapacitas

            double kapacitasSzam = 0;
            bool fojtatodhat = true;

            try
            {
                kapacitasSzam = Convert.ToDouble(txtKapacitas.Text);

                if (kapacitasSzam == 0)
                {
                    fojtatodhat = false;
                }

            }
            catch (FormatException)
            {
                fojtatodhat = false;
                MessageBox.Show("Hiba történt a kapacitás beolvasásakor! Kérlek ellenőrizd a beviteli mezőt!");
            }

            if (fojtatodhat == true)
            {
                double atvitelSzam = sliCsuszka.Value;
                double eredmeny = 0;
                string? kapacitasMert = Convert.ToString(boxKapacitas.SelectedItem);
                string? atvitelMert = Convert.ToString(boxAtvitel.SelectedItem);

                if (kapacitasMert == "KB")
                {

                }
                else if (kapacitasMert == "MB")
                {
                    kapacitasSzam *= 1000;
                }
                else if (kapacitasMert == "GB")
                {
                    kapacitasSzam *= 1000 * 1000;
                }
                else if (kapacitasMert == "TB")
                {
                    kapacitasSzam *= 1000 * 1000 * 1000;
                }

                if (atvitelMert == "KBps")
                {

                }
                else if (atvitelMert == "MBps")
                {
                    atvitelSzam *= 1000;
                }
                else if (atvitelMert == "GBps")
                {
                    atvitelSzam *= 1000 * 1000;
                }
                else if (atvitelMert == "TBps")
                {
                    atvitelSzam *= 1000 * 1000 * 1000;
                }

                eredmeny = kapacitasSzam / atvitelSzam;

                TimeSpan time = TimeSpan.FromSeconds(Math.Round(eredmeny, 3));
                string vegEredmeny = time.ToString(@"hh\:mm\:ss\:fff");

                MessageBox.Show($" Az átvitelhez szükséges idő: {vegEredmeny}");
            }

            
        }
    }
}
