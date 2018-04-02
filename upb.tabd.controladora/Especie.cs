using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = upb.tabd.entidades;
using BR = upb.tabd.broker;

namespace upb.tabd.controladora
{
    public class Especie
    {
        public BR.BDMascotasEntities db = new BR.BDMascotasEntities();

        public List<EN.Especie> ConsultarEspecies()
        {
            List<EN.Especie> listadoEspecies = new List<EN.Especie>();

            try
            {

                var especies = from e in db.Especies
                           select e;

                foreach (var registro in especies)
                {
                    EN.Especie especie = new EN.Especie();
                    especie.IdEspecie = int.Parse(registro.IdEspecie.ToString());
                    especie.NombreEspecie = registro.Especie1;
                    listadoEspecies.Add(especie);
                }
}
            catch (Exception ex)
            {

                throw ex;
            }

            return listadoEspecies;
        }
    }
}
