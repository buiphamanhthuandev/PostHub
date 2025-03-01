﻿using System.ComponentModel.DataAnnotations;

namespace PostHub.Models
{
    public class CategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; } = 1;
        public ICollection<Category> Categories { get; set; }
    }
}
