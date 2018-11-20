﻿using lib60870;
using lib60870.CS101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IEC.Server
{
    public class Services
    {
        public bool interrogationHandler(object parameter, IMasterConnection connection, ASDU asdu, byte qoi)
        {
            Console.WriteLine("Interrogation for group " + qoi);

            ApplicationLayerParameters cp = connection.GetApplicationLayerParameters();

            connection.SendACT_CON(asdu, false);

            // send information objects
            ASDU newAsdu = new ASDU(cp, CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 2, 1, false);

            newAsdu.AddInformationObject(new MeasuredValueScaled(100, -1, new QualityDescriptor()));

            newAsdu.AddInformationObject(new MeasuredValueScaled(101, 23, new QualityDescriptor()));

            newAsdu.AddInformationObject(new MeasuredValueScaled(102, 2300, new QualityDescriptor()));

            connection.SendASDU(newAsdu);

            newAsdu = new ASDU(cp, CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 3, 1, false);

            newAsdu.AddInformationObject(new MeasuredValueScaledWithCP56Time2a(103, 3456, new QualityDescriptor(), new CP56Time2a(DateTime.Now)));

            connection.SendASDU(newAsdu);

            newAsdu = new ASDU(cp, CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 2, 1, false);

            newAsdu.AddInformationObject(new SinglePointWithCP56Time2a(104, true, new QualityDescriptor(), new CP56Time2a(DateTime.Now)));

            connection.SendASDU(newAsdu);

            // send sequence of information objects
            newAsdu = new ASDU(cp, CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 2, 1, true);

            newAsdu.AddInformationObject(new SinglePointInformation(200, true, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(201, false, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(202, true, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(203, false, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(204, true, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(205, false, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(206, true, new QualityDescriptor()));
            newAsdu.AddInformationObject(new SinglePointInformation(207, false, new QualityDescriptor()));

            connection.SendASDU(newAsdu);

            newAsdu = new ASDU(cp, CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 2, 1, true);

            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(300, -1.0f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(301, -0.5f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(302, -0.1f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(303, .0f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(304, 0.1f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(305, 0.2f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(306, 0.5f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(307, 0.7f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(308, 0.99f));
            newAsdu.AddInformationObject(new MeasuredValueNormalizedWithoutQuality(309, 1f));

            connection.SendASDU(newAsdu);

            connection.SendACT_TERM(asdu);

            return true;
        }

        public bool asduHandler(object parameter, IMasterConnection connection, ASDU asdu)
        {

            if (asdu.TypeId == TypeID.C_SC_NA_1)
            {
                Console.WriteLine("Single command");

                SingleCommand sc = (SingleCommand)asdu.GetElement(0);

                Console.WriteLine(sc.ToString());
            }
            else if (asdu.TypeId == TypeID.C_CS_NA_1)
            {


                ClockSynchronizationCommand qsc = (ClockSynchronizationCommand)asdu.GetElement(0);

                Console.WriteLine("Received clock sync command with time " + qsc.NewTime.ToString());
            }

            return true;
        }
    }
}