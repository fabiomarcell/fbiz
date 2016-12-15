using fbiz.business;
using fbiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace fbiz.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String Listar() {
            String HTML = "";

            ComentarioBusiness cb = new ComentarioBusiness( );
            List<Comentario> c = new List<Comentario>( );
            c = cb.getComentarios( Convert.ToInt32(Request[ "id" ]) ).ToList( );

            if( c.Count( ) > 0 ) {
                foreach( var item in c ) {

                    HTML += "<h4>" + item.titulo + "</h4>" +
                                "<p class=\"text-muted\">" + item.descricao + "</p>" +
                                "<span> - " + item.nome + "</span>" +
                                "<hr />";
                }
            }
            else {
                HTML = "<h4>Nenhum Comentário Encontrado!</h4>";
            }

            return new JavaScriptSerializer( ).Serialize(
                            new {
                                html = HTML,
                                status = "true"
                            }
                        );;
        }

        [HttpPost]
        public String Cadastrar( ) {
            ComentarioBusiness cb = new ComentarioBusiness( );
            Comentario c = new Comentario( );

            c.ativo = true;
            c.produtoID = Int32.Parse( Request[ "produtoID" ] );
            c.dataCadastro = DateTime.Now;
            c.titulo = Request[ "titulo" ];
            c.nome = Request[ "autor" ];
            c.descricao = Request[ "descricao" ];

            if( cb.validar(c ) ) {
                if( cb.cadastrar( c ) ) {
                    return new JavaScriptSerializer( ).Serialize(
                    new {
                        status = "true"
                    });
                }
                else {
                    return new JavaScriptSerializer( ).Serialize(
                    new {
                        status = "false",
                        message = "Erro ao cadastrar"
                    });                
                }
            }
            else {
                return new JavaScriptSerializer( ).Serialize(
                    new {
                        status = "false",
                        message = cb.err
                    }); ;
            }

           
        }
    }
}