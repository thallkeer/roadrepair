using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using GeoAPI.Geometries;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.GIS.CoreToGeoTranslators;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Attributes;
using ITS.GIS.MapEntities.Renderer;
using ITS.GIS.MapEntities.Styles;
//using ITS.MapObjects.RoadRepairMapObject.Helpers;
using ITS.MapObjects.RoadRepairingMapObject.Properties;
using Microsoft.Practices.Unity;
using GeoPoint = NetTopologySuite.Geometries.Point;

namespace ITS.MapObjects.RoadRepairingMapObject
{
    public interface IRoadRepairLayerRenderer : ICustomLayerRenderer
    {
        
    }
    public class RoadRepairLayerRenderer : IRoadRepairLayerRenderer
    {
        private readonly SimpleLayerRenderer _simpleLayerRenderer;

        private Matrix _transformMatrix = new Matrix();
        
        public RoadRepairLayerRenderer()
        {
            _simpleLayerRenderer = RoadRepairConstants.Container.Resolve<SimpleLayerRenderer>();
            IsEnabled = true;
           // Alias = string.Empty;
        }
        /// <summary>
        /// Список выделенных геометрий. Key - id, Value - цвет выделения.
        /// </summary>
        public Dictionary<long, Color> SelectedRoadRepair { get; set; }

        private RoadRepair GetRoadRepairByFeature(IFeature feature)
        {
            var attr = (Attribute<RoadRepair>)GetAttribute(feature, RoadRepairConstants.RrepAttributeName);
            return attr == null ? null : attr.AttrValue;
        }

        #region Члены ICustomLayerRenderer

        public string Alias => Resources.RoadRepairAlias;

        public string PluginName => Resources.PluginToolName;

        public bool IsEnabled { get; set; }

        public string Description => "Стандартный";

        private IAttribute GetAttribute(IFeature feature, string name)
        {
            return feature.Attributes.Find(a => a.AttrType.Name == name);
        }

        public void Render(Graphics g, ILayer layer, Envelope envelope, Matrix transformMatrix)
        {
            var vLayer = layer as IVectorLayer;

            if (vLayer != null)
            {
                //Получили все геометрии заданной области
                var features = vLayer.Features.Where(
                        f =>
                            f.Value.Geometry.GeometryType == "Polygon" &&
                            envelope.Intersects(f.Value.Geometry.EnvelopeInternal)).
                    Select(f => f.Value).ToList();

                // Переходим к отрисовке списка ремонтов.
                Render(g, features, transformMatrix);
            }
        }

        public void Render(Graphics g, IEnumerable<IFeature> features, Matrix transformMatrix)
        {
            var gc = g.BeginContainer();
            // Применяем зум и смещения к контейнеру.
            g.Transform = transformMatrix;

            // Задаем максимальное качество отрисовки.
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            foreach (var f in features)
            {
                DrawRrFeature(g,f);
            }
            g.EndContainer(gc);
        }

        #endregion

        protected void DrawRrFeature(Graphics g, IFeature feature)
        {
            var roadRepair = GetRoadRepairFromFeature(feature);
            if (roadRepair == null || !IsVisible(roadRepair, feature)) return;

            //var h = roadRepair.FeatureObject.Style;
            //var Istyle = StyleTranslator.GetStyle(h);
            //Istyle.SetColor(StatusTypeStrings.GetColor(roadRepair.Status));
            //roadRepair.FeatureObject.Style = Istyle.GetStyleObject();


            AreaStyle style;

            switch (roadRepair.Status)
            {
                case RoadRepairStatus.InProgress:
                {
                    style = new AreaStyle(new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 128, 96, 255)), new LineStyle(Color.FromArgb(128, 96, 255), 0.15f));
                    break;
                }
                case RoadRepairStatus.Made:
                {
                    style = new AreaStyle(new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 0, 110, 255)), new LineStyle(Color.FromArgb(0, 110, 255), 0.15f));
                    break;
                }
                case RoadRepairStatus.WillBeMade:
                {
                    style = new AreaStyle(new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 4, 231, 239)), new LineStyle(Color.FromArgb(4, 231, 239), 0.15f));
                    break;
                }
                default:
                {
                    style = new AreaStyle(new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 1, 82, 86)), new LineStyle(Color.FromArgb(1, 82, 86), 0.15f));
                    break;
                }
            }
            Paint(roadRepair.FeatureObject.Geometry, g, style);
            //Paint(roadRepair.FeatureObject.Geometry, g, StatusTypeHelper.GetStyle(roadRepair.Status));

            //Paint(roadRepair.FeatureObject.Geometry, g, roadRepair.FeatureObject.Style.GetStyle());
        }

        protected virtual void Paint(IGeometry geometry, Graphics g, IStyle style)
        {
            if (!geometry.IsEmpty)
                _simpleLayerRenderer.Paint(geometry, g, style, _transformMatrix);
        }

        private RoadRepair GetRoadRepairFromFeature(IFeature feature)
        {
            var attr = GetAttribute(feature, RoadRepairConstants.RrepAttributeName);
            if (attr != null)
                return ((Attribute<RoadRepair>)attr).AttrValue;
            return null;
        }

        private bool IsVisible(RoadRepair roadRepair, IFeature feature)
        {
            var res = true;
            switch (roadRepair.Status)
            {
                case RoadRepairStatus.InProgress:
                    res = RoadRepairConstants.IsDrawInProgress;
                    break;
                case RoadRepairStatus.Made:
                    res = RoadRepairConstants.IsDrawMade;
                    break;
                case RoadRepairStatus.WillBeMade:
                    res = RoadRepairConstants.IsDrawWillBeMade;
                    break;
            }
            if (res)
            {
                var attr = (Attribute<bool>)GetAttribute(feature, "IsVisible");
                if (attr != null) return attr.AttrValue;
            }
            return res;
        }
    }
}