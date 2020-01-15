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
        
        [Theory]
        [InlineData(7, 2.1, new[]{1000/3600.0, 2000/3600.0, 5000/3600.0, 119/3600.0, 120/3600.0, 121/3600.0, 119/3600.0})]
        public void should_return_correct_price_based_on_distance_with_additional_fee_and_waiting_time_given_kilos_by_seconds(double price, double distance, double[] kilosBySeconds)
        {
            var taxiPriceCalculator = new TaxiPriceCalculator();
            Assert.Equal(price, taxiPriceCalculator.Cost(distance, kilosBySeconds));
        }
        

    }
    
}