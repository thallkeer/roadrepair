using System.Collections.Generic;
using System.Linq;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using ITS.GIS.MapEntities.Loader;
using Microsoft.Practices.Unity;
using ITS.MapObjects.RoadRepairingMapObject.Properties;


namespace ITS.MapObjects.RoadRepairingMapObject
{
    public class RoadRepairLayerLoader : ICustomLayerLoader
    {
        /// <summary>
        /// Менеджер.
        /// </summary>
        private readonly IRoadRepairManager _rrManager;

        public RoadRepairLayerLoader()
        {
            _rrManager = RoadRepairConstants.Container.Resolve<IRoadRepairManager>();
        }

        public string LayerName
        {
            get { return Resources.RoadRepairAlias; }
        }

        public string AttributeName
        {
            get { return RoadRepairConstants.RrepAttributeName; }
        }


        /// <param name="listIds"></param>
        /// <param name="map"></param>
        public void Load(List<long> listIds, IMap map)
        {
            if (listIds.Count == 0) return;

            List<long> idsInLayer;
            lock (map.SyncRoot)
            {
                var layer = (IVectorLayer)map.Layers[Resources.RoadRepairAlias];
                idsInLayer = listIds.Where(id => layer.Features.ContainsKey(id)).ToList();
            }

            var rrs = LoadRrByIds(idsInLayer);
            if (rrs != null)
            {
                lock (map.SyncRoot)
                {
                    var layer = (IVectorLayer) map.Layers[Resources.RoadRepairAlias];
                    foreach (var rr in rrs)
                    {
                        if (layer.Features.ContainsKey(rr.FeatureObject.ID))
                        {
                            var f = layer.Features[rr.FeatureObject.ID];
                            var attrRR = (Attribute<RoadRepair>) GetAttribute(f, AttributeName);
                            if (attrRR == null)
                            {
                                attrRR = new Attribute<RoadRepair>(new AttributeType<RoadRepair>(AttributeName), rr);
                                f.Attributes.Add(attrRR);
                            }
                            else
                            {
                                attrRR.AttrValue = rr;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получить список РК по списку идентификаторов геометрий        
        /// </summary>
        /// <param name="ids">Список идентификаторов геометрий</param>
        /// <returns></returns>
        private IEnumerable<RoadRepair> LoadRrByIds(List<long> ids)
        {
            return _rrManager.GetRoadRepairsByFeatureObjectIDs(ids);
        }
        /// <summary>
        /// Получить атрибут геометрии по его названию.
        /// </summary>
        /// <param name="feature">Геометрия</param>
        /// <param name="name">Название атрибута</param>
        /// <returns></returns>
        private IAttribute GetAttribute(IFeature feature, string name)
        {
            return feature.Attributes.Find(a => a.AttrType.Name == name);
        }
    }
}