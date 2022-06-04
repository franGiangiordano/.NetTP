using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Este formulario fue hecho para un laboratorio pero sirve también para el TP2


namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        /* este metodo debe ser reemplazado por un método que solicite a la capa de negocio recupere el        
           usuario con nombre igual al ingresado en el txtUsuario y si existe invocar a un método que 
           valide si su contraseña coincide con la ingresada en txtPass*/
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

           private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
