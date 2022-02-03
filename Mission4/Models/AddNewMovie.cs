using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class AddNewMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a Title Name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter a Director Name")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter a Rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent { get; set; }

        public string Notes { get; set; }

        // Build Foreign Key Relationship
        [Required(ErrorMessage = "Please choose a Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
