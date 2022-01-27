using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using restservice;

namespace DesafioFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost hostWeb = new WebServiceHost(typeof(Service));
            ServiceEndpoint ep = hostWeb.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = hostWeb.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            hostWeb.Open();

            while (true)
            {
                Console.WriteLine("Digite um numero:");

                string numero = Console.ReadLine();

                Service servico = new Service();

                Console.WriteLine(servico.PrintResultado(numero));

            }

        }
    }
}
