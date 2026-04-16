//using System;

// Define a custom EventArgs to pass stock information
public class StockChangedEventArgs : EventArgs
{
    public string Symbol { get; }
    public double Price { get; }

    public StockChangedEventArgs(string symbol, double price)
    {
        Symbol = symbol;
        Price = price;
    }
}

// Define the stock class
public class Stock
{
    private double price;

    public string Symbol { get; }
    public double Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                price = value;
                OnPriceChanged(new StockChangedEventArgs(Symbol, price));
            }
        }
    }

    // Define an event to notify the observers (investors) when the price changes
    public event EventHandler<StockChangedEventArgs> PriceChanged;

    protected virtual void OnPriceChanged(StockChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }

    public Stock(string symbol, double price)
    {
        Symbol = symbol;
        Price = price;
    }
}

// Define the Investor class as an observer
public class Investor
{
    private string name;

    public Investor(string name)
    {
        this.name = name;
    }

    // When the price changes, this method will be called
    public void Stock_PriceChanged(object sender, StockChangedEventArgs e)
    {
        Console.WriteLine($"[{name}] - Stock {e.Symbol} price changed to {e.Price}");
    }
}

/*
class Program
{
    static void Main()
    {
        // Create the stock and investor objects
        var stock = new Stock("AAPL", 150.50);
        var investor1 = new Investor("John");
        var investor2 = new Investor("Alice");

        // Subscribe the investors to the stock's PriceChanged event
        stock.PriceChanged += investor1.Stock_PriceChanged;
        stock.PriceChanged += investor2.Stock_PriceChanged;

        // Simulate stock price changes
        stock.Price = 152.00; // Investors will be notified of the change
        stock.Price = 154.50; // Investors will be notified of the change

        // Unsubscribe the investors from the stock's PriceChanged event
        stock.PriceChanged -= investor1.Stock_PriceChanged;
        stock.PriceChanged -= investor2.Stock_PriceChanged;
    }
}
*/


//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Text.RegularExpressions;
//using System.Text;
//using System;
//using System.Net;
//using System.Net.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//using Newtonsoft.Json;

//public class Diagnosis
//{
//    public string name { get; set; }
//}
//public class Vitals
//{
//    public int pulse { get; set; }
//}
//public class Doctor
//{
//    public int id { get; set; }
//}
//public class UserData
//{
//    public int Id { get; set; }
//    public Diagnosis diagnosis { get; set; }
//    public Vitals vitals { get; set; }
//    public Doctor doctor { get; set; }
//    public int userId { get; set; }
//}
//public class ApiResponse
//{
//    public int page { get; set; }
//    public int per_page { get; set; }
//    public int total { get; set; }
//    public int total_pages { get; set; }
//    public List<UserData> data { get; set; }
//}

//class Result
//{

//    /*
//     * Complete the 'pulseRate' function below.
//     *
//     * The function is expected to return an INTEGER.
//     * The function accepts following parameters:
//     *  1. STRING diagnosisName
//     *  2. INTEGER doctorId
//     * API URL: https://jsonmock.hackerrank.com/api/medical_records?page={page_no}
//     */


//    public async static Task<int> pulseRate(string diagnosisName, int doctorId)
//    {
//        int pageNumber = 0;
//        int sum = 0;
//        int count = 0;
//        int totalPages = 0;

//        using (HttpClient httpClient = new HttpClient())
//        {
//            while (pageNumber <= totalPages)
//            {
//                string apiUrl = "https://jsonmock.hackerrank.com/api/medical_records?page=" + pageNumber;

//                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

//                if (response.IsSuccessStatusCode)
//                {
//                    string apiResponse = await response.Content.ReadAsStringAsync();

//                    ApiResponse res = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);

//                    totalPages = res.total_pages;

//                    var pulses = res!.data
//                                .Where(d => d.doctor.id == doctorId && d.diagnosis.name == diagnosisName)
//                                .Select(d => d.vitals.pulse).ToList();

//                    sum += pulses.Sum();

//                    count += pulses.Count();

//                }
//                else
//                {
//                    Console.WriteLine("Error: " + response.StatusCode);
//                    break;
//                }

//                pageNumber++;
//            }
//        }

//        return (int)(sum / count);
//    }

//}
