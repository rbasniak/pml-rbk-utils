using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aveva.Core.PMLNet;
using System.IO;
using System.Collections;
using Aveva.Core.Presentation;
using System.Diagnostics;
using System.Globalization;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;

namespace rbkPmlUtilities.Excel
{
    [PMLNetCallable]
    public class rbkExcel
    {
        public Guid Id;

        private List<WorksheetData> _data; 

        [PMLNetCallable]
        public rbkExcel()
        {
            _data = new List<WorksheetData>();
            Id = Guid.NewGuid();
        }

        [PMLNetCallable]
        public void Assign(rbkExcel that)
        {
            
        }

        //[PMLNetCallable]
        //public void SetData(string worksheet, Hashtable rawData)
        //{
        //    _data.Add(new WorksheetData(worksheet) { Data = rawData.ToList<string>().ToArray() });
        //}

        [PMLNetCallable]
        public void AppendData(string worksheet, Hashtable rawData)
        {
            var ws = GetWorksheet(worksheet);

            ws.Data.Add(rawData.ToList<string>().ToArray()); 
        }

        [PMLNetCallable]
        public void SetHeaders(string worksheet, Hashtable rawData)
        {
            var ws = GetWorksheet(worksheet);

            ws.Headers = rawData.ToList<string>().ToArray();
        } 

        [PMLNetCallable]
        public void SetSort(string worksheet, Hashtable sortingColumns)
        {
            var ws = GetWorksheet(worksheet);

            ws.SortColumns = sortingColumns.ToList<double>().Select(x => x - 1).Select(x => (int)x).ToArray();
        }

        [PMLNetCallable]
        public void Generate(string path)
        { 
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (var excel = new ExcelPackage())
            {
                foreach (var worksheetData in _data)
                {
                    var ws = excel.Workbook.Worksheets.Add(worksheetData.Name);

                    ws.View.ShowGridLines = false;

                    if (worksheetData.Headers == null || worksheetData.Headers.Length == 0)
                    {
                        throw new ApplicationException($"No headers set for '{worksheetData.Name}'");
                    }

                    var headerRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + "1";
                    ws.Cells[headerRange].LoadFromArrays(new List<object[]> { worksheetData.Headers });

                    var fullRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + (worksheetData.Data.Count + 1).ToString();

                    if (worksheetData.Data != null && worksheetData.Data.Count > 0)
                    {
                        var bodyRange = "A2:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + (worksheetData.Data.Count + 1).ToString();
                        ws.Cells[2, 1].LoadFromArrays(worksheetData.Data);
                        if (worksheetData.SortColumns != null && worksheetData.SortColumns.Length > 0)
                        {
                            ws.Cells[bodyRange].Sort(worksheetData.SortColumns);
                        }

                        for (int i = 3; i <= worksheetData.Data.Count + 1; i = i + 2)
                        {
                            var rowRange = "A" + i + ":" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + i;
                            ws.Cells[rowRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[rowRange].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }
                    }

                    ws.Cells[headerRange].Style.Font.Bold = true;
                    ws.Cells[headerRange].Style.Font.Color.SetColor(Color.White);
                    ws.Cells[headerRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[headerRange].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 48, 48, 48));

                    ws.Cells[fullRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    // ws.Cells[fullRange].Style.Border.Top.Style = ExcelBorderStyle.Dotted;

                    ws.Cells[headerRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                    var fullFormatingRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length - 1 + 64) + (worksheetData.Data.Count + 1).ToString();
                    ws.Cells[fullFormatingRange].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    ws.Cells[fullRange].AutoFitColumns();
                    ws.Cells[fullRange].AutoFilter = true;

                    ws.View.FreezePanes(2, 1);
                }
                    
                FileInfo excelFile = new FileInfo(path);
                excel.SaveAs(excelFile);
            }
        }

        [PMLNetCallable]
        public void Generate(string path, bool open)
        {
            Generate(path);
            
            if (open)
            {
                bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;

                if (isExcelInstalled)
                {
                    Process.Start(path);
                }
            }
        }

        private WorksheetData GetWorksheet(string worksheet)
        {
            var ws = _data.SingleOrDefault(x => x.Name.ToUpper() == worksheet.ToUpper());

            if (ws == null)
            {
                ws = AddWorksheet(worksheet);
            }

            return ws;
        }

        private WorksheetData AddWorksheet(string name)
        {
            var ws = new WorksheetData(name);
            _data.Add(ws);

            return ws;
        }
    }

    internal class WorksheetData
    {
        public WorksheetData(string name)
        {
            Name = name;
            Data = new List<string[]>();
        }

        public string Name { get; set; }
        public string[] Headers { get; set; }
        public int[] SortColumns { get; set; }
        public List<string[]> Data { get; set; }
    }
}