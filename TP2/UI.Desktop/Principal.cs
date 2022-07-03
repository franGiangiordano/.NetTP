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
            int idModulo = mul.GetIdModulo("Principal");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Id);

            if (!mu.PermiteAlta) {
                //pListado.Controls.Remove(btnPersona); //si bien permite removerlo, queda un hueco vacío que no supe eliminar
                //this.btnPersona.Enabled = false; //Esta opcion lo desactiva pero sigue siendo visible
                //this.btnUsuario.Enabled = false;

                //esto es para ocultar los botones que no corresponden a los permisos del usuario en cuestion
                this.btnPersona.Visible = false;
                this.btnUsuario.Visible = false;


                //esto es para cambiar el tamaño del panel de los btn, pues va a ser mas chico (contiene menos btn)
                this.pListado.Size = new Size(135,170);
                //en el size busque un numero a mano para que quedara bien, sino no andaba
                //lo ideal es que tenga 180 en vez de 135 pero al ejecutarse cambia 


                //esto es para acomodar los huecos de los botones en el panel tras ser ocultados 
                this.btnCurso.Location = new Point(0,0);
                this.button7.Location = new Point(0,34); //este es el boton de Planes
                this.btnMateria.Location = new Point(0, 70);
                this.btnEspecialidades.Location = new Point(0, 105);
                this.button11.Location = new Point(0, 140); // este es el bton de Comisiones

                //esto es para darle un nuevo alto a los btn porque los achica al achicarse el panel
                this.btnCurso.Size = new Size(135, 34);
                this.button7.Size = new Size(135, 34); //este es el boton de Planes
                this.btnMateria.Size = new Size(135, 34);
                this.btnEspecialidades.Size = new Size(135, 34);
                this.button11.Size = new Size(135, 34); // este es el bton de Comisiones

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
            AlumnoInscripciones alumnoInscripciones = new AlumnoInscripciones(4);
            alumnoInscripciones.ShowDialog();
        }

        public void DatosUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            txtNombreUsuario.Text = usuario.NombreUsuario.ToString();

            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario us = ul.GetOne(Id);
            this.txtNombreUsuario.Text = us.NombreUsuario.ToString();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog();
        }
    }
}
