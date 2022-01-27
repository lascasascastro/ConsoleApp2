using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restservice
{
    public class Service : IService
    {
        public List<int> GetDivisores(int n)
        {
            List<int> DivArray = new List<int>();
            for (int i = 1; i * i < n; i++)
            {
                if (n % i == 0)
                    DivArray.Add(i);
            }
            for (int i = (int)Math.Sqrt(n); i >= 1; i--)
            {
                if (n % i == 0)
                    DivArray.Add(n / i);
            }

            return DivArray;
        }

        public List<int> GetPrimos(int n)
        {
            List<int> DivArray = new List<int>();

            if (n % 2 == 0)
            {
                DivArray.Add(2);
                while (n % 2 == 0)
                {
                    n /= 2;
                }
            }

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    DivArray.Add(i);
                    n /= i;
                }
            }

            if (n > 2)
            {
                DivArray.Add(n);
            }

            DivArray = DivArray.Distinct().ToList();
            return DivArray;
        }

        public string PrintResultado(string n)
        {
            try
            {
                int Entrada = Convert.ToInt32(n);
                bool Negativo = false;
                if(Entrada < 0)
                {
                    Negativo = true;
                    Entrada *= -1;
                }
                else if(Entrada == 0)
                {
                    return "0 não possui fatores";
                }

                List<int> DivisoresList = GetDivisores(Entrada);
                List<int> PrimosList = GetPrimos(Entrada);
                List<int> DivisoresNegativosList = new List<int>();

                string Resultado = "Número de entrada: " + n.ToString() + Environment.NewLine;
                if (Negativo)
                {
                    foreach(int i in DivisoresList)
                    {
                        DivisoresNegativosList.Add(i * -1);
                    }
                    DivisoresNegativosList.Reverse();
                    Resultado = Resultado + "Números divisores: " + string.Join(" ", DivisoresNegativosList) + " " + string.Join(" ", DivisoresList) + Environment.NewLine;
                    Resultado = Resultado + "Divisores primos: " + string.Join(" ", PrimosList) + Environment.NewLine;
                }
                else
                {

                    Resultado = Resultado + "Números divisores: " + string.Join(" ", DivisoresList) + Environment.NewLine;
                    Resultado = Resultado + "Divisores primos: " + string.Join(" ", PrimosList) + Environment.NewLine;
                }


                return Resultado;
            }
            catch
            {
                return "Verifique o formato de entrada dos dados";
            }
        }
    }
}