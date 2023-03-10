using System.ComponentModel.DataAnnotations;

namespace EnglishLearn.Entities
{
    public class Vocabulary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? WordEng { get; set; }
        [Required]
        public string? WordAze { get; set; }
        [Required]
        public string? WordSound { get; set; }
        [Required]
        public string? ImagePath { get; set; }

    }
}
