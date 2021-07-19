using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Data
{
    public interface IGuitarRepository
    {
        List<Guitar> GetAllGuitars();
        void Add(Guitar guitar);
        Guitar GetById(int id);
        List<Guitar> GetGuitarsByName(string filter);
        void Update(int id, Guitar guitarFromUser);
    }
}
