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
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre.ToString();
            this.txtApellido.Text = this.UsuarioActual.Apellido.ToString();
            this.txtEmail.Text = this.UsuarioActual.Email.ToString();
            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Usuario usuarioNuevo = new Usuario();
                    this.copiarDatos();
                    UsuarioActual.State = Business.Entities.Usuario.States.New;
                    break;
                case ModoForm.Modificacion:
                    this.copiarDatos();
                    this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                    UsuarioActual.State = Usuario.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = Usuario.States.Delete;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = Usuario.States.Unmodified;
                    break;
            }
        }
        public void copiarDatos()
        {
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Email = this.txtEmail.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic u = new UsuarioLogic();
            /*if (this.Modo==ModoForm.Baja) {
                u.Delete(UsuarioActual.ID);
            } else {*/
                u.Save(UsuarioActual);
           //}
        }
        public override bool Validar()
        {
            if (this.txtNombre.Text == "")
            {
                return false;
            }
            if (this.txtApellido.Text == "")
            {
                return false;
            }
            if (this.txtEmail.Text != "")
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(this.txtEmail.Text);
                    return addr.Address == this.txtEmail.Text;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (this.txtUsuario.Text == "")
            {
                return false;
            }
            if (this.txtClave.Text != "" && this.txtClave.Text.Length>=8)
            {
                if (this.txtConfirmarClave.Text != "")
                {
                    if (!this.txtConfirmarClave.Text.Equals(this.txtClave.Text))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }   
            }
            else
            {
                return false;
            }
            
            return true;

        }

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            UsuarioActual = new Usuario();
            this.Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            this.UsuarioActual = usuario.GetOne(ID);
            this.MapearDeDatos();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
