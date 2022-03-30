using Microsoft.VisualStudio.TestTools.UnitTesting;
using rbkPmlUtilities.Excel;
using rbkPmlUtilities.Excel;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbkPmlUtilities.Excel.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestFullGeneration()
        {
            var random = new Random(19001);

            var excel = new rbkExcel();

            excel.SetHeaders("Sheet1", new[] { "SITE", "ZONE", "NAME" }.ToHashtable());

            for (int i = 0; i < 50; i++)
            {
                excel.AppendData("Sheet1", new[] { "SITE" + random.Next(1, 10), "ZONE" + random.Next(1, 10), "NAME" + random.Next(1, 10) }.ToHashtable());
            }

            excel.SetSort("Sheet1", new[] { 1, 3, 2 }.ToHashtable());
            excel.Generate(@"D:\Repositories\pessoal\libraries\rbk-pml-utils\rbkUtilities.Excel\rbkUtilities.Excel.Core\bin\Debug\test.xlsx", true);
        }
    }
}
