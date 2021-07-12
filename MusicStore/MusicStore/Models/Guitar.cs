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
        [RegularExpression(@"/img/[-a-zA-Z0-9@:%._\+~#=]+.jpg")]
        public string ImagePath { get; set; }

        [DisplayName("Item Price")]
        [Range(0, 10000)]
        public double Price { get; set; }

        [Range(1950, 2021)]
        public int Year { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public Guitar()
        {
            Id = ++LastId;
        }
    }
}
