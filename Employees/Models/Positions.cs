﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    
    public partial class Positions
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Employees> Employees { get; set; }
        public Positions()
        {
            Employees = new List<Employees>();
        }
    }
}