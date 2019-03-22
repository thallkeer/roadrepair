using System;
using System.Collections.Generic;
using ITS.Core.Domain.Districts;
using ITS.Core.Domain.Organizations;
using ITS.Core.RoadRepairing.Domain;
using ITS.ProjectBase.Data;
using ITS.Core.Domain.Photos;
using ITS.Core.Domain.Filters;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.Core.RoadRepairing.DataInterfaces
{
    public interface IRoadRepairDAO : IDAO<Domain.RoadRepair, long>
    {        
        /// <summary>
        /// Получить Дорожный ремонт по геометрии.
        /// </summary>
        /// <param name="featureId">Идентификатор геометрии.</param>
        /// <returns>Дорожный ремонт, использующая эту геометрию.</returns>
        RoadRepair GetByFeature(long featureId);

        /// <summary>
        /// Возвращает список объектов Дорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектов Дорожный ремонт</returns>
        List<RoadRepair> GetRoadRepairsByFeatureObjectIDs(List<long> ids);
        
        /// <summary>
        /// Возвращает список объектов дорожный ремонт соответствующих фильтру.
        /// Используется при поиске.
        /// </summary>
        /// <param name="ds">дата начала.</param>
        /// <returns>Список объектов дорожного ремонта.</returns>
        IEnumerable<RoadRepair> FindRoadRepairsByDateStart(DateTime ds);


        /// <summary>
        /// Получить строковое описание Дорожный ремонта.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Ид Дорожный ремонта, строковое описание Дорожный ремонта.</returns>
        Dictionary<long, string> GetObjectIdDescription(long featureId);

        /// <summary>
        /// Получить список строковых описаний Дорожный ремонтов.
        /// </summary>
        /// <param name="featureIds">Список индентификаторов геометрий.</param>
        /// <returns>Список строковых описаний Дорожный ремонтов.</returns>
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
        void SetAddressForRoadRepair(long addressId, long roadRepairId);

        /// <summary>
        /// Удалить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удален ли адрес для дорожной работы.</returns>
        bool DeleteAddressForRoadRepair(long addressId, long roadRepairId);


        /// <summary>
        /// Удалить все адреса для дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удалены ли адреса для дорожной работы.</returns>
        bool DeleteAllAddressesForRoadRepair(long roadRepairId);

        /// <summary>
        /// Получить Ид адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Ид адреса дорожной работы.</returns>
        long? GetAddressIdByRoadRepairId(long roadRepairId);

        /// <summary>
        /// Получить адрес по id дорожной работы
        /// </summary>
        /// <param name="roadRepairId">ID</param>
        /// <returns>Адрес</returns>
        Address GetAddressByRoadRepairId(long roadRepairId);

        /// <summary>
        /// Получение максимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Максимальное значение.</returns>
        int GetMaxValue(string paramName);

        /// <summary>
        /// Получение минимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Минимальное значение.</returns>
        int GetMinValue(string paramName);
    }
}

            
        
    

