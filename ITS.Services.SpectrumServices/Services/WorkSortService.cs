using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ITS.Core;
using ITS.Core.RoadRepairing.DataInterfaces;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.Data.RoadRepairing.DAO;
using ITS.ProjectBase.Data;
using ITS.ProjectBase.Service;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.Compressor;

namespace ITS.Services.RoadRepairingServices.Services
{
    [MessageCompression(Compress.Reply | Compress.Request)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerSession,
        UseSynchronizationContext = false,
        AutomaticSessionShutdown = true)]
    public class WorkSortService : AbstractService<WorkSort, long>, IWorkSortService
    {
        protected override IDAO<WorkSort, long> GetDAO()
        {
            try
            {
                return ApplicationService.GetDaoService().GetDao<IWorkSortDAO>();
            }
            catch (Exception ex)
            {
                ExceptionManager?.HandleException(ex, Policies.AbstractServicePolicy);
                throw;
            }
        }
    }
}
