using fbiz.DataAccess;
using fbiz.model;
using fbiz.repository.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository
{
    public class ProdutoRepository : IProdutoRepository <Produto>{
        public IEnumerable<Produto> listar(Int32 page, Int32 itens, dynamic filter = null) {
            List<Produto> p = new List<Produto>( );
        
            try {
                using( var con = new fbizEntities() ) {
                    var query = from P in con.produto
                                join C in con.categoria on P.categoriaID equals C.categoriaID
                                where P.ativo == true
                                orderby P.nome ascending
                                select P;

                    Int32 fCategoria = 0;

                    if(filter != null){

                        if( filter.GetType( ).GetProperty( "fCategoria" ) != null ) {

                            fCategoria = Convert.ToInt32(filter.GetType( ).GetProperty( "fCategoria" ).GetValue( filter, null ));
                            if(fCategoria != 0){
                                query = from P in con.produto
                                        join C in con.categoria on P.categoriaID equals C.categoriaID
                                        where P.ativo == true
                                        && P.categoriaID == fCategoria
                                        orderby P.nome ascending
                                        select P;
                            }
                        }
                    }

                    foreach( var item in query.Skip((page-1)*itens).Take(itens) ) {
                        p.Add( new Produto( ) {
                            produtoID = item.produtoID,
                            categoriaID = Convert.ToInt32( item.categoriaID ),
                            nome = item.nome,
                            descricao = item.descricao,
                            dataCadastro = Convert.ToDateTime( item.dataCadastro ),
                            ativo = ( item.ativo == true ? 1 : 0 ),
                            categoria = new Categoria( ) { 
                                categoriaID = item.categoria.categoriaID,
                                nome = item.categoria.nome,  
                                dataCadastro = Convert.ToDateTime(item.categoria.dataCadastro),
                                ativo = (item.categoria.ativo == true ? 1 : 0)
                            }
                        } );
                    }
                }
            }
            catch( Exception e ) {
                throw e;
            }
            return p;
        }

        public Produto getProdutoByID( Int32 id ) {
            Produto p = new Produto( );
            Categoria c = new Categoria( );
            try {
                using( var con = new fbizEntities( ) ) {
                    var query = from P in con.produto
                                join C in con.categoria on P.categoriaID equals C.categoriaID
                                where P.produtoID == id
                                orderby P.nome ascending
                                select P;

                    foreach( var item in query ) {
                        p.produtoID = item.produtoID;
                        p.categoriaID = Convert.ToInt32(item.categoriaID);
                        p.nome = item.nome;
                        p.descricao = item.descricao;
                        p.dataCadastro = Convert.ToDateTime( item.dataCadastro );
                        p.ativo = ( item.ativo == true ? 1 : 0 );
                            c.categoriaID = Convert.ToInt32( item.categoriaID);
                            c.nome = item.categoria.nome;
                            c.dataCadastro = Convert.ToDateTime(item.categoria.dataCadastro);
                            c.ativo = ( item.categoria.ativo == true ? 1 : 0 );
                            p.categoria = c;
                    }
                }
            }
            catch( Exception e ) {
                throw e;
            }
            
            return p;
        }

    }
}
