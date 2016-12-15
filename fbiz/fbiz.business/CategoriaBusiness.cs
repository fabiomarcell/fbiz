using fbiz.model;
using fbiz.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.business {
    public class CategoriaBusiness {
        public IEnumerable<Categoria> Listar( ) {
            return new CategoriaRepository( ).listar( );
        }
    }
}
