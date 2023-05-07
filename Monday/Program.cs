//using Nancy.Json;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;

//namespace Monday
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");

//            var columnIdsToValues = new
//            {
//                text = "approved",
//                status = "Done",
//                vacationDays = 1,
//                holidays = 2
//            };

//            var serializedObject = JsonConvert.SerializeObject(columnIdsToValues);

//            const string formula = "CONCATENATE(\"Total: \" , sum( holidays, vacationDays)";

//            //PopulateValues(formula, columnIdsToValues);

//            //PopulateValues2(formula, serializedObject);

//            string tests = "abc][rfd][5][,][.";
//            string[] reslts = formula.Split(new char[] { ',', '(', ')', '\\' });//, StringSplitOptions.RemoveEmptyEntries);

//            PopulateValues3(formula, columnIdsToValues);
//        }

//        static void PopulateValues3(string formula, dynamic columnIdsToValues)
//        {
//            var splits = formula.Split(new char[] { ',','(',')','\\' },StringSplitOptions.None);
//            string[] parts2 = Regex.Split(formula, @"\(\)");
//        }

//        static void PopulateValues2(string formula, string serializedObject)
//        {

//        }
//        static void PopulateValues(string formula, dynamic columnIdsToValues)
//        {
//            Dictionary<string,dynamic> dic = new Dictionary<string, dynamic>();

//            JavaScriptSerializer serializer = new JavaScriptSerializer();

//            dynamic myDynamicObject = serializer.DeserializeObject(columnIdsToValues);

//            var d = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(columnIdsToValues);

//            foreach (var key in d.Keys)
//            {

//            }

//        }
//    }
//}
