using fbiz.DataAccess;
using fbiz.model;
using fbiz.repository.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbiz.repository {
    public class ComentarioRepository : IComentarioRepository<Comentario>{
        public List<Comentario> listar(Int32 id ) {
            List<Comentario> coment = new List<Comentario>( );

            try {
                using( var con = new fbizEntities( ) ) {
                    var query = from C in con.comentario
                                where C.ativo == true
                                && C.produtoID == id
                                orderby C.nome ascending
                                select C;

                    foreach( var item in query ) {
                        coment.Add( new Comentario( ) { 
                            comentarioID = item.comentarioID,
                            produtoID = Convert.ToInt32(item.produtoID),
                            nome = item.nome,
                            titulo = item.titulo,
                            descricao = item.descricao,
                            dataCadastro = Convert.ToDateTime(item.dataCadastro),
                            ativo = Convert.ToBoolean(item.ativo)
                            
                        });
                    }
                }
            }
            catch( Exception e ) {
                throw e;
            }
            return coment;
        }

        public Boolean cadastrar( Comentario c ) {

            try {
                using( var con = new  fbizEntities()) {
                    var tblComentario = new comentario( );
                    tblComentario.produtoID = c.produtoID;
                    tblComentario.nome = c.nome;
                    tblComentario.titulo = c.titulo;
                    tblComentario.descricao = c.descricao;
                    tblComentario.dataCadastro = c.dataCadastro;
                    tblComentario.ativo = c.ativo;

                    //prepara para insert na tabela
                    con.comentario.Add( tblComentario );
                    //insere no banco(insert into ...)
                    con.SaveChanges( );

                    return true;
                }
            }
            catch( Exception e) {
                throw e;
                return false;
            }
        }
    }
}
