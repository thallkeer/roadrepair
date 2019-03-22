using System.Collections.Generic;
using ITS.Core.Domain.Organizations;
using ITS.Core.ManagerInterfaces;
using ITS.Core.Spectrum.Domain;

namespace ITS.Core.Spectrum.ManagerInterfaces
{
    /// <summary>
    /// Интерфейс менеджера доступа к данным по объектам типа "Реклама организации".
    /// </summary>
    public interface IAdvertismentManager : IManager<Advertisment, long>
    {
        /// <summary>
        /// Получить рекламу по списку организаций.
        /// </summary>
        /// <param name="orgs">Список организаций</param>
        /// <returns>Реклама заданных организаций</returns>
        List<Advertisment> GetAdvertisementsByOrganizationList(List<Organization> orgs);

        /// <summary>
        /// Загрузить данные для заданной рекламы.
        /// </summary>
        /// <param name="advertisement">Реклама</param>
        /// <returns></returns>
        Advertisment LoadAdvertisementData(Advertisment advertisement);
    }
}