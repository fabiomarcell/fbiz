using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fbiz.repository;

namespace fbiz.business {
    public class ComentarioBusiness {
        public String err;
        public List<Comentario> getComentarios( Int32 id ) {
            return new ComentarioRepository( ).listar( id );
        }

        public Boolean cadastrar( Comentario c ) {
            return new ComentarioRepository( ).cadastrar( c );
        }

        public Boolean validar( Comentario c ) {
            if( c.nome.Trim( ) == "" ) {
                err = "Nome Inválido";
                return false;
            }

            if( c.titulo.Trim( ) == "" ) {
                err = "Título Inválido";
                return false;
            }

            if( c.descricao.Trim( ) == "" ) {
                err = "Descrição inválida";
                return false;
            }

            if( c.produtoID == 0 ) {
                err = "Produto Inválido";
                return false;
            }

            return true;
        }
    }
}
