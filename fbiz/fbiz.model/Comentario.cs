using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.model {
    public class Comentario {
        public Int32 comentarioID { get; set; }
        public Int32 produtoID { get; set; }
        public String nome { get; set; }
        public String titulo { get; set; }
        public String descricao { get; set; }
        public DateTime dataCadastro { get; set; }
        public Boolean ativo { get; set; }

    }
}
