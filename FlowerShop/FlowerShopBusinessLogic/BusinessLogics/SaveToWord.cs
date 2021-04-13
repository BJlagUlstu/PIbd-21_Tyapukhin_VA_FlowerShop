using FlowerShopBusinessLogic.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    static class SaveToWord
    {
        // Создание документа
        public static void CreateDoc(WordInfo info)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties {Bold = true, Size = "30" } ) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "30",
                        JustificationValues = JustificationValues.Center
                    }
                }));
                if (info.Storehouses != null)
                {
                    Table table = new Table();
                    TableProperties tableProp = new TableProperties();
                    TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };

                    table.AppendChild(CreateTableBorders());

                    TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

                    tableProp.Append(tableStyle, tableWidth);
                    table.AppendChild(tableProp);

                    TableGrid tg = new TableGrid(new GridColumn(), new GridColumn(), new GridColumn());
                    table.AppendChild(tg);

                    table.AppendChild(CreateTableRow(new List<string>() {"Название", "ФИО ответственного", "Дата создания"}, true));

                    foreach (var storehouse in info.Storehouses)
                    {
                        table.AppendChild(CreateTableRow(new List<string>() {
                            storehouse.StorehouseName,
                            storehouse.FullName,
                            storehouse.DateCreate.ToString()
                        }, false));
                    }
                    docBody.AppendChild(table);
                    docBody.AppendChild(CreateSectionProperties());
                }
                wordDocument.MainDocumentPart.Document.Save();
            }
        }
        // Настройки страницы
        private static SectionProperties CreateSectionProperties()
        {
            SectionProperties properties = new SectionProperties();
            PageSize pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        // Создание абзаца с текстом
        private static Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                Paragraph docParagraph = new Paragraph();
                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    Run docRun = new Run();
                    RunProperties properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }
            return null;
        }
        // Задание форматирования для абзаца
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                ParagraphProperties properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = paragraphProperties.JustificationValues
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                ParagraphMarkRunProperties paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val = paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }
        private static TableRow CreateTableRow(List<string> texts, bool header)
        {
            TableRow tr = new TableRow();
            foreach (string text in texts)
            {
                if (header)
                {
                    TableCell tc = new TableCell(CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { (text, new WordTextProperties { Bold = true, Size = "28" }) },
                        TextProperties = new WordTextProperties
                        {
                            Size = "28",
                            JustificationValues = JustificationValues.Both
                        }
                    }));
                    tr.Append(tc);
                } 
                else
                {
                    TableCell tc = new TableCell(CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { (text, new WordTextProperties { Size = "24" }) },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationValues = JustificationValues.Both
                        }
                    }));
                    tr.Append(tc);
                }
            }
            return tr;
        }
        private static TableBorders CreateTableBorders()
        {
            TableBorders tableBorders = new TableBorders();

            BottomBorder bottomBorder = new BottomBorder();
            bottomBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            bottomBorder.Color = "000000";

            tableBorders.AppendChild(bottomBorder);

            TopBorder topBorder = new TopBorder();
            topBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            topBorder.Color = "000000";

            tableBorders.AppendChild(topBorder);

            InsideHorizontalBorder insHorBorder = new InsideHorizontalBorder();
            insHorBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            insHorBorder.Color = "000000";

            tableBorders.AppendChild(insHorBorder);

            InsideVerticalBorder insVerBorder = new InsideVerticalBorder();
            insVerBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            insVerBorder.Color = "000000";

            tableBorders.AppendChild(insVerBorder);

            LeftBorder leftBorder = new LeftBorder();
            leftBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            leftBorder.Color = "000000";

            tableBorders.AppendChild(leftBorder);

            RightBorder rightBorder = new RightBorder();
            rightBorder.Val = new EnumValue<BorderValues>(BorderValues.ThickThinMediumGap);
            rightBorder.Color = "000000";

            tableBorders.AppendChild(rightBorder);
            return tableBorders;
        }
    }
}