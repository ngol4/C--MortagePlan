using System;
using System.IO;
using MortgagePlan;
using System.Linq;

try
{
    string filePath = "prospects.txt";
    string[] lines = File.ReadAllLines(filePath);
    lines = lines.Skip(1).ToArray();



    int prospectCounter = 1;
    foreach (string line in lines)
    {
        try
        {
            string[] prospectDetails = line.Split(',');
            MortgagePlan.MortgagePlan_ mortgagePlan = new MortgagePlan.MortgagePlan_();

            mortgagePlan.CustomerName = prospectDetails[0];
            mortgagePlan.TotalLoan = double.Parse(prospectDetails[1]);
            mortgagePlan.YearlyInterestRate = double.Parse(prospectDetails[2]);
            mortgagePlan.NumberOfYears = int.Parse(prospectDetails[3]);

            Console.WriteLine("Prospect " + prospectCounter + ": " + mortgagePlan.CustomerName + " wants to borrow " + mortgagePlan.TotalLoan + " € for a period of " + mortgagePlan.NumberOfYears + " years and pay " + mortgagePlan.MonthlyPayment() + " € each month");
            prospectCounter++;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error in line " + prospectCounter + ": " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error in line " + prospectCounter + ": " + ex.Message);
        }
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
