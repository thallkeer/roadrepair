using System.Linq;
using System.Windows.Forms;
using GeoAPI.Geometries;
using ITS.Client.Interface.StateMachine;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using ITS.MapObjects.RoadRepairingMapObject;
using ITS.MapObjects.RoadRepairingMapObject.Properties;

namespace ITS.MapObjects.RoadRepairingMapObject
{
    public static class RoadRepairPanelHelper
    {
        public static RoadRepair GetSelectedRoadRepair(IMap handledMap, IRoadRepairManager roadrepairManager,
            Coordinate coord, RoadRepair currentRoadRepair)
        {
            RoadRepair choosenRoadRepair = null;
            var args = handledMap.GetAllFeature(coord, Resources.RoadRepairAlias)
                // Выбираем те фичи, у которых нет атрибута видимости (тогда они видимые) или он есть и его значение true.
                .Where(i => i.Feature.Attributes.All(a => a.AttrType.Name != "IsVisible") ||
                            ((Attribute<bool>) i.Feature.Attributes.First(a => a.AttrType.Name == "IsVisible"))
                            .AttrValue)
                .ToArray();
            if (args.Length == 0)
            {
                var tempFeatures = handledMap.GetAllFeature(coord, handledMap.TempLayerAlias);
                if (
                    tempFeatures.Any(
                        f =>
                            f.Feature.Attributes.Any(
                                a =>
                                    a.AttrType.Name == RoadRepairConstants.RrepAttributeName &&
                                    ((Attribute<RoadRepair>) a).AttrValue == currentRoadRepair)))
                    return currentRoadRepair;
                return null;
            }
            if (args.Length == 1)
            {
                //StateMachine.SelectFeatureAdd(args.First());
                choosenRoadRepair = roadrepairManager.GetByFeature(args.First().FeatureId);
            }
            //Если переездов в указанном месте несколько
            else
            {
                var roadrepair =
                    args.Select(arg => roadrepairManager.GetByFeature(arg.FeatureId))
                        .Where(x => x != null)
                        .ToList();
                var s = roadrepair.Select(x => x.ToString()).ToList();
                var f = new SelectFeatureForm(s) {Text = @"ITSGIS: выбор дорожного ремонта"};
                if (f.ShowDialog() == DialogResult.OK)
                {
                    //StateMachine.SelectFeatureAdd(args[f.SelectedItem]);
                    choosenRoadRepair = roadrepairManager.GetByFeature(args[f.SelectedItem].FeatureId);
                }
            }
            return choosenRoadRepair;
        }
    }
}