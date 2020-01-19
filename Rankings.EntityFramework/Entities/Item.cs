using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rankings.EntityFramework.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }      
        
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public int Rating { get; set; }
        
        [Required]
        public Ranking Ranking { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
