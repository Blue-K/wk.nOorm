using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wk.nOorm.frm.ui
{
    public partial class cOnexion : Form
    {
        private List<lib.ei.dBXml.cOnexion> _cOnexiones;
        internal lib.da.dAtaAccess aCcesoDatos;
        private lib.ei.dBXml.cOnexion eNtidad;

        public cOnexion()
        {
            lib.bn.cOnexion _cOnexion = new lib.bn.cOnexion();
            this._cOnexiones = _cOnexion.lIstar();
            this.eNtidad = new lib.ei.dBXml.cOnexion();
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            this.eNtidad.nOmbre = this.cmbId.Text;
            this.eNtidad.sErvidor = this.txtServidor.Text;
            this.eNtidad.bAseDatos = this.txtBaseDatos.Text;
            this.eNtidad.uSuario = this.txtUsuario.Text;
            this.eNtidad.cOntrasenia = this.txtContrasenia.Text;

            try
            {
                this.aCcesoDatos = new lib.da.dAtaAccess(this.eNtidad);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar, verifique los datos por favor");
            }
        }

        private void cOnexion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void cOnexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lib.ei.dBXml.cOnexion _cOnexion = new lib.ei.dBXml.cOnexion();

            _cOnexion.nOmbre = this.cmbId.Text;
            _cOnexion.sErvidor = this.txtServidor.Text;
            _cOnexion.bAseDatos = this.txtBaseDatos.Text;
            _cOnexion.uSuario = this.txtUsuario.Text;
            _cOnexion.cOntrasenia = this.txtContrasenia.Text;
              
            this._cOnexiones.Add(_cOnexion);

            lib.bn.cOnexion _conexion = new lib.bn.cOnexion();
            _conexion.gRabar(this._cOnexiones);
        }

        private void cOnexion_Load(object sender, EventArgs e)
        {
            this.cArgarComboConexiones();
        }

        private void cArgarComboConexiones()
        {
            foreach (var item in this._cOnexiones)
            {
                this.cmbId.Items.Add(item.nOmbre);
            }
        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            lib.ei.dBXml.cOnexion _cOnexion = this._cOnexiones[this.cmbId.SelectedIndex];
            this.cmbId.Text = _cOnexion.nOmbre;
            this.txtServidor.Text = _cOnexion.sErvidor;
            this.txtBaseDatos.Text = _cOnexion.bAseDatos;
            this.txtUsuario.Text = _cOnexion.uSuario;
            this.txtContrasenia.Text = _cOnexion.cOntrasenia;
        }
    }
}
