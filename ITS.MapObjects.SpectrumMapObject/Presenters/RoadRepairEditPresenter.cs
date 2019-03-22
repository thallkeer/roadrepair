using System.Collections.Generic;
using ITS.Core.Domain.Districts;
using ITS.Core.RoadRepairing.Domain;
using ITS.MapObjects.RoadRepairingMapObject.IModels;
using ITS.MapObjects.RoadRepairingMapObject.IPresenters;
using ITS.MapObjects.RoadRepairingMapObject.IViews;

namespace ITS.MapObjects.RoadRepairingMapObject.Presenters
{
    /// <summary>
    /// Представитель добавления и изменения дорожного ремонта.
    /// </summary>
    public class RoadRepairEditPresenter : BasePresenter<IRoadRepairEditView, IRoadRepairModel>,
        IRoadRepairEditPresenter
    {
        
        /// <summary>
        /// Подписывается на события вида.
        /// </summary>
        protected override void AddViewEventHandlers()
        {
            View.EditRoadRepair += View_EditedFinished;
            View.AddRoadRepair += View_AddedFinished;
            View.WorkSorts = Model.GetWorkSorts();
        }

        /// <summary>
        /// Отписывается от событий вида.
        /// </summary>
        protected override void RemoveViewEventHandlers()
        {
            View.EditRoadRepair -= View_EditedFinished;
            View.AddRoadRepair -= View_AddedFinished;
        }

        protected override void AddModelEventHandlers()
        {
           
        }

        protected override void RemoveModelEventHandlers()
        {
           
        }

        #region private Method

        private void View_AddedFinished(long? addressId, RoadRepair roadRepair)
        {
            Model.RoadRepairAdd(addressId,roadRepair);
        }

        private void View_EditedFinished(long? addressId, RoadRepair roadRepair)
        {
            Model.RoadRepairEdit(addressId,roadRepair);
        }
        #endregion
    }
}