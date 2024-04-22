using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent_Hm_1.Models
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
