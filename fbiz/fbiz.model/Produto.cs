using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.model {
    public class Produto {
        public Int32 produtoID { get; set; }
        public Int32 categoriaID { get; set; }
        public Categoria categoria { get; set; }
        public String nome { get; set; }
        public String descricao { get; set; }
        public DateTime dataCadastro { get; set; }
        public Int32 ativo { get; set; }
    }
}
