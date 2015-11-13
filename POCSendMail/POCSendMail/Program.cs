using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCSendMail
{
    class Program
    {
        

        static void Main(string[] args)
        {
            SendMail eMail = new SendMail();

           
            Console.WriteLine("Vou enviar o e-mail, aperte 1 para confirmar ou 2 para não enviar.");

            int envio = Console.Read();

            if (envio == 49)
            {
                eMail.SendMessage();

                Console.WriteLine("E-mail enviado com sucesso");
            }
            else
            {
                Console.WriteLine("Envio de e-mail cancelado");
            }
        }
    }
}
