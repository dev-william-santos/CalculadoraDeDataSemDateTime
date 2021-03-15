using System;
using WilliamSantos.CalculadoraDeDataSemDateTime.Services;

namespace WilliamSantos.CalculadoraDeDataSemDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculadoraService date = new CalculadoraService();

            Console.WriteLine("09/07/1991 00:00 + 1 " + date.CalcularData("09/07/1991 00:00", '+', 1));
            Console.WriteLine("01/01/2021 23:59 + 1 " + date.CalcularData("01/01/2021 23:59", '+', 1));
            Console.WriteLine("01/01/2021 00:00 - 1 " + date.CalcularData("01/01/2021 00:00", '-', 1));
            Console.WriteLine("28/02/2021 23:59 + 1 " + date.CalcularData("28/02/2021 23:59", '+', 1));
            Console.WriteLine("01/03/2021 00:00 - 1 " + date.CalcularData("01/03/2021 00:00", '-', 1));
            Console.WriteLine("28/02/2021 23:59 + 525600 " + date.CalcularData("28/02/2021 23:59", '+', 525600));
            Console.WriteLine("28/02/2021 23:59 - 525600 " + date.CalcularData("28/02/2021 23:59", '-', 525600));
            Console.WriteLine("09/07/1991 12:00 + 60 " + date.CalcularData("09/07/1991 12:00", '+', 60));
            Console.WriteLine("28/02/2021 23:59 + 1 " + date.CalcularData("28/02/2021 23:59", '+', 1));
        }
    }
}
