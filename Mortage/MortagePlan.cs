using System;

namespace MortgagePlan;

public class MortgagePlan_
{
    public string? CustomerName { get; set; }
    public double TotalLoan { get; set; }
    public double YearlyInterestRate { get; set; }
    public int NumberOfYears { get; set; }



    public static double powerOptimised(double a, int n)
    {
        double answer = 1;

        while (n > 0)
        {
            int last_bit = (n & 1);

            // Check if current LSB
            // is set
            if (last_bit > 0)
            {
                answer = answer * a;
            }
            a = a * a;

            // Right shift
            n = n >> 1;
        }
        return answer;
    }

    public double MonthlyPayment()
    {
        double c = YearlyInterestRate / 12 / 100;
        int n = NumberOfYears * 12;
        double monthlyPayment = TotalLoan * c * powerOptimised(1 + c, n) / (powerOptimised(1 + c, n) - 1);
        return monthlyPayment;
    }
}
