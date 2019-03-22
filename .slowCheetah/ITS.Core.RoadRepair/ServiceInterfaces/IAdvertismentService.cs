using System.Collections.Generic;
using System.ServiceModel;
using ITS.Core.Domain.Organizations;
using ITS.Core.ServiceInterfaces;
using ITS.Core.Spectrum.Domain;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.FaultContracts;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;

namespace ITS.Core.Spectrum.ServiceInterfaces
{
    /// <summary>
    /// Интерфейс сервиса рекламы организации.
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required)]
    [ExceptionShielding(Policies.AbstractServicePolicy)]
    public interface IAdvertismentService : IAbstractService<Advertisment, long>
    {
        /// <summary>
        /// Получить рекламу по списку организаций.
        /// </summary>
        /// <param name="orgs">Список организаций</param>
        /// <returns>Реклама заданных организаций</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "GetAdvertisementsByOrganizationList")]
        [FaultContract(typeof(BaseFault))]
        List<Advertisment> GetAdvertisementsByOrganizationList(List<Organization> orgs);

        /// <summary>
        /// Загрузить данные для заданной рекламы.
        /// </summary>
        /// <param name="advertisement">Реклама</param>
        /// <returns></returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "LoadAdvertisementData")]
        [FaultContract(typeof(BaseFault))]
        Advertisment LoadAdvertisementData(Advertisment advertisement);
    }
}