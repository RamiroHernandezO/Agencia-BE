﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Agencia
{
    public abstract class EntityUtilites<Tid>
    {
        [Key] 
        public Tid Id { get; set; }
    }
}
