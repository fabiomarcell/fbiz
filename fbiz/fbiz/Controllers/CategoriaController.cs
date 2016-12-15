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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public String Listar( ) {
            List<Categoria> c = new List<Categoria>( );
            c = new CategoriaBusiness( ).Listar().ToList();
            String HTML = "";

            if( c.Count( ) > 0 ) {
                foreach( var item in c ) {
                    HTML += "<a href=\"javascript:void(0);\" onclick=\"setFilter('" + item.categoriaID + "')\">" + item.nome + "</a> | ";
                }
                return new JavaScriptSerializer( ).Serialize(
                                new {
                                    html = HTML,
                                    status = true
                                }
                            );
            }
            else {
                return new JavaScriptSerializer( ).Serialize(
                                new {
                                    status = false,
                                    message = "Nenhuma categoria cadastrada..."
                                }
                            );
            }
        }
    }
}