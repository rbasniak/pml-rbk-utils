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
using System.Drawing;

namespace rbkUtilities.Log.Core
{
    [PMLNetCallable]
    public class rbkLog
    {
        private string _filename;
        private bool _includeDate;

        [PMLNetCallable]
        public rbkLog()
        {
        }

        [PMLNetCallable]
        public void Assign(rbkLog that)
        {
            
        } 

        [PMLNetCallable]
        public void Append(string text)
        {
            try
            {
                File.AppendAllText(_filename, $"{Environment.NewLine}{(_includeDate ? DateTime.Now.ToString() : String.Empty)}: {text}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [PMLNetCallable]
        public void SetFilename(string filename)
        {
            _filename = filename;
        }

        [PMLNetCallable]
        public void IncludeDate()
        {
            _includeDate = true;
        }
    }
}