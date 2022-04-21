using Microsoft.VisualStudio.TestTools.UnitTesting;
using rbkUtilities.Log.Core;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbkUtilities.Log.Core.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestFullGeneration()
        {
            var logger = new rbkLog();

            logger.SetFilename(@"C:\Users\basniar\Documents\Development\delete.txt");
            logger.IncludeDate();
            logger.AppendLine("Lorem ipsum");
        }
    }
}
