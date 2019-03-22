using System;
using ITS.Core.Domain;
using ITS.Core.Domain.Organizations;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Enums;
using ITS.Core.RoadRepairing.Domain.Enums;
using JetBrains.Annotations;

namespace ITS.Core.RoadRepairing.Domain
{
    /// <summary>
    /// Ремонт дорог
    /// </summary>
    [Serializable]
    public class RoadRepair : DomainObject<long>
    {
        #region Constructors

        /// <summary>
        /// Дороги
        /// </summary>
        public RoadRepair()
        {
            //this.RepairStart = DateTime.Today;
            //this.RepairEnd = DateTime.Today;
            
        }

        #endregion

        #region DataProperties

        /// <summary>
        /// Тип ремонта.
        /// </summary>
        public RepairType RepairType { get; set; }

        public WorkType WorkType { get; set; }

        public string WorkSort { get; set; }
        
        /// <summary>
        /// Тип статуса.
        /// </summary>
        public RoadRepairStatus Status { get; set; }

        //public Address Address { get; set; }

        public string Note { get; set; }
      
        /// <summary>
        /// Начало ремонта (дата).
        /// </summary>
        public DateTime?  RepairStart { get; set; }  

        /// <summary>
        /// Окончание ремонта (дата).
        /// </summary>
        public DateTime? RepairEnd { get; set; }

        public DateTime? RepairStartFact { get; set; }

        public DateTime? RepairEndFact { get; set; }

        /// <summary>
        /// Организация, проводящая ремонт.
        /// </summary>
        [CanBeNull]
        public Organization Performer { get; set; }
        /// <summary>
        /// Заказчик ремонта.
        /// </summary>
        [CanBeNull]
        public Organization Customer { get; set; }
        /// <summary>
        /// Владелец дороги.
        /// </summary>
        [CanBeNull]
        public Organization Owner { get; set; }
        /// <summary>

        /// <summary>
        /// Геометрический объект ремонта.
        /// </summary>
        public FeatureObject FeatureObject { get; set; }

        /// <summary>
        /// Строковое описание класса дорожных работ.
        /// </summary>
        /// 
        public string TypeAsString => RepairType.GetDescription();

        public string WorkTypeAsString => WorkType.GetDescription();

        /// <summary>
        /// Строковое описание статуса дорожного ремонта.
        /// </summary>
        public string StatusAsString => Status.GetDescription();

        #endregion
      
        #region Overrides of DomainObject<long>

        /// <summary>
        /// Получает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 128;
                //hash ^= Address != null ? Address.GetHashCode() : 5 * 30;
                hash ^= Note != null ? Note.GetHashCode() : 6 * 30;
                hash ^= RepairStart != null ? RepairStart.GetHashCode() : 7 * 30;
                hash ^= RepairEnd != null ? RepairEnd.GetHashCode() : 8 * 30;
                hash ^= Status.GetHashCode();
                hash ^= RepairType.GetHashCode();
                hash ^= WorkType.GetHashCode();
                hash ^= WorkSort != null ? WorkSort.GetHashCode() : 12 * 30;
                hash ^= FeatureObject != null ? FeatureObject.GetHashCode() : 13 * 30;
                return hash;
            }
        }

        /// <summary>
        /// Копирует поля из объекта.
        /// </summary>
        public override void CopyFrom(DomainObject<long> T)
        {
            if (T == null) throw new ArgumentNullException("T");
            var roadRepair = T as RoadRepair;
            if (roadRepair == null) return;

            //Address = roadRepair.Address;
            Note = roadRepair.Note;
            RepairStart = roadRepair.RepairStart;
            RepairEnd = roadRepair.RepairEnd;
            RepairType = roadRepair.RepairType;
            WorkType = roadRepair.WorkType;
            WorkSort = roadRepair.WorkSort;
            Status = roadRepair.Status;
            FeatureObject = roadRepair.FeatureObject;
        }

        public override string ToString()
        {
            return String.Format(TypeAsString +" " + WorkTypeAsString.ToLower() + " " + WorkSort.ToLower());
        }

        #endregion
    }
}
