using System.ComponentModel.DataAnnotations;

namespace Test_API_03.Models.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Kills { get; set; }
        public int Rating { get; set; }
    }
}
