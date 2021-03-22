using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace E0322_PilotosPrimerParcial
{
    public delegate bool FilterPilot(string pCarBrand, string carBrand2);
    public class MainWindow : Window
    {
        private List<Pilot> _pilots;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            _pilots = new PilotsDatabase().Pilots;
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.SearchPilot += ShowPilotIndex;
            secondWindow.SearchByBrand += ShowPilotsByCarBrand;
            secondWindow.ShowAll += ShowAllPilots;
            secondWindow.Show();
            AvaloniaXamlLoader.Load(this);
        }

        protected void ShowPilotIndex(string name, string carBrand, string city)
        {
            TextBlock pilotsView = this.FindControl<TextBlock>("TblPilotsView");
            pilotsView.Text = "";
            int index = -1;
            foreach (Pilot pilot in _pilots)
            {
                if (pilot.Name == name && pilot.CarBrand == carBrand && pilot.City == city)
                {
                    index = _pilots.IndexOf(pilot);
                    break;
                }
            }

            pilotsView.Text = $"Posicion: {index}";
        }

        protected void ShowPilotsByCarBrand(string carBrand)
        {
            SearchPilots(carBrand, (pCarBrand, carBrand) => pCarBrand == carBrand);
        }

        protected void ShowAllPilots()
        {
            SearchPilots( "", (pCarBrand, carBrand) => true);
        }

        private void SearchPilots(string carBrand, FilterPilot filterPilot)
        {
            TextBlock pilotsView = this.FindControl<TextBlock>("TblPilotsView");
            pilotsView.Text = "";
            List<Pilot> res = new List<Pilot>();
            foreach (Pilot pilot in _pilots)
                if (filterPilot(pilot.CarBrand, carBrand))
                    pilotsView.Text += $"\n {pilot}";
        }
    }
}