using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace wk.nOorm.frm.ui
{
    public partial class pRincipal : Form
    {
        private lib.da.dAtaAccess _dAtaAcces;
        private List<lib.ei.tAbla> _tAblas;

        public pRincipal(lib.da.dAtaAccess dAtaAccess)
        {
            this._dAtaAcces = dAtaAccess;
            InitializeComponent();
        }

        private void AgregarNodos()
        {
            foreach (var item in this._tAblas)
            {
                TreeNode _nodeTabla = new TreeNode(item.eSquema+"."+item.nOmbre);
                _nodeTabla.Checked = true;

                TreeNode _nodeSQL = new TreeNode("SQL");
                _nodeSQL.Checked = true;

                TreeNode _nodeInsert = new TreeNode("Insert");
                _nodeInsert.Checked = true;

                TreeNode _nodeUpdate = new TreeNode("Update");
                _nodeUpdate.Checked = true;

                TreeNode _nodeGet = new TreeNode("Get");
                _nodeGet.Checked = true;

                //TreeNode _nodeCSharp = new TreeNode("C#");
                //_nodeCSharp.Checked = true;

                //TreeNode _nodeSelect = new TreeNode("Select");
                //_nodeSelect.Checked = true;

                _nodeSQL.Nodes.Add(_nodeInsert);
                _nodeSQL.Nodes.Add(_nodeUpdate);
                //_nodeTabla.Nodes.Add(_nodeSelect);
                _nodeSQL.Nodes.Add(_nodeGet);

                _nodeTabla.Nodes.Add(_nodeSQL);


                this.tvwTablas.Nodes.Add(_nodeTabla);
            }
        }

        private void tvwTablas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lib.bn.pRocedimiento _pRocedimiento = new lib.bn.pRocedimiento();
            this.rtbConsulta.Clear();

            

            switch (e.Node.Level)
            {
                case 1:

                    TreeNode padre = e.Node.Parent;

                    _pRocedimiento.CrearInsert(this.rtbConsulta, this._tAblas[padre.Index], this._dAtaAcces);

                    _pRocedimiento.CrearUpdate(this.rtbConsulta, this._tAblas[padre.Index], this._dAtaAcces);

                    _pRocedimiento.CrearGet(this.rtbConsulta, this._tAblas[padre.Index], this._dAtaAcces);

                    break;
                    
                case 2:

                    TreeNode abuelo = e.Node.Parent.Parent;

                    switch (e.Node.Text)
                    {
                        case "Insert":
                            _pRocedimiento.CrearInsert(this.rtbConsulta, this._tAblas[abuelo.Index], this._dAtaAcces);
                            break;
                        case "Update":
                            _pRocedimiento.CrearUpdate(this.rtbConsulta, this._tAblas[abuelo.Index], this._dAtaAcces);
                            break;
                        //case "Select":
                        //    this.rtbConsulta.Text = _pRocedimiento.CrearSelect(this._tAblas[parent.Index], this._dAtaAcces);
                        //    break;
                        case "Get":
                            _pRocedimiento.CrearGet(this.rtbConsulta, this._tAblas[abuelo.Index], this._dAtaAcces);
                            break;

                    }
                    break;
            }
        }

        private void btnDeseleccionarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {

        }

        private void pRincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._dAtaAcces != null)
            {
                this._dAtaAcces.Dispose();
            }
        }

        private void pRincipal_Load(object sender, EventArgs e)
        {
            lib.da.tAbla _tabla = new lib.da.tAbla();
            this._tAblas = _tabla.Listar(this._dAtaAcces);
            this.AgregarNodos();
        }
    }
}
