using fbiz.DataAccess;
using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository {
    public class CategoriaRepository {
        public List<Categoria> listar( ) {
            List<Categoria> cat = new List<Categoria>( );

            try {
                using( var con = new fbizEntities( ) ) {
                    var query = from C in con.categoria
                                where C.ativo == true
                                orderby C.nome ascending
                                select C;

                    foreach( var item in query ) {
                        cat.Add( new Categoria( ) {
                            categoriaID = item.categoriaID,
                            nome = item.nome,
                            dataCadastro = Convert.ToDateTime(item.dataCadastro),
                            ativo = (item.ativo == true ? 1 : 0)
                        } );
                    }
                }
            }
            catch( Exception e ) {
                throw e;
            }
            return cat;
        }
    }
}
