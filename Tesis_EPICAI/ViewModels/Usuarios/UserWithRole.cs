using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tesis_EPICAI.ViewModels.Usuarios
{
    public class UserWithRole
    {
        public string User { get; set; }

        public string Role { get; set; }

        public string Id { get; set; }
    }
}
