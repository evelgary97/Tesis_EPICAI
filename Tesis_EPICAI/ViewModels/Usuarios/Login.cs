﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tesis_EPICAI.ViewModels.Usuarios
{
    public class Login
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
