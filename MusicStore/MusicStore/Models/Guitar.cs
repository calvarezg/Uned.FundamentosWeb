using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Guitar
    {
        #region Internal attributes

        private static int LastId = 0;

        public int Id { get; private set; }

        [DisplayName("Model")]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Image path")]
        [RegularExpression(@"/img/[-a-zA-Z0-9@:%._\+~#=]+.jpg")]
        public string ImagePath { get; set; }

        [DisplayName("Item Price")]
        [Range(0, 10000)]
        public double Price { get; set; }

        [Range(1950, 2021)]
        public int Year { get; set; }

        [MinLength(5)]
        [MaxLength(300)]
        public string Description { get; set; }   
        
        public List<string> Errors { get; private set; }

        #endregion 

        public Guitar()
        {
            Id = ++LastId;
            Errors = new List<string>();
        }

        #region Validation methods

        public bool IsValid()
        {
            Errors.Clear();
            ValidateName();
            ValidateYear();
            ValidateDescription();
            return Errors.Count == 0;
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
