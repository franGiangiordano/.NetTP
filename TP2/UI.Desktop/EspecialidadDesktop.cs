using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;


namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private Business.Entities.Especialidad especialidadActual;          
        public Especialidad EspecialidadActual { get => especialidadActual; set => especialidadActual = value; } 

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
        }
        public EspecialidadDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Especialidad esp= new Especialidad();
                    EspecialidadActual = esp;
                    EspecialidadActual.Descripcion = txtDescripcion.Text;
                    EspecialidadActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    EspecialidadActual.Descripcion = txtDescripcion.Text;
                    EspecialidadActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    EspecialidadActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    EspecialidadActual.State = Usuario.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public override bool Validar()
        {
            string errores = "";
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            if (!this.txtDescripcion.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
            }
            if (!errores.Equals(""))
            {
                this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
