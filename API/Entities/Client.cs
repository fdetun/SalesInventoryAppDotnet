using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Client
    {
        [Key]
        public int CIN { get; set; }
        public string Nom { get; set; }
            public string Adress { get; set; }
        public int Tel { get; set; }

    }
}