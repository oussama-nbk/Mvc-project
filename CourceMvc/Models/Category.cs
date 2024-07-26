﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourceMvc.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("category Name")]
        [MaxLength(10)]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
