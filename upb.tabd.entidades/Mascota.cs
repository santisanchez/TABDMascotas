using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace upb.tabd.entidades
{
    [Serializable]
    public class Mascota
    {
        public long IdentMascota { get; set; }
        public String NombreMascota { get; set; }
        public int Visible { get; set; }

        public Raza Raza { get; set; }
        public Especie Especie { get; set; }
        public Cliente Cliente { get; set; }
    }
}