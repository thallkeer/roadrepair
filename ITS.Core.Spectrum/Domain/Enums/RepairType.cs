using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace ITS.Core.RoadRepairing.Domain.Enums
{
    [Serializable]
    public enum RepairType
    {
        [Description("Содержание автодорог")]
        Maintenance = 1,

       
        [Description("Ремонт автодорог")]
        Repair = 2,

        
        [Description("Капитальный ремонт")]
        Overhaul = 3,
    }

    /// <summary>
    /// Описание типа дорожного ремонта.
    /// </summary>
    public static class RepairTypeHelper
    {
        private static Dictionary<RepairType, string> Names =
            new Dictionary<RepairType, string>
            {
                {RepairType.Maintenance, "Содержание автодорог"},
                {RepairType.Repair, "Ремонт автодорог"},
                {RepairType.Overhaul, "Капитальный ремонт"}
            };

        public static Dictionary<RepairType, string> GetNames()
        {
            return Names;
        }

        public static string GetName(RepairType roadRepairType)
        {
            return Names[roadRepairType];
        }

        public static RepairType GetByName(string name)
        {
            return Names.First(s => s.Value == name).Key;
        }

        
    }
}
