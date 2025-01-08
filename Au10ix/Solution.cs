using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Net;
using System.Net.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//using Newtonsoft.Json;
//using System.Transactions;

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
//        int pageNumber = 1;
//        int sum = 0;
//        int count = 0;
//        int totalPages = 1;

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
       
//        return (sum / count);
//    }

//}


//class Solution
//{
//    public async static Task Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        string diagnosisName = Console.ReadLine();

//        int doctorId = Convert.ToInt32(Console.ReadLine().Trim());

//        int result = await Result.pulseRate(diagnosisName, doctorId);

//        textWriter.WriteLine(result);

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}

/*

SET NOCOUNT ON;


/*
Enter your query below.
Please append a semicolon ";" at the end of the query
*/

//go
//select address, count(*) as transactions, sum(amount) as balance
//from wallets W join transactions T
//on W.id = T.wallet_id
//where T.confirmations >= 10
//group by W.id, W.address
//having sum(amount) >= 0
//order by sum(amount) desc