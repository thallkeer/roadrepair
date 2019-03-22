using System;
using System.Collections.Generic;

namespace ITS.Core.Spectrum.Domain.Enums
{
    /// <summary>
    /// Тип рекламы.
    /// </summary>
    [Serializable]
    public enum AdvertismentType
    {
        /// <summary>
        /// Рекламный модуль под окном справочника. Баннер (картинка, анимация, флеш).
        /// </summary>
        LeftPanelBottom = 0,

        /// <summary>
        /// Рекламный модуль в окне рубрики. Баннер (картинка).
        /// </summary>
        LeftInformationPanel = 1,
        
        /// <summary>
        /// Особенное выделение организации в рубрике.
        /// </summary>
        CatalogBold = 2,

        /// <summary>
        /// Рейтинг организации в рубрике. Влияет на сортировку.
        /// </summary>
        CatalogRating = 3,
        
        /// <summary>
        /// Баннер для организации в просмотре информации об организации. 
        /// </summary>
        CatalogBanner = 4
    }

    public static class AdvertismentTypeHelper
    {
        public static Dictionary<AdvertismentType, string> Strings =
            new Dictionary<AdvertismentType, string>
            {
                {AdvertismentType.LeftPanelBottom,"Баннер под окном справочника"},
                {AdvertismentType.LeftInformationPanel,"Баннер в справочнике"},
                {AdvertismentType.CatalogBold,"Выделение в списке"},
                {AdvertismentType.CatalogRating,"Рейтинг в списке"},
                {AdvertismentType.CatalogBanner,"Баннер в списке"},
            };

        public static Dictionary<AdvertismentType, List<AdvertismentDataType>> AdvertismentTypeToDataType =
            new Dictionary<AdvertismentType, List<AdvertismentDataType>>
            {
                {AdvertismentType.LeftPanelBottom, new List<AdvertismentDataType>{AdvertismentDataType.Image, AdvertismentDataType.Flash, AdvertismentDataType.Gif}},
                {AdvertismentType.LeftInformationPanel, new List<AdvertismentDataType>{AdvertismentDataType.Image}},
                {AdvertismentType.CatalogBold,new List<AdvertismentDataType>{AdvertismentDataType.None}},
                {AdvertismentType.CatalogRating,new List<AdvertismentDataType>{AdvertismentDataType.Integer}},
                {AdvertismentType.CatalogBanner, new List<AdvertismentDataType>{AdvertismentDataType.Image}}
            };
    }
}