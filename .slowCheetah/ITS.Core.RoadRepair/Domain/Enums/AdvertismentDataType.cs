using System;
using System.Collections.Generic;

namespace ITS.Core.Spectrum.Domain.Enums
{
    /// <summary>
    /// Тип данных рекламы.
    /// </summary>
    [Serializable]
    public enum AdvertismentDataType
    {
        Image = 0,
        Flash = 1,
        Gif = 2,
        None = 3,
        Integer = 4
    }

    public static class AdvertismentDataTypeHelper
    {
        public static Dictionary<AdvertismentDataType, string> Strings =
            new Dictionary<AdvertismentDataType, string>
            {
                {AdvertismentDataType.Flash,"Флеш ролик"},
                {AdvertismentDataType.Gif,"Gif анимация"},
                {AdvertismentDataType.Image,"Изображение"},
                {AdvertismentDataType.None,"<Не задано>"},
                {AdvertismentDataType.Integer,"Число"}
            };

        public static Dictionary<AdvertismentDataType, List<string>> FileExtentions =
            new Dictionary<AdvertismentDataType, List<string>>
            {
                {AdvertismentDataType.Flash,new List<string>{"swf"}},
                {AdvertismentDataType.Gif,new List<string>{"gif"}},
                {AdvertismentDataType.Image,new List<string>{"png", "jpg", "bmp"}},
                {AdvertismentDataType.Integer, new List<string>()},
                {AdvertismentDataType.None, new List<string>()}
            };
    }
}