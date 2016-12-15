using fbiz.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fbiz.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Detalhe( Int32 id ) {
            ProdutoBusiness pb = new ProdutoBusiness( );

            return View(pb.getProdutoByID(id));
        }

        public ActionResult Cadastrar( ) {
            ProdutoBusiness pb = new ProdutoBusiness( );

            return View( );
        }
    }
}