using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent_Hm_1.Models
{
    internal class Task
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
        public override string ToString()
        {
            string res = $"Id: {Id}\nDescription: {Description}\nDate: {Date.ToShortDateString}\nStatus:";
            res += IsDone ? " \u001b[32mВыполнено\u001b[0m" : " \u001b[31mНе Выполнено\u001b[0m";
            return res;
        }
    }
}
