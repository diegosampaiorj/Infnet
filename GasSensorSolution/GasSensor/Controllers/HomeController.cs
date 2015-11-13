using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasSensor.Utilities;

namespace GasSensor.Controllers
{
    /// <summary>
    /// Controlador principal
    /// </summary>
    public class HomeController : Controller
    {
        // Instanciando a classe que faz a lógica do envio de e-mail.
        SendMail eMail = new SendMail();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        // GET: Simulator
        public ActionResult Simulator()
        {
            // Inicia o gerador randomico de números
            Random rnd = new Random();

            // Gera um numero aleatório de 0 a 10
            int grauVazamento = rnd.Next(0, 10);

            // Caso o teor de vazamento de gás seja maior que 1 será disparado um e-mail avisando que está ocorrendo um vazamento de gás
            if (grauVazamento > 1)
            {
                // Fecha a valvula do sistema de vazamento de gás
                grauVazamento = 0 ;

                // Redirecionado para a ação de enviar o e-mail
                return RedirectToAction("SendMail");

            }
            else
            {
                // Redireciona de volta para a pagina principal
                return RedirectToAction("Index");
            }

        }

        // GET: SendMail
        public ActionResult SendMail()
        {
            // Instancia o método de envio de e-mail.
            eMail.SendMessage();

            // Vai para a view correspondente.
            return View();
        }
    }
}