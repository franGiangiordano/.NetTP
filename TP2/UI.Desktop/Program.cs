using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DUDAS
 ¿Cómo mantener información del usuario a lo largo de la ejecución de la aplicación? (Algo similar a las sesiones en aplicaciones web)
    Usar una propiedad global en el formulario principal
  ¿Qué deberíamos registrar en las tablas módulos y módulos_usuarios?
   modulos_usuarios seria el formulario, esa tabla tiene cols para c/accion en ese form
   sirve para consultar si el usuario tiene permiso para realizar tal operacion en el form 
   Arreglar los comboboxes de todos los formularios
   Agregar propiedades a los atributos
   Ver el tema de reportes
*/

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formLogin());
            //Application.Run(new formMain());
            //Application.Run(new formListaUsuarios());
            //Application.Run(new Usuarios());
            //Application.Run(new PersonaDesktop());
            // Application.Run(new Personas());
            // Application.Run(new Materias());
            //Application.Run(new ApplicationForm());
            //Application.Run(new Principal());
        }
    }
}
