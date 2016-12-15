using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository.contracts {
    public interface IProdutoRepository <TEntity>  where TEntity : class{
        IEnumerable<Produto> listar( Int32 page, Int32 itens, dynamic filter = null );
        Produto getProdutoByID( Int32 id );
    }
}
