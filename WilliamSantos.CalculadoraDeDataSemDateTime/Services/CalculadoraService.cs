using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamSantos.CalculadoraDeDataSemDateTime.Models;

namespace WilliamSantos.CalculadoraDeDataSemDateTime.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        private readonly DataHora _dateTimeDesafio;
        /// <summary>
        /// Array contendo os dias máximos de cada mês do ano + dia zero
        /// </summary>
        private readonly int[] _totalDiasCadaMes = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        public CalculadoraService()
        {
            _dateTimeDesafio = new DataHora();
        }

        /// <summary>
        /// Constroi uma instância de um objeto DataHora a partir de uma string formatada.
        /// </summary>
        /// <param name="data">String contendo uma data no formato dd/MM/yyyy HH:mm</param>
        /// <param name="operacao">Char contendo o valor '+' ou '-'.</param>
        /// <param name="valor">Quantidade de minutos para ser adicionado.</param>
        public string CalcularData(string data, char operacao, long valor)
        {
            string[] dataSplit = data.Split(new char[] { '/', ' ', ':' });

            _dateTimeDesafio.Dia = int.Parse(dataSplit[0]);
            _dateTimeDesafio.Mes = int.Parse(dataSplit[1]);
            _dateTimeDesafio.Ano = int.Parse(dataSplit[2]);
            _dateTimeDesafio.Hora = int.Parse(dataSplit[3]);

            _dateTimeDesafio.Minuto = int.Parse(dataSplit[4]);

            CalcularMinutosTotais();

            if (valor < 0)
                valor = valor * -1;

            if (operacao == '-')
                valor = -valor;

            AddMinutos(valor);

            return FormatString();
        }

        /// <summary>
        /// Converte uma instância de DataHora em string.
        /// </summary>
        /// <returns>String fromatada "dd/MM/yyyy HH:mm"</returns>
        private string FormatString()
        {
            return $"{_dateTimeDesafio.Dia:00}/{_dateTimeDesafio.Mes:00}/{_dateTimeDesafio.Ano:0000} {_dateTimeDesafio.Hora:00}:{_dateTimeDesafio.Minuto:00}";
        }

        /// <summary>
        /// Adiciona minutos a data informada.
        /// </summary>
        /// <param name="minutos">Valor positivo ou negativo</param>
        private void AddMinutos(long minutos)
        {
            _dateTimeDesafio.MinutosTotais += minutos;

            ConverterMinutosTotaisEmDataHoraDesafio();
        }

        /// <summary>
        /// Converte os minutos totais em DataHora novamente.
        /// </summary>
        private void ConverterMinutosTotaisEmDataHoraDesafio()
        {
            //converte minutos em anos
            _dateTimeDesafio.Ano = GetTotalDias() / 365;

            //converte o resto dos dias do ano em minutos
            _dateTimeDesafio.Mes = Array.FindIndex(_totalDiasCadaMes, e => e == _totalDiasCadaMes.Last(el => el <= GetTotalDias() % 365));

            //calcula a diferença do total de dias no mês com o resto dos dias do ano para obter os dias corridos do mês
            _dateTimeDesafio.Dia = GetTotalDias() % 365 - _totalDiasCadaMes[_dateTimeDesafio.Mes];

            //converte o resto dos minutos dos dias do ano em horas
            _dateTimeDesafio.Hora = (int)((_dateTimeDesafio.MinutosTotais - GetTotalMinutosAno() - (_totalDiasCadaMes[_dateTimeDesafio.Mes] * 24 * 60) - (_dateTimeDesafio.Dia * 24 * 60)) / 60);

            //converte o resto das horas em segundos
            _dateTimeDesafio.Minuto = (int)(_dateTimeDesafio.MinutosTotais - GetTotalMinutosAno() - (_totalDiasCadaMes[_dateTimeDesafio.Mes] * 24 * 60) - (_dateTimeDesafio.Dia * 24 * 60) - _dateTimeDesafio.Hora * 3600 / 60);

            //acerto de dia, ano e mês que foram decrementados na conversão em minutos
            _dateTimeDesafio.Ano++;
            _dateTimeDesafio.Mes++;
            _dateTimeDesafio.Dia++;
        }

        private int GetTotalMinutosAno()
        {
            return (_dateTimeDesafio.Ano * 365 * 24 * 60);
        }

        /// <summary>
        /// Converte minutos em dias
        /// </summary>
        /// <returns></returns>
        private int GetTotalDias()
        {
            return (int)_dateTimeDesafio.MinutosTotais / 24 / 60;
        }

        /// <summary>
        /// Converte a instância atual em minutos totais
        /// </summary>
        private void CalcularMinutosTotais()
        {
            _dateTimeDesafio.MinutosTotais = 0;
            //converte hora em minutos
            _dateTimeDesafio.MinutosTotais += _dateTimeDesafio.Hora * 60;
            //converte dia em minutos
            _dateTimeDesafio.MinutosTotais += (_dateTimeDesafio.Dia - 1) * 24 * 60;
            //Converte mês em minutos
            _dateTimeDesafio.MinutosTotais += _totalDiasCadaMes[_dateTimeDesafio.Mes - 1] * 24 * 60;
            //converte anos em minutos
            _dateTimeDesafio.MinutosTotais += (_dateTimeDesafio.Ano - 1) * 365 * 24 * 60;
            //soma os minutos no total
            _dateTimeDesafio.MinutosTotais += _dateTimeDesafio.Minuto;
        }

    }
}
