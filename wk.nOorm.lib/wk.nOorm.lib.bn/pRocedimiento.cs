using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace wk.nOorm.lib.bn
{
    public class pRocedimiento
    {
        private Font _fuenteRegular;
        private Font _fuenteBold;
        private int _cantidadLetrasParametro;
        private int _cantidadLetrasTipoParametro;

        public pRocedimiento()
        {
            FontFamily _familiaFuente = new FontFamily(System.Drawing.Text.GenericFontFamilies.Monospace);
            this._fuenteRegular = new Font(_familiaFuente, 10, FontStyle.Regular);
            this._fuenteBold = new Font(_familiaFuente, 10, FontStyle.Bold);
            this._cantidadLetrasParametro = 30;
            this._cantidadLetrasTipoParametro = 12;
        }

        public void CrearInsert(RichTextBox richTextBox, ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            da.cOlumna _daColumna = new da.cOlumna();

            List<ei.cOlumna> _cOlumnas = _daColumna.Listar(tabla, dataAccess);

            this.escribirCabecera(richTextBox, tabla, _cOlumnas, "rEgistrar");

            this.escribirCuerpoInsert(richTextBox, tabla, _cOlumnas);
        }

        public void CrearUpdate(RichTextBox richTextBox, ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            da.cOlumna _daColumna = new da.cOlumna();

            List<ei.cOlumna> _cOlumnas = _daColumna.Listar(tabla, dataAccess);

            this.escribirCabecera(richTextBox, tabla, _cOlumnas, "aCtualizar");

            this.escribirCuerpoUpdate(richTextBox, tabla, _cOlumnas);
        }

        public void CrearGet(RichTextBox richTextBox, ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            da.cOlumna _daColumna = new da.cOlumna();

            List<ei.cOlumna> _cOlumnas = _daColumna.Listar(tabla, dataAccess);

            this.escribirCabeceraGet(richTextBox, tabla, _cOlumnas, "oBtener");

            this.escribirCuerpoGet(richTextBox, tabla, _cOlumnas);
        }

        /*
        public string CrearSelect(ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            da.cOlumna _daColumna = new da.cOlumna();

            List<ei.cOlumna> _cOlumnas = _daColumna.Listar(tabla, dataAccess);

            StringBuilder _resultado = new StringBuilder();

            _resultado.AppendFormat("CREATE PROCEDURE [{0}].lIstar_{1} ", tabla.eSquema, tabla.nOmbre).AppendLine();
            _resultado.AppendFormat(" ({0}) ", this.CrearParametros(_cOlumnas)).AppendLine();
            _resultado.AppendFormat(" AS SELECT {0} ", this.CrearCampos(_cOlumnas)).AppendLine();
            _resultado.AppendFormat(" FROM [{0}].[{1}]; ", tabla.eSquema, tabla.nOmbre).AppendLine();

            return _resultado.ToString();
        }

        public string CrearObtener(ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            da.cOlumna _daColumna = new da.cOlumna();

            List<ei.cOlumna> _cOlumnas = _daColumna.Listar(tabla, dataAccess);

            StringBuilder _resultado = new StringBuilder();

            _resultado.AppendFormat("CREATE PROCEDURE [{0}].Obtener_{1} ", tabla.eSquema, tabla.nOmbre).AppendLine();
            _resultado.AppendFormat(" ({0}) ", this.CrearParametros(_cOlumnas)).AppendLine();
            _resultado.AppendFormat(" AS SELECT {0} ", this.CrearCampos(_cOlumnas)).AppendLine();
            _resultado.AppendFormat(" FROM [{0}].[{1}] ", tabla.eSquema, tabla.nOmbre).AppendLine();
            _resultado.AppendFormat(" WHERE {0};", this.CrearFiltros(_cOlumnas)).AppendLine();

            return _resultado.ToString();
        }
        
        private string CrearParametros(List<ei.cOlumna> columnas)
        {
            StringBuilder _resultado = new StringBuilder();

            foreach (var columna in columnas)
            {
                _resultado.AppendFormat("@{0} {1}", columna.nOmbre, columna.tIpo).AppendLine();
                if (!this.esUltimaColumna(columna, columnas))
                {
                    _resultado.Append(",");
                }
                
            }
            
            return _resultado.ToString();
        }
        */
        private void CrearParametros(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < columnas.Count; i++)
            {
                if (i == 0)
                {
                    _stringBuilder.AppendFormat("      @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' '));
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }
                else
                {
                    this.escribirTextoNormal(richTextBox, ",", Color.Blue);

                    _stringBuilder.AppendFormat("     @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' '));
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }

                _stringBuilder.AppendFormat("{0}", this.cOmpletar(columnas[i].tIpo, this._cantidadLetrasTipoParametro, ' '));

                if (columnas[i].cAracteres == 0)
                {
                    _stringBuilder.AppendLine();
                }
                this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.LightSeaGreen);
                _stringBuilder.Clear();

                if (columnas[i].cAracteres > 0)
                {
                    _stringBuilder.AppendFormat("({0})", columnas[i].cAracteres).AppendLine();
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }                
            }
        }

        private void CrearParametrosGet(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].eSLlavePrimaria)
                {
                    if (i == 0)
                    {
                        _stringBuilder.AppendFormat("      @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' '));
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }
                    else
                    {
                        this.escribirTextoNormal(richTextBox, ",", Color.Blue);

                        _stringBuilder.AppendFormat("     @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' '));
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }

                    _stringBuilder.AppendFormat("{0}", this.cOmpletar(columnas[i].tIpo, this._cantidadLetrasTipoParametro, ' '));

                    if (columnas[i].cAracteres == 0)
                    {
                        _stringBuilder.AppendLine();
                    }
                    this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.LightSeaGreen);
                    _stringBuilder.Clear();

                    if (columnas[i].cAracteres > 0)
                    {
                        _stringBuilder.AppendFormat("({0})", columnas[i].cAracteres).AppendLine();
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }
                }
            }
        }

        //private string CrearCampos(List<ei.cOlumna> columnas)
        //{
        //    StringBuilder _resultado = new StringBuilder();

        //    foreach (var columna in columnas)
        //    {
        //        _resultado.AppendFormat("{0}", columna.nOmbre).AppendLine();
        //        if (!this.esUltimaColumna(columna, columnas))
        //        {
        //            _resultado.Append(",");
        //        }
        //    }

        //    return _resultado.ToString();
        //}

        private void CrearCampos(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < columnas.Count; i++)
            {
                if (i == 0)
                {
                    _stringBuilder.AppendFormat("     {0}", columnas[i].nOmbre).AppendLine();
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }
                else
                {
                    this.escribirTextoNormal(richTextBox, ",", Color.Blue);

                    _stringBuilder.AppendFormat("    {0}", columnas[i].nOmbre).AppendLine();
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }
            }
        }

        //private string CrearValores(List<ei.cOlumna> columnas)
        //{
        //    StringBuilder _resultado = new StringBuilder();

        //    foreach (var columna in columnas)
        //    {
        //        _resultado.AppendFormat("@{0}", columna.nOmbre).AppendLine();
        //        if (!this.esUltimaColumna(columna, columnas))
        //        {
        //            _resultado.Append(",");
        //        }
        //    }

        //    return _resultado.ToString();
        //}

        private void CrearValores(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < columnas.Count; i++)
            {
                if (i == 0)
                {
                    _stringBuilder.AppendFormat("     @{0}", columnas[i].nOmbre).AppendLine();
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }
                else
                {
                    this.escribirTextoNormal(richTextBox, ",", Color.Blue);

                    _stringBuilder.AppendFormat("    @{0}", columnas[i].nOmbre).AppendLine();
                    this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                    _stringBuilder.Clear();
                }
            }
        }

        //private string CrearAsignaciones(List<ei.cOlumna> columnas)
        //{
        //    StringBuilder _resultado = new StringBuilder();

        //    foreach (var columna in columnas)
        //    {
        //        if (!columna.eSLlavePrimaria)
        //        {
        //            _resultado.AppendFormat("{0} = @{0}", columna.nOmbre).AppendLine();
        //            if (!this.esUltimaColumna(columna, columnas))
        //            {
        //                _resultado.Append(",");
        //            }
        //        }
        //    }

        //    return _resultado.ToString();
        //}

        private void CrearAsignaciones(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < columnas.Count; i++)
            {
                if (!columnas[i].eSLlavePrimaria)
                {
                    if (i == 0)
                    {
                        _stringBuilder.AppendFormat("     {0} = @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' ')).AppendLine();
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }
                    else
                    {
                        this.escribirTextoNormal(richTextBox, ",", Color.Blue);

                        _stringBuilder.AppendFormat("    {0} = @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' ')).AppendLine();
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }
                }
            }
        }

        private string CrearFiltros(List<ei.cOlumna> columnas)
        {
            StringBuilder _resultado = new StringBuilder();

            bool nOesPrimeraLlave = false;

            foreach (var columna in columnas)
            {
                if (columna.eSLlavePrimaria)
                {
                    if (nOesPrimeraLlave)
                    {
                        _resultado.Append(" AND ");
                    }
                    _resultado.AppendFormat("{0} = @{0}", columna.nOmbre).AppendLine();
                    nOesPrimeraLlave = true;
                }
            }

            return _resultado.ToString();
        }

        private void CrearFiltros(RichTextBox richTextBox, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            bool esPrimeraLlave = true;

            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].eSLlavePrimaria)
                {
                    if (esPrimeraLlave)
                    {
                        _stringBuilder.AppendFormat("     {0} = @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' ')).AppendLine();
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                        esPrimeraLlave = false;
                    }
                    else
                    {
                        this.escribirTextoNormal(richTextBox, "AND ", Color.Blue);

                        _stringBuilder.AppendFormat(" {0} = @{0}", this.cOmpletar(columnas[i].nOmbre, this._cantidadLetrasParametro, ' ')).AppendLine();
                        this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
                        _stringBuilder.Clear();
                    }
                }
            }
        }

        //private bool esUltimaColumna(ei.cOlumna columna, List<ei.cOlumna> columnas)
        //{
        //    if (columnas.IndexOf(columna) == columnas.Count - 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private string cOmpletar(string texto, int cantidad, char caracter)
        {
            string _resultado = texto;
            for (int i = 0; i < cantidad-texto.Length; i++)
            {
                _resultado = _resultado + caracter;
            }
            return _resultado;
        }

        private void escribirTextoNormal(RichTextBox richTextBox, string texto, Color color)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionFont = this._fuenteRegular;
            richTextBox.SelectionColor = color;
            richTextBox.AppendText(texto);
        }

        private void escribirTextoNegrita(RichTextBox richTextBox, string texto, Color color)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionFont = this._fuenteBold;
            richTextBox.SelectionColor = color;
            richTextBox.AppendText(texto);
        }

        private void escribirCabecera(RichTextBox richTextBox, ei.tAbla tabla, List<ei.cOlumna> columnas, string accion)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            _stringBuilder.Append("CREATE PROCEDURE ");
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("[{0}].{1}_{2}", tabla.eSquema, accion, tabla.nOmbre).AppendLine();
            this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
            _stringBuilder.Clear();

            _stringBuilder.Append("(").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearParametros(richTextBox, columnas);

            _stringBuilder.Append(")").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();
        }

        private void escribirCabeceraGet(RichTextBox richTextBox, ei.tAbla tabla, List<ei.cOlumna> columnas, string accion)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            _stringBuilder.Append("CREATE PROCEDURE ");
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("[{0}].{1}_{2}", tabla.eSquema, accion, tabla.nOmbre).AppendLine();
            this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
            _stringBuilder.Clear();

            _stringBuilder.Append("(").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearParametrosGet(richTextBox, columnas);

            _stringBuilder.Append(")").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();
        }

        private void escribirCuerpoInsert(RichTextBox richTextBox, ei.tAbla tabla, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append("AS INSERT INTO ");
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("[{0}].[{1}]", tabla.eSquema, tabla.nOmbre).AppendLine();
            this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
            _stringBuilder.Clear();

            _stringBuilder.Append("(").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearCampos(richTextBox, columnas);

            _stringBuilder.Append(")").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.Append("VALUES ").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.Append("(").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearValores(richTextBox, columnas);

            _stringBuilder.Append(");").AppendLine().AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();
        }

        private void escribirCuerpoUpdate(RichTextBox richTextBox, ei.tAbla tabla, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(" AS UPDATE ");
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("[{0}].[{1}]", tabla.eSquema, tabla.nOmbre).AppendLine();
            this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
            _stringBuilder.Clear();

            _stringBuilder.Append(" SET ").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearAsignaciones(richTextBox, columnas);

            _stringBuilder.Append(" WHERE ").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearFiltros(richTextBox, columnas);

            _stringBuilder.Append(";").AppendLine().AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();
        }

        private void escribirCuerpoGet(RichTextBox richTextBox, ei.tAbla tabla, List<ei.cOlumna> columnas)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(" AS SELECT ").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearCampos(richTextBox, columnas);

            _stringBuilder.Append(" FROM ");
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("[{0}].[{1}]", tabla.eSquema, tabla.nOmbre).AppendLine();
            this.escribirTextoNegrita(richTextBox, _stringBuilder.ToString(), Color.Black);
            _stringBuilder.Clear();

            _stringBuilder.Append(" WHERE ").AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();

            this.CrearFiltros(richTextBox, columnas);

            _stringBuilder.Append(";").AppendLine().AppendLine();
            this.escribirTextoNormal(richTextBox, _stringBuilder.ToString(), Color.Blue);
            _stringBuilder.Clear();
        }
    }
}
