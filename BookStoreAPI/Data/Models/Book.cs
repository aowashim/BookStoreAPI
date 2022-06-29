using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
