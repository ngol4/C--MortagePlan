using NUnit.Framework;
using MortgagePlan;

namespace MortgagePlan.Tests
{
    [TestFixture]
    public class MortgagePlanTests
    {
        [TestCase("Juha", 1000, 5, 2, 50.34)]
        [TestCase("Karvinen", 4356, 1.27, 6, 69.47)]
        [TestCase("Claes Månsson", 1300.55, 8.67, 2, 68.33)]
        [TestCase("Clarencé,Andersson", 2000, 6, 4, 51.67)]
        public void MonthlyPayment_ReturnsCorrectMonthlyPayment(string customerName, double totalLoan, double yearlyInterestRate, int numberOfYears, double expectedResult)
        {
            var mortgagePlan = new MortgagePlan.mo
            {
                CustomerName = customerName,
                TotalLoan = totalLoan,
                YearlyInterestRate = yearlyInterestRate,
                NumberOfYears = numberOfYears
            };

            double result = mortgagePlan.MonthlyPayment();
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.01));
        }
    }
}
