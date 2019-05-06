using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk.nOorm.lib.bn
{
    public class cOnexion
    {
        //public List<>
        public cOnexion()
        {

        }

        public void gRabar(List<ei.dBXml.cOnexion> conexiones)
        {
            da.dBXml.cOntrolador _cOntrolador = new da.dBXml.cOntrolador();
            _cOntrolador.gRabar(conexiones);
        }

        public List<ei.dBXml.cOnexion> lIstar()
        {
            List<ei.dBXml.cOnexion> _resultado;

            da.dBXml.cOntrolador _cOntrolador = new da.dBXml.cOntrolador();
            _resultado = _cOntrolador.Listar<List<ei.dBXml.cOnexion>>();

            if (_resultado == null)
            {
                _resultado = new List<ei.dBXml.cOnexion>();
            }

            return _resultado;
        }
    }
}