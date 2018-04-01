using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upb.tabd.entidades
{
    [Serializable]
    public class Raza
    {
        public int IdRaza { get; set; }
        public string NombreRaza { get; set; }
        public Especie Especie { get; set; }
    }
}
