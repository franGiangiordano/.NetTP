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

        private Business.Entities.Curso _cursoActual;

        public Curso CursoActual { get => _cursoActual; set => _cursoActual = value; }

        public CursoDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            InitializeComponent();
            cargarComboMaterias();
            cargarComboComisiones();
        }
       
        public CursoDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            cargarComboMaterias();
            cargarComboComisiones();
            MapearDeDatos();
        }

        public CursoDesktop()
        {
            //InitializeComponent();            
        }

        private void cargarComboMaterias()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetDescripciones();
            this.cmbMaterias.DataSource = materias;
            this.cmbMaterias.DisplayMember = "Descripcion";
            this.cmbMaterias.ValueMember = "ID";
        }


        private void cargarComboComisiones()
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetDescripciones();
            this.cmbComisiones.DataSource = comisiones;
            this.cmbComisiones.DisplayMember = "Descripcion";
            this.cmbComisiones.ValueMember = "ID";
        }


        public override void MapearDeDatos()
        {
            CursoLogic cl = new CursoLogic();

            this.txtId.Text = this.CursoActual.ID.ToString();           
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();

            this.cmbMaterias.SelectedValue = this.CursoActual.IDMateria;
            this.cmbComisiones.SelectedValue = this.CursoActual.IDComision;
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
            CursoLogic pl = new CursoLogic();

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Curso cur = new Curso();                    
                    CursoActual = cur;
                    CursoActual.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);
                    CursoActual.Cupo = Int32.Parse(txtCupo.Text);                                        
                    CursoActual.IDMateria = (int)this.cmbMaterias.SelectedValue;
                    CursoActual.IDComision = (int)this.cmbComisiones.SelectedValue;

                    CursoActual.State = Curso.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:                    
                    CursoActual.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);
                    CursoActual.Cupo = Int32.Parse(txtCupo.Text);                    
                    CursoActual.IDMateria = (int)this.cmbMaterias.SelectedValue;
                    CursoActual.IDComision = (int)this.cmbComisiones.SelectedValue;
                    
                    CursoActual.State = Curso.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    CursoActual.State = Curso.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    CursoActual.State = Curso.States.Modified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            
            try {
                MapearADatos();
                CursoLogic ul = new CursoLogic();
                ul.Save(CursoActual);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) {
                GuardarCambios();
                Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override bool Validar()
        {
            string errores = "";
            CursoLogic cl = new CursoLogic();
            if (String.IsNullOrEmpty(this.txtAnioCalendario.Text)
            || String.IsNullOrEmpty(this.txtCupo.Text))
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            else {
                if ((!cl.validarEntero(this.txtCupo.Text)) || (!cl.validarEntero(this.txtAnioCalendario.Text)))
                {
                    errores += "El cupo y el año calendario tienen que ser numeros enteros positivos";
                }
                else {
                    errores += cl.validaCupo(Int32.Parse(this.txtCupo.Text));
                    errores += cl.validaAnioCalendario(Int32.Parse(this.txtAnioCalendario.Text));
                }                                
                if (!Modo.ToString().Equals("Baja") && (cl.validaCursoExistente((int)this.cmbMaterias.SelectedValue, (int)this.cmbComisiones.SelectedValue, Int32.Parse(this.txtAnioCalendario.Text))) && (CursoActual.IDMateria != (int)this.cmbMaterias.SelectedValue || CursoActual.IDComision != (int)this.cmbComisiones.SelectedValue || CursoActual.AnioCalendario != Int32.Parse(this.txtAnioCalendario.Text)))
                {
                    errores += "Ya existe un curso con esas caracteristicas\n";
                }
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

    }
}
