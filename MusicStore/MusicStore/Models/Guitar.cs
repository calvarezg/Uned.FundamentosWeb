using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Guitar
    {
        #region Internal attributes        

        [Key]
        [Column("GuitarId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Model")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Image path")]
        [RegularExpression(@"/img/[-a-zA-Z0-9@:%._\+~#=]+.jpg")]
        public string ImagePath { get; set; }

        [DisplayName("Item Price")]
        [Range(0, 10000)]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }

        [Range(1950, 2021)]
        public int Year { get; set; }

        [MinLength(5)]
        [MaxLength(300)]
        public string Description { get; set; }   
        
        [NotMapped]
        public List<string> Errors { get; private set; }

        #endregion 

        public Guitar()
        {
            Errors = new List<string>();
        }

        #region Validation methods

        public bool IsValid()
        {
            Errors.Clear();
            ValidateName();
            ValidateYear();
            ValidateDescription();
            ValidatePrice();
            return Errors.Count == 0;
        }

        private void ValidatePrice()
        {
            if (Price <= 0 || Price >= 10000)
                Errors.Add("Price must be a value between 0 and 10000");
        }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 5 || Name.Length > 30)
                Errors.Add("Name must be a string between 5 and 30 characters.");
        }

        private void ValidateYear()
        {
            if (Year < 1950 || Year > 2021)
                Errors.Add("Year must be a number between 1950 and 2021");
        }

        private void ValidateDescription()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length < 5 || Description.Length > 30)
                Errors.Add("Description must be a string between 5 and 300 characters");
        }

        #endregion
    }
}
