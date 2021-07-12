using MusicStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Data
{
    public class Repository
    {
        private static List<Guitar> guitars = null;
        public static List<Guitar> GuitarCollection
        {
            get
            {
                if (guitars == null)
                {
                    guitars = new List<Guitar>();
                    guitars.Add(new Guitar() { Name = "Standard Strat.", ImagePath = "/img/img-1.jpg", Price = 1600 });
                    guitars.Add(new Guitar() { Name = "Rosewood Std.", ImagePath = "/img/img-2.jpg", Price = 1850 });
                    guitars.Add(new Guitar() { Name = "Limited Edition", ImagePath = "/img/img-3.jpg", Price = 2665 });
                    guitars.Add(new Guitar() { Name = "Standard Mapple", ImagePath = "/img/img-4.jpg", Price = 1500 });
                }
                return guitars;
            }
        }

        public static IEnumerable<Guitar> GetGuitarsByName(string filter)
        {
            var nameFilter = filter ?? string.Empty;
            var guitars = from guitar in GuitarCollection
                          where guitar.Name.Contains(nameFilter.Trim(), System.StringComparison.InvariantCultureIgnoreCase)
                          select guitar;
            return guitars.ToList();
        }
    }
}
