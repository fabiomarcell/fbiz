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
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index( Int32 id = 0 ) {
            ViewData[ "id" ] = id;
            return View( ViewData );
        }

        public ActionResult Categoria( Int32 id = 0 ) {
            ViewData[ "id" ] = id;
            return View( "Index", id);
        }

        [HttpPost]
        public String Listar( Int32 page = 1, Int32 itens = 10 ) {
            page = Convert.ToInt32( Request[ "page" ] );
            itens = Convert.ToInt32( Request[ "itens" ] );

            List<Produto> p = new List<Produto>( );
            if( Request[ "categoria" ] != null) {
                var filter = new { fCategoria = Request["categoria"] };
                p = new ProdutoBusiness().listarProdutos( page, itens, filter ).ToList();
            }
            else{
                p = new ProdutoBusiness( ).listarProdutos( page, itens ).ToList( );
            }

            String HTML = "";
            foreach(var item in p){
            HTML += "<div class='col-md-3 col-sm-6 to-do-item'>" +
                    "<div class='clearfix'></div>" +
                    "<div class='to-do-caption'>" +
                        "<h4><a href=\"/Produto/Detalhe/" + item.produtoID + "\">" + item.nome + "</a></h4>" +
                        "<h4>" + item.categoria.nome + "</h4>" +
                        "<div class='clearfix'></div>" +
                        "<br />" +
                        "<hr>" +
                        "<p class='text-muted pull-center' style='margin-right:20px;'>" + item.dataCadastro + "</p>" +
                        "<div class='clearfix'></div>" +
                        "<hr>" +
                        "<p class='text-muted'><a href=\"/Produto/Detalhe/" + item.produtoID + "\">Detalhes</a></p>" +
                        "<div class='clearfix'></div>" +

                    "</div>" +
                "</div>";
            }
            
            if(p.Count() > 0){ 
                return new JavaScriptSerializer( ).Serialize(
                                new {
                                    html = HTML,
                                    status = "true",
                                    totalItens = p.Count(),
                                    page = page + 1
                                }
                            );
            }
            else{
                return new JavaScriptSerializer( ).Serialize(
                                new {
                                    message = "Nenhum produto encontrado...",
                                    status = false,
                                    page = 1
                                }
                            );
            }
        }
    }
}