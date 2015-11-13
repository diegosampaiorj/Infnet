using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GasSensor.Utilities
{
    public class SendMail
    {
        public void SendMessage()
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("diego.dscrj@gmail.com", "@Ie14ih153");
            MailMessage mail = new MailMessage();
            mail.Sender = new MailAddress("diego.dscrj@gmail.com", "Sender");
            mail.From = new MailAddress("diego.dscrj@gmail.com", "Quem enviou");
            mail.To.Add(new MailAddress("dsampaio@mundipagg.com", "Receiver"));
            mail.Subject = "Contato";
            mail.Body = " Mensagem do site: E-mail de teste para o cliente de envio de e-mail do trabalho da Yona.<br/> Nome:  " + "Diego" + "<br/> Email : " + "diego.dscrj@gmail.com" +
                        " <br/> Mensagem : " + "Mensagem de teste";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                mail = null;
            }

        }
    }
}