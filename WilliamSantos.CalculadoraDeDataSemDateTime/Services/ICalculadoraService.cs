using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamSantos.CalculadoraDeDataSemDateTime.Services
{
    public interface ICalculadoraService
    {
        public string CalcularData(string data, char operacao, long valor);
    }
}
