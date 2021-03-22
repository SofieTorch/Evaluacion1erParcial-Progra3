using System.Collections.Generic;

namespace E0322_PilotosPrimerParcial
{
    public class PilotsDatabase
    {
        public List<Pilot> Pilots { get; set; }
        public PilotsDatabase()
        {
            Pilots = new List<Pilot>();
            LoadPilots();
        }

        private void LoadPilots()
        {
            Pilots.Add(new Pilot("Maria Lopez", "Toyota", "Mexico"));
            Pilots.Add(new Pilot("Favio Muller", "Ford", "Alemania"));
            Pilots.Add(new Pilot("Marcos Uriona", "Ford", "Francia"));
            Pilots.Add(new Pilot("Mario Torrez", "Toyota", "Bolivia"));
            Pilots.Add(new Pilot("Maria Jose Coronado", "Suzuki", "España"));
        }
    }
}