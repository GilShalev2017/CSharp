using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Au10ix
{
    class Program
    {
        public class Diagnosis
        {
            public string name { get; set; }
        }
        public class Vitals
        {
            public int pulse { get; set; }
        }
        public class Doctor
        {
            public int id { get; set; }
        }
        public class UserData
        {
            public int Id { get; set; }
            public Diagnosis diagnosis { get; set; }
            public Vitals vitals { get; set; }
            public Doctor doctor { get; set; }
            public int userId { get; set; }
        }
        public class ApiResponse
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<UserData> data { get; set; }
        }
        public static async Task<int> pulseRateAsync(string diagnosisName, int doctorId)
        {
            int pageNumber = 1; //API starts from pageNumber=1
            int sum = 0;
            int count = 0;
            int totalPages = 1;

            using (HttpClient httpClient = new HttpClient())
            {
                while (pageNumber <= totalPages)
                {
                    string apiUrl = "https://jsonmock.hackerrank.com/api/medical_records?page=" + pageNumber;
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        ApiResponse res = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);

                        totalPages = res.total_pages;

                        var pulses = res!.data
                                    .Where(d => d.doctor.id == doctorId && d.diagnosis.name == diagnosisName)
                                    .Select(d => d.vitals.pulse).ToList();

                        sum += pulses.Sum();

                        count += pulses.Count();

                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                        break;
                    }

                    pageNumber++;
                }
            }

            return (int)(sum / count);
        }

        static async Task Main()
        {
            Console.WriteLine("HELLO MAIN");

            var res = await pulseRateAsync("Common Cold", 2);

            Console.WriteLine("average pool = " + res);
        }
    }
}