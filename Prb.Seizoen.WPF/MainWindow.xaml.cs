using System;
using System.Collections.Generic;
using System.Data;
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

namespace Prb.Seizoen.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // we maken de listbox leeg (niet echt nodig want we starten pas op)
            cmbMonth.Items.Clear();
            // we vullen de listbox met de 12 maanden
            cmbMonth.Items.Add("Januari");
            cmbMonth.Items.Add("Februari");
            cmbMonth.Items.Add("Maart");
            cmbMonth.Items.Add("April");
            cmbMonth.Items.Add("Mei");
            cmbMonth.Items.Add("Juni");
            cmbMonth.Items.Add("Juli");
            cmbMonth.Items.Add("Augustus");
            cmbMonth.Items.Add("September");
            cmbMonth.Items.Add("Oktober");
            cmbMonth.Items.Add("November");
            cmbMonth.Items.Add("December");
            // we selecteren het eerste element
            //cmbMonth.SelectedIndex = 0;
            // of we selecteren de huidige maand
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btnSeason_Click(object sender, RoutedEventArgs e)
        {
            // we zoeken het geselecteerde maandnummer op
            // de selectedindex vertelt ons het hoeveelste element werd geselecteerd
            // maar ... er wordt begonnen met element 0
            // dus tellen we eentje bij
            int monthNr = cmbMonth.SelectedIndex + 1;

            int dayNr = 1;
            // we gebruiken de TryParse methode om tekst om te zetten naar een getal
            // goed idee om dat altijd zo te doen i.p.v. de gewone parse
            // alle numerieke datatypes (int, double, byte ...) hebben een TryParse
            // 2 argumenten : 
            //   1° = de tekst die moet worden omgezet
            //   2° = "out" + de naam van de variabele waarin de waarde moet worden omgezet
            // als de omzetting mislukt, dan komt in het 2° argument de waarde 0
            int.TryParse(txtDay.Text, out dayNr);

            // we laten niet toe dat de dag kleiner is dan 1
            if (dayNr < 1)
            {
                dayNr = 1;
            }

            // per maand bekijken we wat het hoogste dagnummer mag zijn
            if (monthNr == 1 || monthNr == 3 || monthNr == 5
                || monthNr == 7 || monthNr == 8 || monthNr == 10 || monthNr == 12)
            {

                if (dayNr > 31)
                {
                    dayNr = 31;
                }
            }
            else if(monthNr == 2)
            {
                if (dayNr > 29)
                {
                    dayNr = 29;
                }
            }
            else
            {
                if(dayNr > 30)
                {
                    dayNr = 30;
                }
            }
            txtDay.Text = dayNr.ToString();
            lblSeason.Content = GetSeason(dayNr, monthNr);
        }

        private string GetSeason(int dayNr, int MonthNr)
        {
            string seizoen = "";
            if(MonthNr <= 3)
            {
                if (MonthNr == 3 && dayNr >= 21)
                    seizoen = "lente";
                else
                    seizoen = "winter";
            }
            else if(MonthNr <= 6)
            {
                if (MonthNr == 6 && dayNr >= 21)
                    seizoen = "zomer";
                else
                    seizoen = "lente";
            }
            else if (MonthNr <= 9)
            {
                if (MonthNr == 9 && dayNr >= 21)
                    seizoen = "herfst";
                else
                    seizoen = "zomer";
            }
            else
            {
                if (MonthNr == 12 && dayNr >= 21)
                    seizoen = "winter";
                else
                    seizoen = "herfst";
            }


            return seizoen;
        }
    }
}
