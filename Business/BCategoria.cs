using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BCategoria
    {
        private DCategoria dCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;


            dCategoria = new DCategoria();
            //PROBLEMA
            categorias = dCategoria.Listar(new Categoria { IdCategoria = IdCategoria });


            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Actualizar(Categoria categoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Actualizar(categoria);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Eliminar(int IdCategoria)
        {
            bool result = true;

            try
            {
                dCategoria = new DCategoria();
                dCategoria.Eliminar(IdCategoria);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
