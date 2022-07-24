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
    public partial class UsuarioDesktop : ApplicationForm
    {

        private Business.Entities.Usuario usuarioActual;

        public Usuario UsuarioActual { get => usuarioActual; set => usuarioActual = value; }

        public UsuarioDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            InitializeComponent();
            cargarComboLegajos();
        }
        public UsuarioDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            InitializeComponent();
            cargarComboLegajos();
            Modo = (ApplicationForm.ModoForm)modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();            
        }

        private void cargarComboLegajos()
        {
            PersonaLogic pl = new PersonaLogic();
            List <Persona> legajos = pl.GetLegajos();            
            this.cmbLegajos.DataSource = legajos;
            this.cmbLegajos.DisplayMember = "Legajo";
            this.cmbLegajos.ValueMember = "ID";
        }

        //public UsuarioDesktop(ApplicationForm.ModoForm alta)
        //{
        //    InitializeComponent();
        //}

        public UsuarioDesktop()
        {
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            PersonaLogic pl = new PersonaLogic();

            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.checkHab.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApe.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsu.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirm.Text = this.UsuarioActual.Clave;
            
            this.cmbLegajos.SelectedValue = this.UsuarioActual.IdPersona;
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
            PersonaLogic pl = new PersonaLogic();

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Usuario usu = new Usuario();
                    UsuarioActual = usu;
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = checkHab.Checked;
                    UsuarioActual.Apellido = txtApe.Text;
                    UsuarioActual.NombreUsuario = txtUsu.Text;
                    //_UsuarioActual.IDPersona = (pl.GetOnePorLejago(Int32.Parse(cmbLegajos.SelectedItem.ToString()))).ID;                    
                    UsuarioActual.IdPersona = (int)this.cmbLegajos.SelectedValue;
                    UsuarioActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    if (!txtClave.Text.Equals(UsuarioActual.Clave))
                    {
                        UsuarioActual.CambiaClave = true;
                        UsuarioActual.Clave = txtClave.Text;
                    }
                    else {
                        UsuarioActual.CambiaClave = false;
                    }                    

                    UsuarioActual.Habilitado = checkHab.Checked;
                    UsuarioActual.Apellido = txtApe.Text;
                    UsuarioActual.NombreUsuario = txtUsu.Text;
                    //_UsuarioActual.IDPersona = (pl.GetOnePorLejago(Int32.Parse(cmbLegajos.SelectedItem.ToString()))).ID;
                    UsuarioActual.IdPersona = (int)this.cmbLegajos.SelectedValue;
                    UsuarioActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    UsuarioActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    UsuarioActual.State = Usuario.States.Modified;
                    break;
            }
        }
        
        public override void GuardarCambios()
        {
            try
            {
                //esto es sólo en caso de que se modifique el id_persona y cambie el rol del usuario
                int idViejo = -1;
                if (Modo.ToString().Equals("Modificacion"))
                {
                    idViejo = this.UsuarioActual.IdPersona;
                }

                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                PersonaLogic pl = new PersonaLogic();
                UsuarioLogic ul = new UsuarioLogic();
                MapearADatos(); //aca ya cambio el Id

                if (Modo.ToString().Equals("Alta"))
                {

                    ul.Save(UsuarioActual);
                    Persona per = pl.GetOne(UsuarioActual.IdPersona);
                    List<ModuloUsuario> modulos = crearLista((int)per.Tipo);
                    try {
                        mul.CargarPermisos(modulos);
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                        this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                    
                }
                else if (Modo.ToString().Equals("Baja"))
                {
                    try {
                        mul.EliminarPermisos(UsuarioActual.ID);
                        ul.Save(UsuarioActual);
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al eliminar permisos", Ex);
                        this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }            
                }
                else if (Modo.ToString().Equals("Modificacion"))
                {
                    Persona perNueva = pl.GetOne(UsuarioActual.IdPersona);
                    Persona perVieja = pl.GetOne(idViejo);
                    if (perNueva.Tipo == perVieja.Tipo)
                    {
                        ul.Save(UsuarioActual);
                    }
                    else
                    {                        
                        try{
                            mul.EliminarPermisos(UsuarioActual.ID);
                            List<ModuloUsuario> modulos = crearLista((int)perNueva.Tipo);
                            mul.CargarPermisos(modulos);
                            ul.Save(UsuarioActual);
                        }
                        catch (Exception Ex)
                        {
                            Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                            this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

        }
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           
        }

        private List<ModuloUsuario> crearLista(int tipo)
        {
            List<ModuloUsuario> m = new List<ModuloUsuario>();
            for (int i = 1; i <= 7; i++) {
                ModuloUsuario modulo = new ModuloUsuario();
                if (tipo == 2) {
                    modulo.IdModulo = i;
                    modulo.IdUsuario = UsuarioActual.ID;
                    modulo.PermiteAlta = true;
                    modulo.PermiteBaja = true;
                    modulo.PermiteConsulta = true;
                    modulo.PermiteModificacion = true;
                } else if (tipo == 0)
                {
                    if (i == 1)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else if (i >= 5)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = true;
                        modulo.PermiteBaja = true;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = false;
                        modulo.PermiteModificacion = false;
                    }               
                }
                else if (tipo == 1)
                {
                    if (i == 1 || i == 5 || i == 6)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = true;
                    } else if(i==7){
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = false;
                        modulo.PermiteModificacion = false;
                    }                    
                }
                m.Add(modulo);
            }
            return m;
        }

        public override bool Validar()
        {
            string errores = "";
            UsuarioLogic ul = new UsuarioLogic();
            if ( String.IsNullOrEmpty(this.txtNombre.Text)
            || String.IsNullOrEmpty(this.txtApe.Text) || String.IsNullOrEmpty(this.txtClave.Text)
            || String.IsNullOrEmpty(this.txtConfirm.Text) || String.IsNullOrEmpty(this.txtUsu.Text)
             )
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            errores += ul.validarLongitud(txtClave.Text);
            errores += ul.validarClave(txtClave.Text, txtConfirm.Text);
            
            if (ul.IsValidMailAddress1(txtEmail.Text) == false)
            {
                errores += "El Email ingresado es invalido\n";               
            }
            if (!this.txtNombre.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
            }
            if (!this.txtApe.Text.All(Char.IsLetter))
            {
                errores += "El campo apellido solo puede contener letras\n";
            }
            if (!Modo.ToString().Equals("Baja") && ul.GetUser(txtUsu.Text)) {
                errores += "Ya existe un usuario con ese nombre de usuario\n";
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
        /*
        private bool ValidarMail(string Email)
        {
            bool arrobaFlag = false;
            bool dominioFlag = false;
            for (int i = 0; i < Email.Length; i++)
            {
                if (Email[i] == '@')
                {
                    arrobaFlag = true;
                    if (Email.Contains(".com") || Email.Contains(".net") || Email.Contains(".edu") || Email.Contains(".com.ar"))
                    {
                        dominioFlag = true;
                        break;
                    }
                    else
                        dominioFlag = false;
                }
                else
                    arrobaFlag = false;
            }
            if (arrobaFlag && dominioFlag)
                return true;
            else
                return false;
        }*/



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
            if (Validar())
            {
                try
                {
                    GuardarCambios();
                    Close();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar usuarios", Ex);
                    this.Notificar(ExcepcionManejada.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
