using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class WaitingTimeCalculatorSpec
    {

        [Theory]
        [InlineData(2, 0, new[]{100/3600.0, 119/3600.0, 120/3600.0, 121/3600.0})]
        [InlineData(1, 1, new[]{100/3600.0, 119/3600.0, 120/3600.0, 121/3600.0})]
        [InlineData(0, 4, new[]{100/3600.0, 119/3600.0, 120/3600.0, 121/3600.0})]
        [InlineData(0, 5, new[]{100/3600.0, 119/3600.0, 120/3600.0, 121/3600.0})]
        void should_calculate_waiting_time_when_speed_is_lower_than_120_km_per_hour(int waitingSeconds, int startIndex, double[] kilosBySecond)
        {
            var waitingTimeCalculator = new WaitingTimeCalculator(kilosBySecond);

            Assert.Equal(waitingSeconds, waitingTimeCalculator.CalcWaitingTime(startIndex, kilosBySecond.Length));
        }
        
        [Theory]
        [InlineData(2, 0, new[]{100/3600.0, 119/3600.0, 120/3600.0, 121/3600.0})]
        [InlineData(0, 0.1, new[]{121/3600.0, 120/3600.0, 119/3600.0, 121/3600.0})]
        [InlineData(1, 0.1, new[]{121/3600.0, 120/3600.0, 119/3600.0, 121/3600.0, 119/3600.0})]
        void should_calculate_waiting_time_ignoring_starting_mileage_and_considering_speed(int waitingSeconds, double startMileages, double[] kilosBySecond)
        {
            var waitingTimeCalculator = new WaitingTimeCalculator(kilosBySecond);

            Assert.Equal(waitingSeconds, waitingTimeCalculator.CalcWaitingTime(startMileages));
        }
    }
}