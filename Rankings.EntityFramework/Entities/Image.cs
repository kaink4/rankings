using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rankings.EntityFramework.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
