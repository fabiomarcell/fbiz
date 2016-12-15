using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository.contracts {
    interface IComentarioRepository <TEntity> where TEntity : class {
        List<Comentario> listar( Int32 id );
        Boolean cadastrar ( Comentario c );
    }
}
