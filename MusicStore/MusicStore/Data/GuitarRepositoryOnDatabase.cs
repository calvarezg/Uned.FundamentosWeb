using MusicStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Data
{
    public class GuitarRepositoryOnDatabase : IGuitarRepository
    {
        private MusicStoreContext Context { get; set; }

        public GuitarRepositoryOnDatabase(MusicStoreContext context)
        {
            Context = context;
        }

        public List<Guitar> GetAllGuitars()
        {
            var query = from guitar in Context.Guitars
                        select guitar;
            return query.ToList();
        }

        public void Add(Guitar guitar)
        {
            Context.Add(guitar);
            Context.SaveChanges();
        }

        public Guitar GetById(int id)
        {
            var query = from guitar in Context.Guitars
                        where guitar.Id == id
                        select guitar;
            return query.FirstOrDefault();
        }

        public List<Guitar> GetGuitarsByName(string filter)
        {
            var nameFilter = filter ?? string.Empty;
            var guitars = from guitar in Context.Guitars
                          where guitar.Name.Contains(nameFilter.Trim())
                          select guitar;
            return guitars.ToList();
        }

        public void Update(int id, Guitar guitarFromUser)
        {
            Context.Update(guitarFromUser);
            Context.SaveChanges();
        }
    }
}
