using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DUDAS
 ¿Persona debería tener mail? (Usuario ya tiene uno)
 Al momento de dar de alta un usuario ¿Deberiamos mostrar un combobox con los nombres de las personas?
 ¿Deberiamos crear metodos adicionales para buscar por nombre o descripcion en la capa de datos? ¿o podemos usar Linq con un getAll?
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
