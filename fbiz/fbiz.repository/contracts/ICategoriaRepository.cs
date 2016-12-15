using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository.contracts {
    interface ICategoriaRepository <TEntity> where TEntity : class {
        List<Categoria> Listar();
    }
}
