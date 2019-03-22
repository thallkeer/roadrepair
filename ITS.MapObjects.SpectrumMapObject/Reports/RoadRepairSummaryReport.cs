using System.Collections.Generic;
using ITS.Common.RtfWriter;

using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.MapObjects.RoadRepairingMapObject.Reports
{
    /// <summary>
    /// Формирование отчета "Сводная ведомость автодорожных ремонтов".
    /// </summary>
    public static class RoadRepairSummaryReport
    {
        /// <summary>
        /// Размер шрифта заголовка.
        /// </summary>
        private static float titleFontSize = 12;
        const float smToPt = 28.34646f;

        /// <summary>
        /// Отчет из плагина
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="roadrepairs"></param>
        public static void ReportMake(string fileName, IList<RoadRepairDTO> roadrepairs, 
            float sectionFontSize = 8.5f, PaperOrientation paperOrientation = PaperOrientation.Portrait)
        {
            var doc = new RtfDocument(PaperSize.A4, paperOrientation, Lcid.Russian);
            //RTFWorkingProvider.DocumentMargins(doc,
            //    paperOrientation == PaperOrientation.Landscape ? 2.5f : 1.5f,
            //    paperOrientation == PaperOrientation.Landscape ? 1.5f : 2.5f, 
            //    1.5f, 1.5f);
            RTFWorkingProvider.DocumentMargins(doc, 2.5f, 1.5f, 1.5f, 1.5f);

            doc.ChangeSectionMargins(
                (paperOrientation == PaperOrientation.Landscape ? 2.5f : 1.5f) * smToPt,
                1.5f * smToPt, 1.5f * smToPt,
                (paperOrientation == PaperOrientation.Landscape ? 1.5f : 2.5f) * smToPt);

            CreateDocumentTitle(doc);
            CreateDataTable(doc, roadrepairs, sectionFontSize);

            doc.AddSection(PaperSize.A4, paperOrientation);
            doc.ChangeSectionMargins(
                (paperOrientation == PaperOrientation.Landscape ? 2.5f : 1.5f) * smToPt,
                1.5f * smToPt, 1.5f * smToPt,
                (paperOrientation == PaperOrientation.Landscape ? 1.5f : 2.5f) * smToPt);
            CreateDocumentTitle(doc);
            CreateDataTable(doc, roadrepairs, sectionFontSize);

            doc.Save(fileName);
            
        }

        private static void CreateDocumentTitle(RtfDocument document)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize,HorizontalAlignment.Center, "Сводная ведомость дорожных работ");
            RTFWorkingProvider.AddEmptyLine(document, titleFontSize, HorizontalAlignment.Left);
            RTFWorkingProvider.AddEmptyLine(document, titleFontSize, HorizontalAlignment.Left);
        }

        #region Старый отчет для сводной ведомости плагина

        private static void CreateDataTable(RtfDocument document, IList<RoadRepairDTO> roadrepairs, float fontSize = 8.5f)
        {
            var table = document.AddTable(roadrepairs.Count + 2, 14); // 3-заголовок
            table.SetInnerBorder(BorderStyle.Single, 0.5f);
            table.SetOuterBorder(BorderStyle.Single, 1.5f);

            for (var i = 0; i < table.RowCount; i++)
            {
                for (var j = 0; j < table.ColCount; j++)
                {
                    table.Cell(i, j).HorizontalAlignment = HorizontalAlignment.Center;
                    table.Cell(i, j).VerticalAlignment = VerticalAlignment.Middle;
                    table.Cell(i, j).DefaultCharFormat.Font = document.CreateFont("Times New Roman");
                    table.Cell(i, j).DefaultCharFormat.AnsiFont = document.CreateFont("Times New Roman");
                    ;
                    table.Cell(i, j).DefaultCharFormat.FontSize = fontSize;
                }
                table.SetRowKeepInSamePage(i, true);
            }

            table.HorizontalAlignment = HorizontalAlignment.Distributed;

            for (var col = 0; col < table.ColCount; col++)
            {
                table.SetOuterBorder(col, 0, 1, table.RowCount, BorderStyle.Single, 1.5f);
            }

            old_CreateTableTitle(table);
            old_FillDataTable(table, roadrepairs);
        }

        private static void old_CreateTableTitle(RtfTable table)
        {
            for (var j = 0; j < table.ColCount; j++)
            {
                for (var i = 0; i < 2; i++)
                {
                    table.Cell(i, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
                }
            }
            RTFWorkingProvider.AddTextToCell(0, 0, table, "№ п/п");
            RTFWorkingProvider.AddTextToCell(0, 1, table, "Идентификатор");
            RTFWorkingProvider.AddTextToCell(0, 2, table, "Тип ремонта");
            RTFWorkingProvider.AddTextToCell(0, 3, table, "Тип работ");
            RTFWorkingProvider.AddTextToCell(0, 4, table, "Описание работ");
            RTFWorkingProvider.AddTextToCell(0, 5, table, "Статус ремонта");
            RTFWorkingProvider.AddTextToCell(0, 6, table, "Адрес");
            RTFWorkingProvider.AddTextToCell(0, 7, table, "Дата начала");
            RTFWorkingProvider.AddTextToCell(0, 8, table, "Дата окончания");
            RTFWorkingProvider.AddTextToCell(0, 9, table, "Дата начала фактическая");
            RTFWorkingProvider.AddTextToCell(0, 10, table, "Дата окончания фактическая");
            RTFWorkingProvider.AddTextToCell(0, 11, table, "Исполнитель");
            RTFWorkingProvider.AddTextToCell(0, 12, table, "Заказчик");
            RTFWorkingProvider.AddTextToCell(0, 13, table, "Владелец автодороги");


            for (var i = 0; i < table.ColCount; i++)
            {
                RTFWorkingProvider.AddTextToCell(1, i, table, (i + 1).ToString());
            }

        }

        private static void old_FillDataTable(RtfTable table, IList<RoadRepairDTO> roadrepairs)
        {
            var i = 2;
            foreach (var rr in roadrepairs)
            {
                RTFWorkingProvider.AddTextToCell(i, 0, table, (i - 1).ToString());
                RTFWorkingProvider.AddTextToCell(i, 1, table, rr.RoadRepairId.ToString());
                RTFWorkingProvider.AddTextToCell(i, 2, table, RepairTypeHelper.GetName(rr.RepairType));
                RTFWorkingProvider.AddTextToCell(i, 3, table, WorkTypeHelper.GetName(rr.WorkType));
                RTFWorkingProvider.AddTextToCell(i, 4, table, rr.WorkSort);
                RTFWorkingProvider.AddTextToCell(i, 5, table, StatusTypeHelper.GetName(rr.Status));
                RTFWorkingProvider.AddTextToCell(i, 6, table, rr.Address==null?"Не определён":rr.Address.FullAddress);
                RTFWorkingProvider.AddTextToCell(i, 7, table, rr.RepairStart?.ToShortDateString() ?? "");
                RTFWorkingProvider.AddTextToCell(i, 8, table, rr.RepairEnd?.ToShortDateString() ?? "");
                RTFWorkingProvider.AddTextToCell(i, 9, table, rr.RepairStartFact?.ToShortDateString() ?? "");
                RTFWorkingProvider.AddTextToCell(i, 10, table, rr.RepairEndFact?.ToShortDateString() ?? "");
                RTFWorkingProvider.AddTextToCell(i, 11, table, rr.Performer==null? "Не определён":rr.Performer.Name);
                RTFWorkingProvider.AddTextToCell(i, 12, table, rr.Customer == null ? "Не определён" : rr.Customer.Name);
                RTFWorkingProvider.AddTextToCell(i, 13, table, rr.Owner == null ? "Не определён" : rr.Owner.Name);
                i++;
            }
        }

        #endregion
    }
}