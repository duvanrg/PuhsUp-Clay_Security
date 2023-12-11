using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Authorization1
    {

        public enum Rol
        {
            Cliente,
            CiberSeguridad,
            Vigilante
        }

        public const Rol rol_default = Rol.Cliente;
    }
}