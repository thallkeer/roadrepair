using System.Collections.Generic;
using System.ServiceModel;
using ITS.Core.Domain.Districts;
using ITS.Core.Domain.Organizations;
using ITS.Core.ManagerInterfaces;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.Domain.Photos;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.Core.ServiceInterfaces;
using ITS.ProjectBase.Utils.WCF.FaultContracts;

namespace ITS.Core.RoadRepairing.ManagerInterfaces
{
     /// <summary>
    /// Интерфейс менеджера доступа к данным по объектам типа "Ремонт дорог".
    /// </summary>
    public interface IRoadRepairManager : IManager<RoadRepair, long>
    {
        /// <summary>
        /// ПолучитьДорожный ремонт по геометрии.
        /// </summary>
        /// <param name="featureId">Идентификатор геометрии.</param>
        /// <returns>Дорожный ремонт, использующая эту геометрию.</returns>       
        RoadRepair GetByFeature(long featureId);

        /// <summary>
        /// Возвращает список объектовДорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектовДорожный ремонт</returns>
        List<RoadRepair> GetRoadRepairsByFeatureObjectIDs(List<long> ids);


       

        /// <summary>
        /// Получить строковое описаниеДорожный ремонта.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>ИдДорожный ремонта, строковое описаниеДорожный ремонта.</returns>
        Dictionary<long, string> GetObjectIdDescription(long featureId);

        /// <summary>
        /// Получить список строковых описаний Дорожный ремонтов.
        /// </summary>
        /// <param name="featureIds">Список индентификаторов геометрий.</param>
        /// <returns>Список строковых описанийДорожный ремонтов.</returns>
        Dictionary<long, Dictionary<long, string>> GetFeatureIdObjectIdDescription(IEnumerable<long> featureIds);

        /// <summary>
        /// Получение версии геометрии.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Версия геометрии.</returns>
        int GetFeatureVersion(long featureId);
        /// <summary>
        /// Фильтр DTO ЖД переезды.
        /// </summary>
        /// <param name="rwcrossingFilters">Коллекция фильтров.</param>
        /// <returns>ЖД переезды DTO.</returns>
        IEnumerable<RoadRepairDTO> FilterRoadRepairs(ICollection<ITS.Core.Domain.Filters.Filter> roadrepairFilters);

        /// <summary>
        /// Установить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">Дорожная работы.</param>
        /// <returns>Установлен ли адрес для дорожной работы.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "SetAddressForRoadRepair")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        void SetAddressForRoadRepair(long addressId, long roadRepairId);

        /// <summary>
        /// Удалить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удален ли адрес для дорожной работы.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "DeleteAddressForRoadRepair")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        bool DeleteAddressForRoadRepair(long addressId, long roadRepairId);

        /// <summary>
        /// Удалить все адреса для дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удалены ли адреса для дорожной работы.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "DeleteAllAddressesForRoadRepair")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        bool DeleteAllAddressesForRoadRepair(long roadRepairId);

        /// <summary>
        /// Получить Ид адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Ид адреса дорожной работы.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "GetAddressIdByRoadRepairId")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        long? GetAddressIdByRoadRepairId(long roadRepairId);

        /// <summary>
        /// Получить адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID</param>
        /// <returns>адреса дорожной работы.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "GetAddressByRoadRepairId")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        Address GetAddressByRoadRepairId(long roadRepairId);
        /// <summary>
        /// Получение максимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Максимальное значение.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "GetMaxValue")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        int GetMaxValue(string paramName);

        /// <summary>
        /// Получение минимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Минимальное значение.</returns>
        [UseNetDataContractSerializer]
        [OperationContract(Action = "GetMinValue")]
        [FaultContract(typeof(BaseFault))]
        [FaultContract(typeof(GeoAccessDeniedFault))]
        int GetMinValue(string paramName);
    }
}
