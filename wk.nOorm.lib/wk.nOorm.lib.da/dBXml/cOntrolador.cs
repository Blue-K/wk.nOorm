using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace wk.nOorm.lib.da.dBXml
{
    public class cOntrolador
    {
        public void gRabar(string name, string value)
        {
            eNcriptador _encriptador = new eNcriptador();
            
            XmlDocument _xmlDocument = new XmlDocument();
            
            _xmlDocument.Load("wk.nOorm.db.xml");
            XmlElement _xmlElement = _xmlDocument.CreateElement(_encriptador.eNcriptar(name));
            _xmlElement.InnerText = _encriptador.eNcriptar(value);
            _xmlDocument.AppendChild(_xmlElement);
            _xmlDocument.Save("wk.nOorm.db.xml");
        }

        public void gRabar<T>(T objeto)
        {
            XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));

            if (File.Exists("wk.nOorm.db.xml"))
            {
                File.Delete("wk.nOorm.db.xml");

            }
            using (StreamWriter _streamWriter = new StreamWriter("wk.nOorm.db.xml"))
            {
                _xmlSerializer.Serialize(_streamWriter, objeto);
            }
        }

        public T Listar<T>()
        {
            T _resultado = default(T);

            if (File.Exists("wk.nOorm.db.xml"))
            {
                using (StreamReader _streamReader = new StreamReader("wk.nOorm.db.xml"))
                {
                    XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));
                    _resultado = (T)_xmlSerializer.Deserialize(_streamReader);
                }
            }

            return _resultado;
        }


        public List<ei.dBXml.cOnexion> lIstar()
        {
            List<ei.dBXml.cOnexion> _resultado = new List<ei.dBXml.cOnexion>();

            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.Load("wk.nOorm.db.xml");
            //_xmlDocument.el

            //_xmlDocument.n

            return _resultado;
        }

        public ei.dBXml.cOnexion oBtener()
        {
            ei.dBXml.cOnexion _resultado = new ei.dBXml.cOnexion();



            return _resultado;
        }
    }
}
