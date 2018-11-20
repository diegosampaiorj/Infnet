using lib60870;
using lib60870.CS101;
using lib60870.CS104;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace IEC.Client.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/Client
        [HttpGet]
        public void ClientConnection()
        {
           
            Connection con = new Connection("127.0.0.1");

            con.DebugOutput = true;


            Managers managers = new Managers();
            
            con.SetASDUReceivedHandler(managers.asduReceivedHandler, null);
            con.SetConnectionHandler(managers.ConnectionHandler, null);

            con.Connect();

            con.GetDirectory(1);

            con.GetFile(1, 30000, NameOfFile.TRANSPARENT_FILE, new Receiver());

            Thread.Sleep(50000);

            con.SendTestCommand(1);

            con.SendInterrogationCommand(CauseOfTransmission.ACTIVATION, 1, QualifierOfInterrogation.STATION);

            Thread.Sleep(5000);

            con.SendControlCommand(CauseOfTransmission.ACTIVATION, 1, new SingleCommand(5000, true, false, 0));

            con.SendControlCommand(CauseOfTransmission.ACTIVATION, 1, new DoubleCommand(5001, DoubleCommand.ON, false, 0));

            con.SendControlCommand(CauseOfTransmission.ACTIVATION, 1, new StepCommand(5002, StepCommandValue.HIGHER, false, 0));

            con.SendControlCommand(CauseOfTransmission.ACTIVATION, 1,
                                    new SingleCommandWithCP56Time2a(5000, false, false, 0, new CP56Time2a(DateTime.Now)));

            /* Synchronize clock of the controlled station */
            con.SendClockSyncCommand(1 /* CA */, new CP56Time2a(DateTime.Now));

/* exemplo de reconexao e perda
           con.Close();

            con.Connect();

            Thread.Sleep(5000);

            con.Close();
            */
        }


    }
}
