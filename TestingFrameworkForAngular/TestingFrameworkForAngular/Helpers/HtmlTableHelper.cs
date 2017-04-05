using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using TestingFrameworkForAngular.Base;
using TestingFrameworkForAngular.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestingFrameworkForAngular.Helpers
{
    public class HtmlTableHelper
    {
        private static List<TableDatacollection> _tableDatacollections;
        private static List<string> _resultList;

        public static void ReadTable(string cssSelector)
        {
            //Initialize the table
            IHtmlDocument angle = new HtmlParser().Parse(DriverContext.NgDriver.PageSource);

            _tableDatacollections = new List<TableDatacollection>();

            //Get all the columns from the table
            var table = angle.QuerySelector(cssSelector);

            var columns = angle.QuerySelectorAll("th");

            //Get all the rows
            var rows = angle.QuerySelectorAll("tr");

            //Create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.QuerySelectorAll("td");

                //Store data only if it has value in the row
                if (colDatas.Count() != 0)
                {
                    foreach (var colValue in colDatas)
                    {
                        _tableDatacollections.Add(new TableDatacollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].TextContent != "" ?
                                         columns[colIndex].TextContent : colIndex.ToString(),
                            ColumnValue = colValue.TextContent,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        //Move to next column
                        colIndex++;
                    }
                }
                rowIndex++;
            }
        }

        private static ColumnSpecialValue GetControl(IElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;

            //Check if the control has specific tags like input/hyperlink etc
            if (columnValue.QuerySelectorAll("a").Count() > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.QuerySelectorAll("a"),
                    ControlType = "hyperlink"
                };
            }

            if (columnValue.QuerySelectorAll("input").Count() > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.QuerySelectorAll("input"),
                    ControlType = "input"
                };
            }

            return columnSpecialValue;
        }

        public static void PerformActionOnCell(string columnIndexOrName, string refColumnName, string refColumnValue,
                                               string cssSelector, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName.Trim() == columnIndexOrName && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();
                //Need to operate on those controls
                if (cell != null)
                {
                    //Since based on the control type, the retrieving of text changes
                    //created this kind of control
                    if (cell.ControlType == "hyperlink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.TextContent == controlToOperate || c.NodeName == "A"
                                               select c).SingleOrDefault();

                        //ToDo: Currently only click is supported, future is not taken care here
                        if (returnedControl != null)
                        {
                            DriverContext.NgDriver.FindElement(By.CssSelector(cssSelector + " tr:nth-child(" + rowNumber + ") a")).Clicks();
                        }
                    }

                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.TagName == controlToOperate || c.TagName == cell.ControlType.ToUpper()
                                               select c).SingleOrDefault();

                        //ToDo: Currently only click is supported, future is not taken care here
                        if (returnedControl != null)
                        {
                            DriverContext.NgDriver.FindElement(By.CssSelector(cssSelector + " tr:nth-child(" + rowNumber + ") input")).Clicks();
                        }
                    }
                }
                else
                {
                    //cell.ElementCollection?.FirstOrDefault().Click();
                }
            }
        }

        public static List<string> GetCellText(string columnIndexOrName, string refColumnName, string refColumnValue)
        {
            _resultList = new List<string>();

            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                _resultList.Add((from e in _tableDatacollections
                                 where e.ColumnName.Trim() == columnIndexOrName && e.RowNumber == rowNumber
                                 select e.ColumnValue).Single());
            }

            return _resultList;
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            //dynamic row
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName.Trim() == columnName && table.ColumnValue.Trim() == columnValue)
                {
                    yield return table.RowNumber;
                }
            }
        }
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }
}
