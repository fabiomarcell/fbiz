using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fbiz.model;
using fbiz.repository;
namespace fbiz.business
{
    public class ProdutoBusiness {
        public IEnumerable<Produto> listarProdutos(Int32 page, Int32 itens,  dynamic filter = null ) {
            return new ProdutoRepository( ).listar( page, itens, filter );
        }

        public Produto getProdutoByID( Int32 id) {
            return new ProdutoRepository( ).getProdutoByID( id );
        }
    }
}
