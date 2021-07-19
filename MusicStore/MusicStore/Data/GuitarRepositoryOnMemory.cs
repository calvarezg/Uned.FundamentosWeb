using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class GuitarRepositoryOnMemory : IGuitarRepository
    {        
        private static List<Guitar> guitars = null;
        private static List<Guitar> GuitarCollection
        {
            get
            {
                if (guitars == null)
                {
                    guitars = new List<Guitar>();
                    guitars.Add(new Guitar() { Name = "Standard Strat.", ImagePath = "/img/img-1.jpg", Price = 1600, Year = 2000, Description = GenerateText() });
                    guitars.Add(new Guitar() { Name = "Rosewood Std.", ImagePath = "/img/img-2.jpg", Price = 1850, Year = 2015, Description = GenerateText() });
                    guitars.Add(new Guitar() { Name = "Limited Edition", ImagePath = "/img/img-3.jpg", Price = 2665, Year = 1965, Description = GenerateText() });
                    guitars.Add(new Guitar() { Name = "Standard Mapple", ImagePath = "/img/img-4.jpg", Price = 1500, Year = 2021, Description = GenerateText() });
                }
                return guitars;
            }
        }
        public List<Guitar> GetAllGuitars()
        {
            return GuitarCollection;

        }

        public void Add(Guitar guitar)
        {
            GuitarCollection.Add(guitar);
        }

        public Guitar GetById(int id)
        {
            var query = from guitar in GuitarCollection
                        where guitar.Id == id
                        select guitar;
            return query.FirstOrDefault();
        }

        public List<Guitar> GetGuitarsByName(string filter)
        {
            var nameFilter = filter ?? string.Empty;
            var guitars = from guitar in GuitarCollection
                          where guitar.Name.Contains(nameFilter.Trim(), StringComparison.InvariantCultureIgnoreCase)
                          select guitar;
            return guitars.ToList();
        }

        public void Update(int id, Guitar guitarFromUser)
        {
            var guitarFromRepository = GetById(id);
            guitarFromRepository.Name = guitarFromUser.Name;
            guitarFromRepository.Description = guitarFromUser.Description;
            guitarFromRepository.Year = guitarFromUser.Year;
            guitarFromRepository.Price = guitarFromUser.Price;
            guitarFromRepository.ImagePath = guitarFromUser.ImagePath;
        }

        private static string GenerateText()
        {
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean vel vehicula lectus. Suspendisse sed vulputate justo. Curabitur sapien diam, porttitor eget urna nec, sagittis tincidunt dolor. Nam consectetur non velit eget placerat. Sed pulvinar auctor purus, vel rhoncus ligula faucibus ut. Nam ac justo id dolor aliquam viverra quis in nunc. Aliquam eget finibus sem, ornare tincidunt tortor. Nulla vehicula justo enim, a scelerisque enim dignissim a. Nulla vulputate metus et vulputate rutrum. Maecenas lacinia quam a convallis malesuada. ";
        }
    }
}
