using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamSantos.CalculadoraDeDataSemDateTime.Models
{
    public class DataHora
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public long MinutosTotais { get; set; }
    }
}
