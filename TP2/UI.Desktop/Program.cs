using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DUDAS
 ¿Persona debería tener mail? (Usuario ya tiene uno) 
 ¿Deberiamos crear metodos adicionales para buscar por nombre o descripcion en la capa de datos? ¿o podemos usar Linq con un getAll?
 ¿Cómo mantener información del usuario a lo largo de la ejecución de la aplicación? (Algo similar a las sesiones en aplicaciones web)
 ¿Que datos mostrar en el listado de inscripciones?
 ¿Horarios de cursado?
  ¿Qué deberíamos registrar en las tablas módulos y módulos_usuarios?
  ¿No faltaria una tabla materias_comisiones?
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
