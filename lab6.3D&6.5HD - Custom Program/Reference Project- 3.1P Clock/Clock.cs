using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocks
{
    public class Clock
    {
        private Counter[] _counters;
        private int _input_time;
        private bool _paused;


        public Clock(int input_time)
        {
            _counters = new Counter[3];
            _counters[0] = new Counter("Second counter");
            _counters[1] = new Counter("Minute counter");
            _counters[2] = new Counter("Hour counter");

            _input_time = input_time;
            SetTime(input_time);
        }

        private void SetTime(int total_time)
        {
            int hours = total_time / 3600;
            int minutes = (total_time % 3600) / 60;
            int seconds = total_time % 60;

            _counters[2].Set(hours);
            _counters[1].Set(minutes);
            _counters[0].Set(seconds);
        }

        public bool IsTimeUp { get; private set; } = false;

        public void Tick()
        {
            if (IsTimeUp) return;

            _counters[0].Decrement();

            if (_counters[0].Ticks < 0)
            {
                _counters[0].Set(59);
                _counters[1].Decrement();
            }

            if (_counters[1].Ticks < 0)
            {
                _counters[1].Set(59);
                _counters[2].Decrement();
            }

            if (_counters[2].Ticks < 0)
            {
                IsTimeUp = true;
                _counters[2].Set(0);
                _counters[1].Set(0);
                _counters[0].Set(0);
            }
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Resume()
        {
            _paused = false;
        }

        public bool Flaged()
        {
            return IsTimeUp;
        }

        public string Show()
        {
            return $"{_counters[2].Ticks:D2}:{_counters[1].Ticks:D2}:{_counters[0].Ticks:D2}";
        }


    }

}



    


