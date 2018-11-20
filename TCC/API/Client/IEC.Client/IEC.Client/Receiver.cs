using lib60870.CS101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IEC.Client
{
    public class Receiver : IFileReceiver
    {
        public void Finished(FileErrorCode result)
        {
            Console.WriteLine("File download finished - code: " + result.ToString());
        }


        public void SegmentReceived(byte sectionName, int offset, int size, byte[] data)
        {
            Console.WriteLine("File segment - sectionName: {0} offset: {1} size: {2}", sectionName, offset, size);
        }
    }
}