using System;

namespace TaxiPriceCalculator
{
    public class TaxiPriceCalculator
   
    {
        private const int BaseDistance = 2;
        private const int BasePrice = 3;
        private const int AdditionalFee = 1;
        public double Cost(double totalKilos, double waitingTime)
        {
            var addtionalFeeToAdd = totalKilos - BaseDistance > 0 ? AdditionalFee : 0;
            var waitingFee = Math.Ceiling(waitingTime) * 1;
            return Math.Ceiling(Math.Max(totalKilos-BaseDistance,0)) * 1 + BasePrice + addtionalFeeToAdd + waitingFee;
        }

        public double Cost(double totalKilos, double[] kilosBySeconds)
        {
            return Cost(totalKilos, new WaitingTimeCalculator(kilosBySeconds).CalcWaitingTime(BaseDistance));
        }
    }
}