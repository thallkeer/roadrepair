using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.ServiceInterfaces;
using ITS.ProjectBase.Utils.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;

namespace ITS.Core.RoadRepairing.ServiceInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    [ExceptionShielding(Policies.AbstractServicePolicy)]
    public interface IWorkSortService : IAbstractService<WorkSort, long>
    {
    }
}
