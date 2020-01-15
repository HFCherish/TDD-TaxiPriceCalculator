using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class TaxiPriceCalculatorSpec
    {

        [Theory]
        [InlineData(0, 3)]
        [InlineData(2, 3)]
        public void should_return_correct_price_based_on_distance_without_additional_fee(double distance, double price)
        {
            var taxiPriceCalculator = new TaxiPriceCalculator();
            Assert.Equal(price, taxiPriceCalculator.Cost(distance, 0));
        }
        
        [Theory]
        [InlineData(2.1, 5)]
        [InlineData(5, 7)]
        public void should_return_correct_price_based_on_distance_with_additional_fee_without_waiting_fee(double distance, double price)
        {
            var taxiPriceCalculator = new TaxiPriceCalculator();
            Assert.Equal(price, taxiPriceCalculator.Cost(distance, 0));
        }
        
        [Theory]
        [InlineData(2.1, 10, 15)]
        [InlineData(5, 10.2, 18)]
        public void should_return_correct_price_based_on_distance_with_additional_fee_and_waiting_time(double distance, double waitingTime, double price)
        {
            var taxiPriceCalculator = new TaxiPriceCalculator();
            Assert.Equal(price, taxiPriceCalculator.Cost(distance, waitingTime));
        }

    }
    
}