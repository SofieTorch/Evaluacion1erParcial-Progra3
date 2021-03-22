namespace E0322_PilotosPrimerParcial
{
    public class Pilot
    {
        public string Name { get; set; }
        public string CarBrand { get; set; }
        public string City { get; set; }
        
        public Pilot(string name, string carBrand, string city)
        {
            Name = name;
            CarBrand = carBrand;
            City = city;
        }

        public override string ToString()
        {
            return $"{Name}, Marca de auto: {CarBrand}, Ciudad: {City}";
        }
    }
}