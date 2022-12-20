﻿using System.ComponentModel.DataAnnotations;

namespace News_Backend.Models
{
    public class News : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
