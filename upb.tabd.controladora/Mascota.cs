using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = upb.tabd.entidades;
using BR = upb.tabd.broker;

namespace upb.tabd.controladora
{
    public class Mascota
    {
        public BR.BDMascotasEntities db = new BR.BDMascotasEntities();

        public List<EN.Mascota> ConsultarMascotas(int idMascota)
        {
            List<EN.Mascota> listadoMascotas = new List<EN.Mascota>();

            try
            {

                var item = from m in db.Mascotas
                           join r in db.Razas on m.IdRaza equals r.IdRaza
                           join e in db.Especies on r.IdEspecie equals e.IdEspecie
                           join c in db.Clientes on m.IdentCliente equals c.IdentCliente
                           where ((m.Id == idMascota || idMascota == -1) && m.Visible == 1)
                           select new
                           { m.Id, m.Nombre, r.IdRaza, r.Raza1, c.IdentCliente, c.NombreCliente, e.IdEspecie, e.Especie1 };

                foreach (var registro in item)
                {
                    EN.Mascota mascota = new EN.Mascota();
                    mascota.IdentMascota = int.Parse(registro.Id.ToString());
                    mascota.NombreMascota = registro.Nombre;

                    mascota.Raza = new EN.Raza();
                    mascota.Raza.NombreRaza = registro.Raza1;

                    mascota.Especie = new EN.Especie();
                    mascota.Especie.NombreEspecie = registro.Especie1;

                    mascota.Cliente = new EN.Cliente();
                    mascota.Cliente.IdentCliente = int.Parse(registro.IdentCliente.ToString());
                    mascota.Cliente.NombreCliente = registro.NombreCliente;





                    listadoMascotas.Add(mascota);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listadoMascotas;
        }

        public bool BorrarMascota(long id)
        {
            var confirmacion = false;
            try
            {
                var mascota = (from m in db.Mascotas
                              where m.Id == id
                              select m).First();
                mascota.Visible = 0;
                db.SaveChanges();                
                confirmacion = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return confirmacion;
        }

        public bool CrearMascota(EN.Mascota objMascota)
        {
            var confirmacion = false;

            try
            {
                BR.Mascota mascota = new BR.Mascota();
                mascota.Id = objMascota.IdentMascota;
                mascota.Nombre = objMascota.NombreMascota;
                mascota.IdentCliente = objMascota.Cliente.IdentCliente;
                mascota.IdRaza = objMascota.Raza.IdRaza;
                db.Mascotas.Add(mascota);
                db.SaveChanges();

                confirmacion = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return confirmacion;
        }
    }
}
