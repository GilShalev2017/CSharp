using Newtonsoft.Json;

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


internal class Program
{
    /*
     * Complete the 'pulseRate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING diagnosisName
     *  2. INTEGER doctorId
     * API URL: https://jsonmock.hackerrank.com/api/medical_records?page={page_no}
     */
    public async static Task<int> pulseRate(string diagnosisName, int doctorId)
    {
        int pageNumber = 1;
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
        
        return (sum / count);
    }

    static async Task Main(string[] args)
    {
        int result1 = await pulseRate("Pulmonary embolism", 2);
        int result2 = await pulseRate("Common Cold", 2);
    }

}