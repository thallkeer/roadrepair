using System;
using ITS.Core.Domain;
using ITS.Core.Domain.Organizations;
using ITS.Core.Spectrum.Domain.Enums;

namespace ITS.Core.Spectrum.Domain
{
    /// <summary>
    /// Реклама организации.
    /// </summary>
    [Serializable]
    public class Advertisment : DomainObject<long>
    {
        #region Constructors

        /// <summary>
        /// Реклама организации.
        /// </summary>
        public Advertisment()
        {
        }

        /// <summary>
        /// Реклама организации.
        /// </summary>
        /// <param name="data">Данные рекламы</param>
        /// <param name="dataType">Тип данных</param>
        /// <param name="type">Тип рекламы</param>
        /// <param name="organization">Организация</param>
        public Advertisment(byte[] data, AdvertismentDataType dataType, AdvertismentType type, Organization organization)
            : this()
        {
            Data = data;
            DataType = dataType;
            AdvertismentType = type;
            Organization = organization;
        }

        #endregion

        #region DataProperties

        /// <summary>
        /// Данные рекламы.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Тип рекламы.
        /// </summary>
        public AdvertismentType AdvertismentType { get; set; }

        /// <summary>
        /// Тип данных.
        /// </summary>
        public AdvertismentDataType DataType { get; set; }

        /// <summary>
        /// Время показа в секундах (м.б. null).
        /// </summary>
        public int? ShowTime { get; set; }

        /// <summary>
        /// Начало действия (дата и время).
        /// </summary>
        public DateTime ShowStart { get; set; }

        /// <summary>
        /// Окончание действия (дата и время).
        /// </summary>
        public DateTime ShowEnd { get; set; }

        /// <summary>
        /// Организация - владелец рекламы.
        /// </summary>
        public Organization Organization { get; set; }

        #endregion

        #region Overrides of DomainObject<long>

        public override void CopyFrom(DomainObject<long> T)
        {
            var adv = T as Advertisment;
            if (adv == null) return;
            Data = adv.Data;
            AdvertismentType = adv.AdvertismentType;
            DataType = adv.DataType;
            ShowTime = adv.ShowTime;
            ShowStart = adv.ShowStart;
            ShowEnd = adv.ShowEnd;
            Organization = adv.Organization;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash += Organization != null ? Organization.GetHashCode() : 0;
            //hash += Data != null ? Data.GetHashCode() : "".GetHashCode();
            hash += AdvertismentType.GetHashCode();
            hash += DataType.GetHashCode();
            hash += ShowTime != null ? ShowTime.GetHashCode() : 0;
            hash += ShowStart.GetHashCode();
            hash += ShowEnd.GetHashCode();
            return hash;
        }

        #endregion
    }
}