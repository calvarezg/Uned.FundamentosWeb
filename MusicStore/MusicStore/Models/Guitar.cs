using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Guitar
    {
        private static int LastId = 0;

        public int Id { get; private set; }

        [DisplayName("Model")]
        [StringLength(30)]
        public string Name { get; set; }

        [DisplayName("Image path:")]
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)")]
        public string ImagePath { get; set; }

        [DisplayName("Item Price")]
        public double Price { get; set; }

        public int Year { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public Guitar()
        {
            Id = LastId++;
        }
    }
}
