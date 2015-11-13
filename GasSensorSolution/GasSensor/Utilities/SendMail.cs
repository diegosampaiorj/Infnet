using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GasSensor.Utilities
{
    /// <summary>
    /// Classe para enviar o e-mail
    /// </summary>
    public class SendMail
    {
        /// <summary>
        /// Método de envio de e-mail
        /// </summary>
        public void SendMessage()
        {
            // Classe de envio de e-mail utilizando SMTP
            SmtpClient client = new SmtpClient();
            
            // Definindo o host a ser utilizado
            client.Host = "smtp.gmail.com";
            
            // Encriptografia em SSL habilitada
            client.EnableSsl = true;

            // Passando as credenciais de acesso do e-mail a ser utilizado
            client.Credentials = new System.Net.NetworkCredential("diego.dscrj@gmail.com", "@Ie14ih153");

            // Instancia a classe de envio.
            MailMessage mail = new MailMessage();

            // Especifica o e-mail de quem está enviando (opicional)
            mail.Sender = new MailAddress("dlfmsolutions@gmail.com");

            // Especifica quem está enviando o e-mail
            mail.From = new MailAddress("diego.dscrj@gmail.com");

            // Especifica os remetentes do e-mail
            mail.To.Add(new MailAddress("luis-oliveira@msn.com"));

            // Assunto do e-mail
            mail.Subject = "Alerta de vazamento de gás.";

            // Corpo do e-mail
            mail.Body = " Este e-mail está sendo enviado para alertar que foi detectado um vazamento de gás em sua casa.";

            // Diz que o corpo do e-mail é um HTML
            mail.IsBodyHtml = true;

            // Seta a prioridade do e-mail
            mail.Priority = MailPriority.High;

            try
            {
                // Envia o e-mail
                client.Send(mail);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                // Esvazia o e-mail enviado.
                mail = null;
            }

        }
    }
}