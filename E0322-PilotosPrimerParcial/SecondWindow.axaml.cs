using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace E0322_PilotosPrimerParcial
{
    public delegate void SearchPilotDelegate(string name, string carBrand, string city);
    public delegate void SearchByCarBrandDelegate(string carBrand);
    public delegate void ShowAllDelegate();
    public class SecondWindow : Window
    {
        public event SearchPilotDelegate SearchPilot;
        public event SearchByCarBrandDelegate SearchByBrand;
        public event ShowAllDelegate ShowAll;
        
        public SecondWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public void BtnSearchPilot_Click(object sender, RoutedEventArgs e)
        {
            string name = this.FindControl<TextBox>("TxbPilotName").Text;
            string carBrand = this.FindControl<TextBox>("TxbPilotCar").Text;
            string city = this.FindControl<TextBox>("TxbPilotCity").Text;

            if (name.Trim() == "" || carBrand.Trim() == "" || city.Trim() == "")
                this.FindControl<TextBlock>("TblWarning").Text = "Debe ingresar un valor valido";
            else
                OnSearchPilot(name, carBrand, city);
        }

        public void BtnSearchByCarBrand_Click(object sender, RoutedEventArgs e)
        {
            string carBrand = this.FindControl<TextBox>("TxbCarBrand").Text;
            
            if (carBrand.Trim() == "")
                this.FindControl<TextBlock>("TblWarning").Text = "Debe ingresar una marca de auto valida";
            else
                OnSearchByBrand(carBrand);
        }

        public void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            OnShowAll();
        }
        

        private void OnSearchPilot(string name, string carBrand, string city)
        {
            SearchPilot?.Invoke(name, carBrand, city);
        }

        private void OnSearchByBrand(string carBrand)
        {
            SearchByBrand?.Invoke(carBrand);
        }

        private void OnShowAll()
        {
            ShowAll?.Invoke();
        }
    }
}