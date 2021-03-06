using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Principal : ApplicationForm
    {
        public static int id;

        public static int Id { get => id; set => id = value; }

        public Principal()
        {
            InitializeComponent();            
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            ModuloUsuario mu = null;
            try {
                int idModulo = mul.GetIdModulo("Principal");
                mu = mul.GetModuloUsuario(idModulo, Id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            if (!mu.PermiteAlta && mu.PermiteModificacion) {
                //pListado.Controls.Remove(btnPersona); //si bien permite removerlo, queda un hueco vacío que no supe eliminar
                //this.btnPersona.Enabled = false; //Esta opcion lo desactiva pero sigue siendo visible
                //this.btnUsuario.Enabled = false;

                //esto es para ocultar los botones que no corresponden a los permisos del usuario en cuestion
                this.btnPersona.Visible = false;
                this.btnUsuario.Visible = false;
                this.btnEspecialidades.Visible = false;
                this.btnMateria.Visible = false;
                this.btnPlan.Visible = false;
                this.btnComision.Visible = false;


                //esto es para cambiar el tamaño del panel de los btn, pues va a ser mas chico (contiene menos btn)
                this.pListado.Size = new Size(135, 34); //170
                //en el size busque un numero a mano para que quedara bien, sino no andaba
                //lo ideal es que tenga 180 en vez de 135 pero al ejecutarse cambia 


                //esto es para acomodar los huecos de los botones en el panel tras ser ocultados 
                this.btnCurso.Location = new Point(0, 0);
                this.btnPlan.Location = new Point(0, 34); //este es el boton de Planes
                this.btnMateria.Location = new Point(0, 70);
                this.btnEspecialidades.Location = new Point(0, 105);
                this.btnComision.Location = new Point(0, 140); // este es el bton de Comisiones

                //esto es para darle un nuevo alto a los btn porque los achica al achicarse el panel
                this.btnCurso.Size = new Size(135, 34);
                this.btnPlan.Size = new Size(135, 34); //este es el boton de Planes
                this.btnMateria.Size = new Size(135, 34);
                this.btnEspecialidades.Size = new Size(135, 34);
                this.btnComision.Size = new Size(135, 34); // este es el bton de Comisiones

                // lo que esta aca es para mostrar el rol en el formPrincipal para los usuarios de acuerdo al permiso 
                // ver una manera de distinguir al alumno del docente puesto que en el formPrincipal tienen los 
                //mismos permisos, una forma es colocar en la tabla modulo_usuarios que el docecente pueda modificar
                //en el principal y asi distinguirlo en el ultimo if y no cambiaria el funcionamiento


                this.txtRol.Text = "Docente"; //esto es para mostrar el rol del usuario Logueado
            } else if (!mu.PermiteAlta && !mu.PermiteModificacion) {
                this.panel2.Visible = false;
                this.btnListados.Visible = false;
                this.txtRol.Text = "Alumno";
            }

            if (mu.PermiteAlta && mu.PermiteModificacion && mu.PermiteBaja)
            {

                this.txtRol.Text = "Administrador"; //esto es para mostrar el rol del usuario Logueado
            }            
        }

        public Principal(int idUsuario)
        {
            InitializeComponent();
            Id = idUsuario;
            validarPermisos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e) //es el del listado
        {
            if (!pListado.Visible)
            {
                pListado.Visible = true;
            }
            else
            {
                pListado.Visible = false;
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }

        private void btnCurso_Click_1(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos();
            formCursos.ShowDialog();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog();
        }

        private void btnMateria_Click_1(object sender, EventArgs e)
        {
            Materias formMaterias = new Materias();
            formMaterias.ShowDialog();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {            
            AlumnoInscripciones alumnoInscripciones = new AlumnoInscripciones();
            alumnoInscripciones.ShowDialog();
        }

        //public void DatosUsuario(int idUsuario)
        //{
        //    Usuario usuario = new Usuario();
        //    txtNombreUsuario.Text = usuario.NombreUsuario.ToString();

            
        //}

        private void Principal_Load(object sender, EventArgs e)
        {
            UsuarioLogic ul = null;
            try {
                ul = new UsuarioLogic();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Usuario us = ul.GetOne(Id);
            this.txtNombreUsuario.Text = us.NombreUsuario.ToString();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea Cerrar Sesion?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();   
            formComisiones.ShowDialog();    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //nombre carpeta.NombreForm
            DatosReportes.ReporteUsuarios formReporteUsuarios = new DatosReportes.ReporteUsuarios();
            formReporteUsuarios.ShowDialog();
        }
    }
}
