using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using lib60870;
using lib60870.CS101;
using lib60870.CS104;

namespace IEC.Server.Controllers
{
    public class ServerController : ApiController
    {
        // GET: api/Server
        public void ServerConnection()
        {
            bool running = true;

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                running = false;
            };

            lib60870.CS104.Server server = new lib60870.CS104.Server();

            server.DebugOutput = true;

            server.MaxQueueSize = 10;

            Services services = new Services();

            server.SetInterrogationHandler(services.interrogationHandler, null);

            server.SetASDUHandler(services.asduHandler, null);

            server.Start();

            ASDU newAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.INITIALIZED, false, false, 0, 1, false);
            EndOfInitialization eoi = new EndOfInitialization(0);
            newAsdu.AddInformationObject(eoi);
            server.EnqueueASDU(newAsdu);

            int waitTime = 1000;

            while (running)
            {
                Thread.Sleep(100);

                if (waitTime > 0)
                    waitTime -= 100;
                else
                {

                    newAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.PERIODIC, false, false, 2, 1, false);

                    newAsdu.AddInformationObject(new MeasuredValueScaled(110, -1, new QualityDescriptor()));

                    server.EnqueueASDU(newAsdu);

                    waitTime = 1000;
                }
            }

            Console.WriteLine("Stop server");
            server.Stop();
        }
    }
}
