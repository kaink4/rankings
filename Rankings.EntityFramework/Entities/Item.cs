using System.ComponentModel.DataAnnotations;

namespace Rankings.EntityFramework.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
        public Ranking Ranking { get; set; }
    }
}
