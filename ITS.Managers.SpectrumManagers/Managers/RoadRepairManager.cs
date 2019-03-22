using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Security;
using ITS.Core.Domain.Districts;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.Managers.BaseManagers;
using ITS.ProjectBase.Utils.ExceptionHandling;
using ITS.ProjectBase.Utils.WCF.FaultContracts;

namespace ITS.Managers.RoadRepairingManagers.Managers
{
    /// <summary>
    /// Менеджер дорожного ремонта.
    /// </summary>
    public class RoadRepairManager :  AbstractManager<RoadRepair, long, IRoadRepairService>, IRoadRepairManager
    {
        #region Члены IRoadRepairManager

       public RoadRepair GetByFeature(long featureId)
        {
            RoadRepair res = null;
            IRoadRepairService channel = GetChannel();
            using (channel as IDisposable)
            {
                try
                {
                    res = channel.GetByFeature(featureId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }
            return res;
        }

        /// <summary>
        /// Возвращает список объектов Дорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектов Дорожный ремонт</returns>
        public List<RoadRepair> GetRoadRepairsByFeatureObjectIDs(List<long> ids)
        {
            {
                IRoadRepairService channel = GetChannel();
                try
                {
                    using (channel as IDisposable)
                    {
                        return channel.GetRoadRepairsByFeatureObjectIDs(ids);
                    }
                }
                catch (FaultException<BaseFault> ex)
                {
                    ExceptionManager?.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    ExceptionManager?.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    ExceptionManager?.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    ExceptionManager?.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }

      
        /// <summary>
        /// Получить строковое описание Дорожный ремонта.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Ид Дорожный ремонта, строковое описание Дорожный ремонта.</returns>
        public Dictionary<long, string> GetObjectIdDescription(long featureId)
        {
            Dictionary<long, string> res = null;
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    res = channel.GetObjectIdDescription(featureId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }

            return res;
        }

        /// <summary>
        /// Получить список строковых описаний Дорожный ремонтов.
        /// </summary>
        /// <param name="featureIds">Список индентификаторов геометрий.</param>
        /// <returns>Список строковых описаний Дорожный ремонтов.</returns>
        public Dictionary<long, Dictionary<long, string>> GetFeatureIdObjectIdDescription(IEnumerable<long> featureIds)
        {
            Dictionary<long, Dictionary<long, string>> res = null;
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    res = channel.GetFeatureIdObjectIdDescription(featureIds);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }

            return res;
        }

        /// <summary>
        /// Получение версии геометрии.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Версия геометрии.</returns>
        public int GetFeatureVersion(long featureId)
        {
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    return channel.GetFeatureVersion(featureId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }

        /// <summary>
        /// Фильтр DTO ремонты.
        /// </summary>
        /// <param name="roadrepairFilters">Коллекция фильтров.</param>
        /// <returns>ремонты DTO.</returns>

        public IEnumerable<RoadRepairDTO> FilterRoadRepairs(ICollection<ITS.Core.Domain.Filters.Filter> roadrepairFilters)
        {
            IEnumerable<RoadRepairDTO> res = null;
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    res = channel.FilterRoadRepairs(roadrepairFilters);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
            }

            return res;
        }

        /// <summary>
        /// Установить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">Дорожная работы.</param>
        /// <returns>Установлен ли адрес для дорожной работы.</returns>
        public void SetAddressForRoadRepair(long addressId, long roadRepairId)
        {
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    channel.SetAddressForRoadRepair(addressId, roadRepairId);
                    return;
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
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
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    return channel.DeleteAddressForRoadRepair(addressId, roadRepairId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }

        /// <summary>
        /// Удалить все адреса для дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удалены ли адреса для дорожной работы.</returns>
        public bool DeleteAllAddressesForRoadRepair(long roadRepairId)
        {
            IRoadRepairService channel = GetChannel();
            using ((IDisposable) channel)
            {
                try
                {
                    return channel.DeleteAllAddressesForRoadRepair(roadRepairId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    ExceptionManager?.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    ExceptionManager?.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    ExceptionManager?.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    ExceptionManager?.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }

        /// <summary>
        /// Получить Ид адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Ид адреса дорожной работы.</returns>
        public long? GetAddressIdByRoadRepairId(long roadRepairId)
        {
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    return channel.GetAddressIdByRoadRepairId(roadRepairId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }


        public Address GetAddressByRoadRepairId(long roadRepairId)
        {
            IRoadRepairService channel = GetChannel();
            using ((IDisposable)channel)
            {
                try
                {
                    return channel.GetAddressByRoadRepairId(roadRepairId);
                }
                catch (FaultException<BaseFault> ex)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
                }
                catch (MessageSecurityException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
                }
                catch (SecurityAccessDeniedException e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
                }
                catch (Exception e)
                {
                    if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
                }
                throw new Exception("Не удалось выполнить запрос к серверу.");
            }
        }
        /// <summary>
        /// Получение максимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Максимальное значение.</returns>
        public int GetMaxValue(string paramName)
        {
            int result = 0;
            IRoadRepairService channel = GetChannel();
            if (channel == null) return 0;
            try
            {
                using ((IDisposable)channel)
                {
                    result = channel.GetMaxValue(paramName);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            return result;
        }

        /// <summary>
        /// Получение минимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Минимальное значение.</returns>
        public int GetMinValue(string paramName)
        {
            int result = 0;
            IRoadRepairService channel = GetChannel();
            if (channel == null) return 0;
            try
            {
                using ((IDisposable)channel)
                {
                    result = channel.GetMinValue(paramName);
                }
            }
            catch (FaultException<BaseFault> ex)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(ex, Policies.AbstractManagerPolicy);
            }
            catch (MessageSecurityException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.SecurityPolicy);
            }
            catch (SecurityAccessDeniedException e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.AccessPolicy);
            }
            catch (Exception e)
            {
                if (ExceptionManager != null) ExceptionManager.HandleException(e, Policies.ChannelCreatorPolicy);
            }
            return result;
        }

        #endregion
    }
}
