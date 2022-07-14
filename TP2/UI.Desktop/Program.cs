using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DUDAS     
   Ver el tema de reportes
   Hacer transacciones para las tablas modulo_usuarios al momento de crear un usuario
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
