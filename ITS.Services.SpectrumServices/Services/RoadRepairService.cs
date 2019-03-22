using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;
using ITS.Core;
using ITS.Core.Domain.Districts;
using ITS.Core.Domain.Organizations;
using ITS.Core.Security;
using ITS.Core.RoadRepairing.DataInterfaces;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.ProjectBase.Data;
using ITS.ProjectBase.Service;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.Compressor;
using ITS.ProjectBase.Utils.WCF.FaultContracts;
using ITS.Core.Domain.Photos;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.Services.RoadRepairingServices.Services
{
    /// <summary>
    /// Сервис по объектам типа "Ремонт организаций".
    /// </summary>
    [MessageCompression(Compress.Reply | Compress.Request)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerSession,
        UseSynchronizationContext = false,
        AutomaticSessionShutdown = true)]
    public class RoadRepairService : AbstractService<RoadRepair, long>, IRoadRepairService
    {
        protected override IDAO<RoadRepair, long> GetDAO()
        {
            try
            {
                return ApplicationService.GetDaoService().GetDao<IRoadRepairDAO>();
            }
            catch (Exception ex)
            {
                ExceptionManager?.HandleException(ex, Policies.AbstractServicePolicy);
                throw;
            }
        }
        
        #region Члены IRoadRepairService

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public RoadRepair GetByFeature(long featureId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetByFeature(featureId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        public override RoadRepair SaveOrUpdate(RoadRepair entity)
        {
            try
            {
                var transient = entity.IsTransient();
                entity = GetDAO().Save(entity);
                HistoryManager.CreateOrUpdate(entity, entity.FeatureObject.Layer.Map.Alias, transient);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
            return entity;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        public override void DeleteAndCommit(RoadRepair entity)
        {
            try
            {
                GetDAO().Delete(entity);
                HistoryManager.Delete(entity, entity.FeatureObject.Layer.Map.Alias);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Возвращает список объектов Дорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектов Дорожный ремонт</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public List<RoadRepair> GetRoadRepairsByFeatureObjectIDs(List<long> ids)
        {

            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetRoadRepairsByFeatureObjectIDs(ids);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }


        
        /// <summary>
        /// Поиск ремонта по дате начала.
        /// </summary>
        /// <param name="ds">Дата.</param>
        /// <returns>Список ремонтов.</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public IEnumerable<RoadRepair> FindRoadRepairsByDateStart(DateTime ds)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).FindRoadRepairsByDateStart(ds);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }


       

        /// <summary>
        /// Получить строковое описание Дорожный ремонта.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Ид Дорожный ремонта, строковое описание Дорожный ремонта.</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public Dictionary<long, string> GetObjectIdDescription(long featureId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetObjectIdDescription(featureId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Получить список строковых описаний Дорожный ремонтов.
        /// </summary>
        /// <param name="featureIds">Список индентификаторов геометрий.</param>
        /// <returns>Список строковых описаний Дорожный ремонтов.</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public Dictionary<long, Dictionary<long, string>> GetFeatureIdObjectIdDescription(IEnumerable<long> featureIds)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetFeatureIdObjectIdDescription(featureIds);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Получение версии геометрии.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Версия геометрии.</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public int GetFeatureVersion(long featureId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetFeatureVersion(featureId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Фильтр DTO дорожных работ.
        /// </summary>
        /// <param name="rwcrossingFilters">Коллекция фильтров.</param>
        /// <returns>дорожные работы DTO.</returns>
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadWrite)]
        [PrincipalPermission(SecurityAction.Demand, Role = AppRoles.ReadOnly)]
        public IEnumerable<RoadRepairDTO> FilterRoadRepairs(ICollection<ITS.Core.Domain.Filters.Filter> roadrepirFilters)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).FilterRoadRepairs(roadrepirFilters);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null)
                    ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var f = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(f);
            }
        }

        /// <summary>
        /// Установить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">Дорожная работы.</param>
        /// <returns>Установлен ли адрес для дорожной работы.</returns>
        public void SetAddressForRoadRepair(long addressId, long roadRepairId)
        {
            try
            {
                ((IRoadRepairDAO)GetDAO()).SetAddressForRoadRepair(addressId, roadRepairId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        /// <summary>
        /// Удалить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удален ли адрес для дорожной работы.</returns>
        public bool DeleteAddressForRoadRepair(long addressId, long roadRepairId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).DeleteAddressForRoadRepair(addressId, roadRepairId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        /// <summary>
        /// Удалить все адреса для дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удалены ли адреса для дорожной работы.</returns>
        public bool DeleteAllAddressesForRoadRepair(long roadRepairId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).DeleteAllAddressesForRoadRepair(roadRepairId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        /// <summary>
        /// Получить Ид адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Ид адреса дорожной работы.</returns>
        public long? GetAddressIdByRoadRepairId(long roadRepairId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetAddressIdByRoadRepairId(roadRepairId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        public Address GetAddressByRoadRepairId(long roadRepairId)
        {
            try
            {
                return ((IRoadRepairDAO)GetDAO()).GetAddressByRoadRepairId(roadRepairId);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex);
                throw new FaultException<BaseFault>(fault);
            }
        }

        /// <summary>
        /// Получение максимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Максимальное значение.</returns>
        public int GetMaxValue(string paramName)
        {
            int foundObjects;
            try
            {
                foundObjects = ((IRoadRepairDAO)GetDAO()).GetMaxValue(paramName);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(fault);
            }
            return foundObjects;
        }

        /// <summary>
        /// Получение минимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Минимальное значение.</returns>
        public int GetMinValue(string paramName)
        {
            int foundObjects;
            try
            {
                foundObjects = ((IRoadRepairDAO)GetDAO()).GetMinValue(paramName);
            }
            catch (Exception ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractServicePolicy);
                var fault = new BaseFault(ex, ServiceSecurityContext.Current.PrimaryIdentity.Name);
                throw new FaultException<BaseFault>(fault);
            }
            return foundObjects;
        }

        #endregion


    }
}
