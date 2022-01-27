using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using restservice;

namespace TesteUnitario
{
    [TestClass]
    public class TesteUnitario
    {
        [TestMethod]
        public void TesteInteiro()
        {
            string Entrada = "100";
            string Esperado = "Número de entrada: 100\r\nNúmeros divisores: 1 2 4 5 10 20 25 50 100\r\nDivisores primos: 2 5\r\n";
            Service servico = new Service();
            string Resultado = servico.PrintResultado(Entrada);

            Assert.AreEqual(Esperado, Resultado);
        }

        [TestMethod]
        public void TesteNegativo()
        {
            string Entrada = "-100";
            string Esperado = "Número de entrada: -100\r\nNúmeros divisores: -100 -50 -25 -20 -10 -5 -4 -2 -1 1 2 4 5 10 20 25 50 100\r\nDivisores primos: 2 5\r\n";
            Service servico = new Service();
            string Resultado = servico.PrintResultado(Entrada);

            Assert.AreEqual(Esperado, Resultado);
        }

        [TestMethod]
        public void TesteZero()
        {
            string Entrada = "0";
            string Esperado = "0 não possui fatores";
            Service servico = new Service();
            string Resultado = servico.PrintResultado(Entrada);

            Assert.AreEqual(Esperado, Resultado);
        }

        [TestMethod]
        public void TesteNaoNumerico()
        {
            string Entrada = "teste";
            string Esperado = "Verifique o formato de entrada dos dados";
            Service servico = new Service();
            string Resultado = servico.PrintResultado(Entrada);

            Assert.AreEqual(Esperado, Resultado);
        }
    }
}
