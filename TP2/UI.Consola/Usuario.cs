using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuario
    {
        Business.Logic.UsuarioLogic UsuarioNegocio;

        public Usuario()
        {
            UsuarioNegocio = new UsuarioLogic();
            
        }

        public void menu()
        {
            string opt = "";
            do
            {
                Console.WriteLine("1– Listado General\n2– Consulta\n3– Agregar \n 4 - Modificar \n 5 - Eliminar \n 6 - Salir");
                opt = Console.ReadLine();
            }while(!opt.Equals("6"));
                
        }

        public void Alta()
        {
            string unMail = "abc";  
            if (!Validaciones.EsMailValido(unMail))
            {
                Console.WriteLine("Usuario con mail no valido");
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Business.Entities.Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        private void MostrarDatos(Business.Entities.Usuario usr)
        {
            Console.WriteLine("Usuario: {0}",usr.ID);
            Console.WriteLine("\t \tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t \tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t \tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t \tClave: {0}", usr.Clave);
            Console.WriteLine("\t \tMail: {0}", usr.Email);
            Console.WriteLine("\t \tHabilitado: {0}", usr.Habilitado);

            Console.WriteLine();
        }
    }
}
