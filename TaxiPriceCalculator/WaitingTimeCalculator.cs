using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxiPriceCalculator
{
    public class WaitingTimeCalculator
    {
        private const int WAITING_SPEED_THRESHOLD = 120;    // km/s
        private readonly List<double> _kilosBySecond;

        public WaitingTimeCalculator(double[] kilosBySecond)
        {
            _kilosBySecond = kilosBySecond.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="startIndex">included</param>
        /// <param name="endIndex">excluded</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public long CalcWaitingTime(int startIndex, int endIndex)
        {
            return _kilosBySecond
                .GetRange(startIndex, endIndex - startIndex)
                .Count(k => k * 3600 < WAITING_SPEED_THRESHOLD);
        }
    }
}