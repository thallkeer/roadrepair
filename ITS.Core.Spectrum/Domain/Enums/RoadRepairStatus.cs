using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using ITS.GIS.MapEntities.Styles;

namespace ITS.Core.RoadRepairing.Domain.Enums
{
    /// <summary>
    /// Cтатус ремонта.
    /// </summary>
    [Serializable]
    public enum RoadRepairStatus 
    {
        [Description("Выполняются")]
        InProgress,


        [Description("Выполнены")]
        Made,


        [Description("Запланированы")]
        WillBeMade,

        [Description("Приостановлены")]
        Stopped
    }

    
    public static class StatusTypeHelper
    {
        private static Dictionary<RoadRepairStatus, string> Names =
            new Dictionary<RoadRepairStatus, string>
            {
                {RoadRepairStatus.Made, "Выполнены"},
                {RoadRepairStatus.InProgress, "Выполняются"},
                {RoadRepairStatus.WillBeMade, "Запланированы"},
                {RoadRepairStatus.Stopped,"Приостановлены" }
            };

        public static string GetName(RoadRepairStatus roadRepairStatus)
        {
            return Names[roadRepairStatus];
        }

        public static RoadRepairStatus GetByName(string name)
        {
            return Names.First(s => s.Value == name).Key;
        }

        /// <summary>
        /// Возвращает цвет, соответствующий заданному значению перечисления "статус".
        /// </summary>
        public static Color GetColor(RoadRepairStatus statusType)
        {
            switch (statusType)
            {
                case (RoadRepairStatus.InProgress):
                    return Color.Red;
                case (RoadRepairStatus.Made):
                    return Color.Green;
                case (RoadRepairStatus.WillBeMade):
                    return Color.Blue;
                default:
                    return Color.BlueViolet;
            }
        }

        public static AreaStyle GetStyle(RoadRepairStatus statusType)
        {
            switch (statusType)
            {
                case RoadRepairStatus.InProgress:
                {
                    return new AreaStyle(
                        new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 0, 128, 0)),
                        new LineStyle(Color.FromArgb(0, 128, 0), 0.15f));
                }
                case RoadRepairStatus.Made:
                {
                    return new AreaStyle(
                        new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 0, 70, 255)),
                        new LineStyle(Color.FromArgb(0, 70, 255), 0.15f));
                }
                case RoadRepairStatus.WillBeMade:
                {
                    //return new AreaStyle(
                    //    new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 4, 231, 239)),
                    //    new LineStyle(Color.FromArgb(4, 231, 239), 0.15f));
                    return new AreaStyle(
                        new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 128, 96, 255)),
                        new LineStyle(Color.FromArgb(128, 96, 255), 0.15f));
                    }
                default:
                {
                    return new AreaStyle(
                        new InteriorStyle(HatchStyle.Percent70, Color.Transparent, Color.FromArgb(220, 1, 82, 86)),
                        new LineStyle(Color.FromArgb(1, 82, 86), 0.15f));
                }
            }
        }
    }
}
