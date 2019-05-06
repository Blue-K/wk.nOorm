using System.Collections.Generic;

namespace wk.nOorm.lib.ei
{
    public class pRocedimiento
    {
        public string nOmbre { get; set; }
        public string tIpo { get; set; }
        public List<pArametro> fIltros { get; set; }
        public List<pArametro> mIxtos { get; set; }
        public List<pArametro> aCtualizadores { get; set; }
    }
}
