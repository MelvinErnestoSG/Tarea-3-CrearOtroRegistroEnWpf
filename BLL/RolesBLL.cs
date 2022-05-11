using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_3_CrearOtroRegistroEnWpf.DAL;
using Tarea_3_CrearOtroRegistroEnWpf.Entidades;

namespace Tarea_3_CrearOtroRegistroEnWpf.BLL
{
    public class RolesBLL
    {
        public static List<Roles> GetRoles()
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Roles.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}

