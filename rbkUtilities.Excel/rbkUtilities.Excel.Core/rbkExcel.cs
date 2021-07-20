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

namespace rbkUtilities.Excel.Core
{
    [PMLNetCallable]
    public class rbkExcel
    {
        private string _message;
        private string _separator;
        private int[] _sortColumns;
        private List<WorksheetData> _data; 

        [PMLNetCallable]
        public rbkExcel()
        {
            _separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            _data = new List<WorksheetData>();
        }

        [PMLNetCallable]
        public void Assign(rbkExcel that)
        {
            
        }

        [PMLNetCallable]
        public void SetData(string worksheet, Hashtable rawData)
        {
            var data = rawData.ToList<string>();
        }

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
        public void SetSeparator(string separator)
        {
            _separator = separator;
        }

        [PMLNetCallable]
        public void SetSort(Hashtable sortingColumns)
        {
            _sortColumns = sortingColumns.ToList<int>().Select(x => x - 1).ToArray();
        }

        [PMLNetCallable]
        public bool Generate(string path)
        {
            var result = false;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (var excel = new ExcelPackage())
                {
                    foreach (var worksheetData in _data)
                    {
                        var ws = excel.Workbook.Worksheets.Add(worksheetData.Name);

                        ws.View.ShowGridLines = false;

                        var headerRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + "1";
                        ws.Cells[headerRange].LoadFromArrays(new List<object[]> { worksheetData.Headers });

                        var fullRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + (worksheetData.Data.Count + 1).ToString();
                        var bodyRange = "A2:" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + (worksheetData.Data.Count + 1).ToString();
                        ws.Cells[2, 1].LoadFromArrays(worksheetData.Data);
                        ws.Cells[bodyRange].Sort(_sortColumns);

                        ws.Cells[headerRange].Style.Font.Bold = true;
                        ws.Cells[headerRange].Style.Font.Color.SetColor(Color.White);
                        ws.Cells[headerRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[headerRange].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 48, 48, 48));

                        ws.Cells[fullRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        // ws.Cells[fullRange].Style.Border.Top.Style = ExcelBorderStyle.Dotted;

                        ws.Cells[headerRange].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                        var fullFormatingRange = "A1:" + Char.ConvertFromUtf32(worksheetData.Headers.Length - 1 + 64) + (worksheetData.Data.Count + 1).ToString();
                        ws.Cells[fullFormatingRange].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        for (int i = 3; i <= worksheetData.Data.Count + 1; i = i + 2)
                        {
                            var rowRange = "A" + i + ":" + Char.ConvertFromUtf32(worksheetData.Headers.Length + 64) + i;
                            ws.Cells[rowRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[rowRange].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }

                        ws.Cells[fullRange].AutoFitColumns();
                        ws.Cells[fullRange].AutoFilter = true;

                        ws.View.FreezePanes(2, 1);
                    }
                    
                    FileInfo excelFile = new FileInfo(path);
                    excel.SaveAs(excelFile);
                }


                result = true;
            }
            catch (Exception ex)
            {
                _message = ex.Message;
            }

            return result;
        }

        [PMLNetCallable]
        public bool Generate(string path, bool open)
        {
            var result = Generate(path);
            
            if (result && open)
            {
                bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;

                if (isExcelInstalled)
                {
                    Process.Start(path);
                }
            }

            return result;
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
        public List<string[]> Data { get; set; }
    }
}