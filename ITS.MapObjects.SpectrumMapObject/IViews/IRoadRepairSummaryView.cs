using System;
using System.Collections.Generic;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.Domain.Photos;
using ITS.Core.Domain.Organizations;
using ITS.MapObjects.RoadRepairingMapObject.EventArgses;

namespace ITS.MapObjects.RoadRepairingMapObject.IViews
{
    /// <summary>
    /// Интерфейс вида поиска дорожных ремонтов.
    /// </summary>
    public interface IRoadRepairSummaryView 
    {
        /// <summary>
        /// Отображаемые ДТО ЖД переезды.
        /// </summary>
        IEnumerable<RoadRepairDTO> Model { get; set; }

         void View();
        /// <summary>
        /// Заполняет фильтры ЖД переезда.
        /// </summary>
        /// <param name="filterDictionary">Фильтры и их возможные значения.</param>
        void FillRoadRepairFilters(IDictionary<ITS.Core.Domain.Filters.Filter, object> filterDictionary);

        /// <summary>
        /// Фильтры ЖД преездов.
        /// </summary>
        ICollection<ITS.Core.Domain.Filters.Filter> RoadRepairFilters { get; }

        /// <summary>
        /// Отобразить ЖД переезд на карте.
        /// </summary>
        event EventHandler<RoadRepairDTOEventArgs> ShowOnMap;

        /// <summary>
        /// Редактировать ЖД переезд.
        /// </summary>
        event EventHandler<RoadRepairDTOEventArgs> EditRoadRepair;

        /// <summary>
        /// Применить фильтр.
        /// </summary>
        event EventHandler<EventArgs> LoadRoadRepair;

        /// <summary>
        /// Экспортировать сводную ведомость в MS Word.
        /// </summary>
        event EventHandler<EventArgs> ExportToWord;
    }
}
