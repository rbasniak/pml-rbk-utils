using Aveva.Core.PMLNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Threading;

namespace rbkPmlUtilities.Timer
{
    [PMLNetCallable]
    public class rbkTimer
    {
        private System.Timers.Timer _timer;
        private Dispatcher _avevaDispatcher;

        [PMLNetCallable]
        public event PMLNetDelegate.PMLNetEventHandler TimerElapsed;

        [PMLNetCallable]
        public rbkTimer()
        {
            _avevaDispatcher = Dispatcher.CurrentDispatcher;
        }

        [PMLNetCallable]
        public void Assign(rbkTimer that)
        {
        }

        [PMLNetCallable]
        public void Start(double interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += (object sender, ElapsedEventArgs e) => 
            {
                _avevaDispatcher.BeginInvoke(new Action(() => TimerElapsed?.Invoke(new ArrayList())));
            };
            _timer.Start();
        }

        [PMLNetCallable]
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
