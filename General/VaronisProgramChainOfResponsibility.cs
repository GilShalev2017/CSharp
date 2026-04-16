using System;


// Handler interface
interface ITaxCalculator
{
    void SetNext(ITaxCalculator next);
    decimal CalculateTax(decimal salary);
}

// Concrete handler: Basic tax calculator
class BasicTaxCalculator : ITaxCalculator
{
    private ITaxCalculator next;

    public void SetNext(ITaxCalculator next)
    {
        this.next = next;
    }

    public decimal CalculateTax(decimal salary)
    {
        if (salary <= 1000)
        {
            return salary * 0.1m; // 10% tax
        }
        else if (next != null)
        {
            return next.CalculateTax(salary);
        }
        else
        {
            throw new Exception("No suitable tax calculator found for the salary");
        }
    }
}

// Concrete handler: Advanced tax calculator
class AdvancedTaxCalculator : ITaxCalculator
{
    private ITaxCalculator next;

    public void SetNext(ITaxCalculator next)
    {
        this.next = next;
    }

    public decimal CalculateTax(decimal salary)
    {
        if (salary > 1000 && salary <= 5000)
        {
            return salary * 0.2m; // 20% tax
        }
        else if (next != null)
        {
            return next.CalculateTax(salary);
        }
        else
        {
            throw new Exception("No suitable tax calculator found for the salary");
        }
    }
}

// Concrete handler: Premium tax calculator
class PremiumTaxCalculator : ITaxCalculator
{
    private ITaxCalculator next;

    public void SetNext(ITaxCalculator next)
    {
        this.next = next;
    }

    public decimal CalculateTax(decimal salary)
    {
        if (salary > 5000)
        {
            return salary * 0.3m; // 30% tax
        }
        else if (next != null)
        {
            return next.CalculateTax(salary);
        }
        else
        {
            throw new Exception("No suitable tax calculator found for the salary");
        }
    }
}
/*
class Program
{
    
    static void Main()
    {
        // Build the chain of tax calculators
        ITaxCalculator basicTaxCalculator = new BasicTaxCalculator();
        ITaxCalculator advancedTaxCalculator = new AdvancedTaxCalculator();
        ITaxCalculator premiumTaxCalculator = new PremiumTaxCalculator();

        basicTaxCalculator.SetNext(advancedTaxCalculator);
        advancedTaxCalculator.SetNext(premiumTaxCalculator);

        // Calculate taxes
        decimal salary = 3000;
        decimal tax = basicTaxCalculator.CalculateTax(salary);

        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Tax: {tax}");
    }
    
}
*/