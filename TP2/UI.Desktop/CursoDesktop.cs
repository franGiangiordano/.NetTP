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
    public partial class CursoDesktop : ApplicationForm
    {

        public Business.Entities.Curso _CursoActual;
        public CursoDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            InitializeComponent();
        }
        public CursoDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            CursoLogic cl = new CursoLogic();
            _CursoActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public CursoDesktop()
        {

        }

        public override void MapearDeDatos()
        {
        }


        public override void MapearADatos()
        {
        }

        public override void GuardarCambios()
        {
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
    }
}
