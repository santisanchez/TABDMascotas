using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = upb.tabd.entidades;
using BR = upb.tabd.broker;

namespace upb.tabd.controladora
{
    public class Raza
    {
        BR.BDMascotasEntities db = new BR.BDMascotasEntities();


        public List<EN.Raza> ConsultarRaza(int idEspecie)
        {
            List<EN.Raza> resultado = new List<EN.Raza>();            

            //var item = from r in db.Razas                      
            //           where (r.IdEspecie == idEspecie)
            //           select new { r.IdRaza, r.Raza1};

            var item = from r in db.Razas
                       select r;

            foreach (var registro in item)
            {
                EN.Raza objRaza = new EN.Raza();                
                objRaza.IdRaza = int.Parse(registro.IdRaza.ToString());
                objRaza.NombreRaza = registro.Raza1;                               

                resultado.Add(objRaza);
            }
            return resultado;
        }
    }
}
