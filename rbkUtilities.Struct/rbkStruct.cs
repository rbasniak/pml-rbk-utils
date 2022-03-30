using Aveva.Core.PMLNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rbkPmlUtilities.Struct
{
    [PMLNetCallable]
    public class rbkStruct
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        [PMLNetCallable]
        public rbkStruct()
        {

        }

        [PMLNetCallable]
        public void Assign(rbkStruct that)
        {
        }

        [PMLNetCallable]
        public void Set(string key, string value)
        {
            if (_data.TryGetValue(key, out _))
            {
                _data[key] = value;
            }
            else
            {
                _data.Add(key, value);
            }
        }

        [PMLNetCallable]
        public string Get(string key)
        {
            if (key == "null") return null;

            if (_data.TryGetValue(key, out string value))
            {
                return value;
            }
            else
            {
                return "";
            }
        }
    }
}
