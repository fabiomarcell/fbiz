using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.model {
    public class Categoria {
        public Int32 categoriaID { get; set; }
        public String nome { get; set; }
        public DateTime dataCadastro { get; set; }
        public Int32 ativo { get; set; }
    }
}
