using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args) //tu też trzeba dopisac async, żeby w var response mozna uzyc await
            //Task jest odpowiednikiem void, nic nie zwraca
        {
            /*
            Console.WriteLine("Hello World!");
            int? tmp1 = null; //gdy damy "?" po typie można przypisać null
            
            bool tmp4 = true;

            //nie trzeba podawać typu zmiennej, dopasowuje sie sam (używamy wtedy var)
            string tmp3 = "Ala ma kota ";
            var tmp5 = "i psa."; //nie może być null
            Console.WriteLine($"{tmp3} {tmp5}"); //$ jest, żeby połączyc string z var, reszte można +
            */
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            //żeby odpalic ze swoim aramerem : tools > Nuget pachet manager > packet manager console
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);//działa asynchronicznie - jest tworzony nowy watek, głowny watek czeka az ten poboczny zwroci wynik
            //2xx porzadane komunikaty po IsSuccessStatusCode
            //4xx to srednio
            //5xx tragedia, to koniec
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);//ctrl + spacja to podpowiedzi

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
//Metody lub pola klasowe z dużej litery. Np. AddPerson();
//żeby wybrać podświetlona podpowiedz 2x TAB
