using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ITS.Core.RoadRepairing.Domain.Enums
{
    /// <summary>
    /// Вид работ конкретного типа ремонта
    /// </summary>
    [Serializable]
    public enum WorkType
    {
        [Description("По земляному полотну и системе водоотвода")] CanvasDrainage = 1,

        [Description("По дорожным одеждам")] RoadСlothes = 2,

        [Description("По искусственным и защитным дорожным сооружениям")] ArtificialConstr = 3,

        [Description("По элементам обустройства автомобильных дорог")] RoadConstrElements = 4,

        [Description("По зимнему содержанию")] WinterMaintenance = 5,

        [Description("По озеленению")] Landscaping = 6,

        [Description("Прочие работы")] Others = 7
    }

   
    public static class WorkTypeHelper
    {
        private static Dictionary<WorkType, string> Names =
            new Dictionary<WorkType, string>
            {
                {WorkType.CanvasDrainage, "По земляному полотну и системе водоотвода"},
                {WorkType.RoadСlothes, "По дорожным одеждам"},
                {WorkType.ArtificialConstr, "По искусственным и защитным дорожным сооружениям"},
                {WorkType.RoadConstrElements,"По элементам обустройства автомобильных дорог"},
                {WorkType.WinterMaintenance,"По зимнему содержанию"},
                {WorkType.Landscaping,"По озеленению"},
                {WorkType.Others,"Прочие работы"}
            };

        public static Dictionary<WorkType, string> GetNames()
        {
            return Names;
        }

        public static string GetName(WorkType workType)
        {
            return Names[workType];
        }

        public static WorkType GetByName(string name)
        {
            return Names.First(s => s.Value == name).Key;
        }
    }
}

