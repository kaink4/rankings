using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rankings.EntityFramework.Entities
{
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
