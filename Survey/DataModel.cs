using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
    public class Update
    {
        [Required]
        [MaxLength(140)]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public int age { get; set; }
    }
}
