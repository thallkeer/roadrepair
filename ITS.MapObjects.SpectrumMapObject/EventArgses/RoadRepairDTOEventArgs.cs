using System;
using ITS.Core.RoadRepairing.Domain;

namespace ITS.MapObjects.RoadRepairingMapObject.EventArgses
{
    public class RoadRepairDTOEventArgs : EventArgs
    {
        public RoadRepairDTOEventArgs(RoadRepairDTO roadRepair)
        {
            RoadRepair = roadRepair;
        }

        public RoadRepairDTO RoadRepair { get; }
    }
}


