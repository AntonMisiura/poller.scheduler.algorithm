using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class SecondaryAirStatusCommand : CommandBase
    {
        protected override bool Parse(string data)
        {
            throw new NotImplementedException();

            //Cant get this PID's
            //Monitor status since DTCs cleared. (Includes malfunction indicator lamp(MIL) status and number of DTCs.)
            //Freeze DTC
            //Fuel system status
            //Commanded secondary air status
            //Oxygen sensors present (in 2 banks)
            //Oxygen Sensor 1-8 {A: Voltage, B: Short term fuel trim}
            //OBD standards this vehicle conforms to
            //Oxygen sensors present (in 4 banks)
            //Auxiliary input status
        }
    }
}
