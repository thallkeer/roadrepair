using System.Linq;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.Core.RoadRepairing.Domain;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.ManagerInterfaces.Districts;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.GIS.MapEntities.Styles;
using ITS.MapObjects.RoadRepairingMapObject.IModels;

namespace ITS.MapObjects.RoadRepairingMapObject.Models
{
    /// <summary>
    /// Модель ремонта дорог.
    /// </summary>
    public class RoadRepairModel : IRoadRepairModel 
    {
        #region Fields
        private readonly IRoadRepairManager _roadrepairManager;
        private readonly IWorkSortManager _workSortManager;
        private readonly IAddressManager _addressManager;
        #endregion

        #region Constructors
        /// Конструктор создания модели ремонта дорог.
        public RoadRepairModel(IRoadRepairManager rrManager, IWorkSortManager wsManager, IAddressManager addrManager)
        {
            _roadrepairManager = rrManager;
            _workSortManager = wsManager;
            _addressManager = addrManager;
        }
        #endregion

        #region Члены IRoadRepairModel

        public void RoadRepairAdd(long? addressId, RoadRepair roadRepair)
        {
            //SetStyle(roadRepair);
            roadRepair =_roadrepairManager.AddNew(roadRepair);
            //if (addressId != null)
            //{
            //    //TODO: удалить эту сточку, после реализации механизма добавления нескольких адресов.
            //    _roadRepairManager.DeleteAllAddressesForRoadRepair(roadRepairNew.ID);
            //if (RoadRepair.FeatureObject.ID != 0)
            //{
            //    var addresses = _addressManager.GetAddressesByFeatureObjectId(RoadRepair.FeatureObject.ID);
            //    foreach (var address in addresses)
            //    {
            if (addressId.HasValue)
            {
                _roadrepairManager.SetAddressForRoadRepair(addressId.Value, roadRepair.ID);
            }
            //    }
            //}
            //}
            //return roadRepairNew;

        }

        public void RoadRepairEdit(long? addressId, RoadRepair roadRepair)
        {
            //SetStyle(roadRepair);
            roadRepair = _roadrepairManager.Edit(roadRepair);
            //if (addressId.HasValue)
            //{
            //    _roadrepairManager.SetAddressForRoadRepair(addressId.Value, roadRepair.ID);
            //}
        }

        private void SetStyle(RoadRepair roadRepair)
        {
            var style = roadRepair.FeatureObject.Style as AreaStyleObject;
            if (style != null)
            {
                switch (roadRepair.Status)
                {
                    case RoadRepairStatus.InProgress:
                        {
                            style.InteriorHatchStyle = HatchStyle.Percent70;
                            style.InteriorBackColor = Color.Transparent;
                            //style.InteriorColor = Color.FromArgb(220, 0, 128, 0);
                            //style.LineColor = Color.FromArgb(0, 128, 0);
                            style.InteriorColor = Color.LimeGreen;
                            style.InteriorColor = Color.Green;
                            style.LineWidth = 0.17f;
                            break;
                        }
                    case RoadRepairStatus.Made:
                        {
                            style.InteriorHatchStyle = HatchStyle.Percent70;
                            style.InteriorBackColor = Color.Transparent;
                            style.InteriorColor = Color.FromArgb(220, 0, 128, 255);
                            style.LineColor = Color.FromArgb(0, 0, 255);
                            style.LineWidth = 0.17f;
                            break;
                        }
                    case RoadRepairStatus.WillBeMade:
                        {
                            style.InteriorHatchStyle = HatchStyle.Percent70;
                            style.InteriorBackColor = Color.Transparent;
                            style.InteriorColor = Color.FromArgb(220, 128, 100, 255);
                            style.LineColor = Color.FromArgb(128, 0, 255);
                            style.LineWidth = 0.17f;
                            break;
                        }
                    default:
                        {
                            style.InteriorHatchStyle = HatchStyle.Percent70;
                            style.InteriorBackColor = Color.Transparent;
                            style.InteriorColor = Color.FromArgb(220, 4, 231, 239);
                            style.LineColor = Color.FromArgb(4, 231, 239);
                            style.LineWidth = 0.17f;
                            break;
                        }
                }
            }
        }

        public List<WorkSort> GetWorkSorts()
        {
            return _workSortManager.GetAll().ToList();
        }

        //public List<string> ChangeDescription(IEnumerable<string> repairTypes, IEnumerable<string> workTypes)
        //{
        //    var repairType  = repairTypes.ElementAt(0);
        //    var workType = workTypes.ElementAt(0);
        //    //return _roadrepairManager.GetDescribeByRepairWorkType(RepairTypeHelper.GetByName(repairType),
        //    //    WorkTypeHelper.GetByName(workType));
        //    return null;
        //}

        //public List<string> ChangeDescription(int repairType, int workType)
        //{
        //    return _roadrepairManager.GetDescribeByRepairWorkType(repairType,workType);
        //}
        #endregion
    }
}