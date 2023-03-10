using EnglishLearn.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnglishLearn.Models
{
    public class EnglishModel
    {
        public int Id { get; set; }
        [Required]
        public string? WordEng { get; set; }
        [Required]
        public string? WordAze { get; set; }
        [Required]
        public string? WordSound { get; set; }
        public IFormFile File { get; set; }
    }
}
