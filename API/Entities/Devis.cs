using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Devis
    {
        [Key]
        public int NumDevis { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Article> Articles  { get; set; }

    }
}