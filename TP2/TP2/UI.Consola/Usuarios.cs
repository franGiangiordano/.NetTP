using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

//Esta clase fue hecha para un laboratorio, si bien no forma parte del TP, puede ser utilizada como referencia

namespace UI.Consola
{
    public class Usuarios
    {
        Business.Logic.UsuarioLogic _UsuarioNegocio;

        public Usuarios()
        {
            _UsuarioNegocio = new UsuarioLogic();
            
        }

        public void menu()
        {
            string opt = "";
            do
            {
                Console.WriteLine("1– Listado General\n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir");
                opt = Console.ReadLine();
                switch (opt) {
                    case "1":
                        ListadoGeneral();
                      break;
                    case "2":
                        Consultar();
                        break;
                    case "3":
                        Agregar();
                        break;
                    case "4":
                        Modificar();
                        break;
                    case "5":
                        Eliminar();
                        break;
                    default:
                        break;
                }
                    
            }while(!opt.Equals("6"));
                
        }

        public void Eliminar()
        {
            try {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                _UsuarioNegocio.Delete(ID);

            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione un tecla para continuar");
                Console.ReadKey();
            }

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
            foreach(Business.Entities.Usuario usr in _UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void Consultar() {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(_UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally {                
                Console.WriteLine("Presione un tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Modificar()
        {
            try
            {
                Console.Clear();                
                Console.WriteLine("Ingrese la ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = _UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Mail: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitacion de Usuario (1-Si/2-No): ");
                usuario.Habilitado = (Console.ReadLine()=="1");
                usuario.State = BusinessEntity.States.Modified;
                _UsuarioNegocio.Save(usuario);
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione un tecla para continuar");
                Console.ReadKey();
            }

        }


        public void Agregar() {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de Usuario (1-Si/2-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            _UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
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
