using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ITS.Core.Enums;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Fluent;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;

namespace ITS.Core.RoadRepairing.Domain.Enums
{
    /// <summary>
    /// Работы от типа ремонта и вида работ 
    /// </summary>
    [Serializable]
    public enum WorkSortOld
    {
        /// <summary>
        /// средний ремонт, земляное полотно и водоотводы
        /// </summary>
        [Description("Ремонт и укрепление обочин")]
        Medium_1_1 = 0,


        [Description("Ремонт откосов полотна и резервов")]
        Medium_1_2,


        [Description("Ремонт дренажей")]
        Medium_1_3,

        [Description("Ремонт труб")]
        Medium_1_4,

        [Description("Ремонт русел мостов")]
        Medium_1_5 = 4,

        /// <summary>
        /// средний ремонт дорожные одежды
        /// </summary>
        [Description("Восстановление слоя износа")]
        Medium_2_1 = 5,


        [Description("Выравнивание покрытия и повышение шероховатости")]
        Medium_2_2,


        [Description("Восстановление ровности щебеночных, гравийных и грунтовых покрытий добавлением нового материала")]
        Medium_2_3,

        [Description("Устройство виражей")]
        Medium_2_4 = 8,

        /// <summary>
        /// средний ремонт по искусственным сооружениям, зданиям и обстановке пути
        /// </summary>
        [Description("Несложный ремонт с заменой отдельных элементов")]
        Medium_3_1 = 9,

        [Description("Установка новых знаков")]
        Medium_3_2,

        [Description("Устройство ограждений")]
        Medium_3_3,

        [Description("Благоустройство развязок площадок отдыха")]
        Medium_3_4,

        [Description("Устройство тротуаров")]
        Medium_3_5 = 13,

        /// <summary>
        /// капитальный ремонт, земляное полотно и водоотводы
        /// </summary>
        [Description("Перестройка отдельных элементов с целью повышения прочности и устойчивости")]
        Overhaul_1_1 =14,

        [Description("Устранение деформаций и повреждений элементов земляного полотна на пересечениях и примыканиях, площадках для остановки," +
                     " стоянках транспортных средств, площадках для отдыха, разворотных площадках, тротуарах, пешеходных и велосипедных дорожках, " +
                     "переездах, съездах, подъездных дорогах к объектам дорожно-ремонтной службы, историческим и достопримечательным объектам, " +
                     "паромным переправам и другим объектам)")]
        Overhaul_1_2 = 15,

        [Description("Устройство пересечений в одном уровне")]
        Overhaul_1_3 = 16,
        
        /// <summary>
        /// капитальный ремонт дорожные одежды
        /// </summary>

        [Description("Утолщение, уширение, устройство новых одежд")]
        Overhaul_1_4 = 17,

        
        /// <summary>
        /// капитальный ремонт по искусственным сооружениям, зданиям и обстановке пути
        /// </summary>
        [Description("Перестройка мостов на новые")]
        Overhaul_2_1,
        [Description("Устройство галерей")]
        Overhaul_2_2,
        [Description("Устройство подпорных стенок,тоннелей, укрепительных сооружений")]
        Overhaul_2_3,
        [Description("Строительство новых зданий для эксплуатационной службы")]
        Overhaul_2_4,
        [Description("Устройство съездов  и подъездов длиной до 100 м")]
        Overhaul_2_5,
        [Description("Устройство сигнализации, освещения")]
        Overhaul_2_6,
        [Description("Архитектурное оформление")]
        Overhaul_2_7,
        [Description("Строительство автопавильонов, мест отдыха")]
        Overhaul_2_8,

        
        /// <summary>
        /// текущий ремонт, земляное полотно и водоотводы
        /// </summary>
        [Description("Ремонт дождеприемных и смотровых колодцев")]
        Maintenance_1_1 = 26,

        [Description("Ремонт водовыпускных устройств и водоотводных канав")]
        Maintenance_1_2 = 27,


        /// <summary>
        /// текущий ремонт дорожные одежды
        /// </summary>
        [Description("Заделка мелких ям, выбоин, трещин, колей")]
        Maintenance_2_1 = 28,
        [Description("Исправление просадок на дорожных одеждах")]
        Maintenance_2_2,
        [Description("Удаление волн и наплывов")]
        Maintenance_2_3,
        [Description("Устройство поверхностной обработки с целью повышения шероховатости на асфальтобетонных покрытиях")]
        Maintenance_2_4,
         [Description("Замена или выравнивание отдельных бортовых камней")]
        Maintenance_2_5 = 32,
        

        /// <summary>
        ///текущий ремонт по искусственным сооружениям, зданиям и обстановке пути
        /// </summary>
        [Description("Замена пришедших в негодность крышек, решеток и люков колодцев")]
        Maintenance_3_1 = 33,
        [Description("Замощение отдельных участков открытых водостоков")]
        Maintenance_3_2,
        [Description("Обновление дорожных знаков, сигналов, линий регулирования и других элементов обстановки улицы")]
        Maintenance_3_3 = 35,
    }

    public static class WorkSortHelper
    {
        public static string GetString(WorkSortOld wtd)
        {
            return wtd.GetDescription();
        }

        public static WorkSortOld GetValue(string name)
        {
            var tmp = Enum.GetValues(typeof(WorkSortOld)).Cast<WorkSortOld>();
            return tmp.FirstOrDefault(t => t.GetDescription() == name);
        }

        //public static List<string> GetDescribeByRepairWorkType(RepairTypes rt, WorkTypes wt)
        //{
        //    var tmp = Enum.GetValues(typeof (WorkSorts)).Cast<WorkSorts>();
        //    var res = new List<string>();
        //    int i;
        //    switch (rt)
        //    {
        //            #region Medium

        //        case RepairTypes.Medium:
        //        {
        //            switch (wt)
        //            {
        //                case WorkTypes.CanvasDrainage:
        //                {
        //                    for (i = 0; i < 5; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //                case WorkTypes.RoadСlothes:
        //                {
        //                    for (i = 5; i < 9; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //                case WorkTypes.ArtificialConstr:
        //                {
        //                    for (i = 9; i < 14; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;

        //                }
        //            }
        //        }
        //            break;

        //            #endregion

        //            #region Overhaul

        //        case RepairTypes.Overhaul:
        //        {
        //            switch (wt)
        //            {
        //                case WorkTypes.CanvasDrainage:
        //                {
        //                    for (i = 14; i < 17; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //                case WorkTypes.RoadСlothes:
        //                {
        //                    res.Add(tmp.ElementAt(17).GetDescription());
        //                    return res;
        //                }
        //                case WorkTypes.ArtificialConstr:
        //                {
        //                    for (i = 18; i < 26; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;

        //                }
        //            }
        //        }
        //            break;

        //            #endregion

        //            #region Maintenance

        //        case RepairTypes.Maintenance:
        //        {
        //            switch (wt)
        //            {
        //                case WorkTypes.CanvasDrainage:
        //                {
        //                    for (i = 26; i < 28; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //                case WorkTypes.RoadСlothes:
        //                {
        //                    for (i = 28; i < 33; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //                case WorkTypes.ArtificialConstr:
        //                {
        //                    for (i = 33; i < 36; i++)
        //                    {
        //                        res.Add(tmp.ElementAt(i).GetDescription());
        //                    }
        //                    return res;
        //                }
        //            }
        //        }
        //            break;

        //            #endregion
        //    }
        //    return null;
        //}


    }
}
