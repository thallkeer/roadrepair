using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.Managers.BaseManagers;
using ITS.Services.RoadRepairingServices.Services;

namespace ITS.Managers.RoadRepairingManagers.Managers
{
   public class WorkSortManager : AbstractManager<WorkSort, long, IWorkSortService>, IWorkSortManager
    {
    }
}
