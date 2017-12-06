using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using С2ls2.Workers;

namespace С2ls2
{
    class Programm

    {   /// <summary>
    ///  В обще программа делает 18 воркеров и всех почему-то приписывает Based on time типу.  Не исключено, что я что-то упустила в FixedWrokers
    /// </summary>
    /// <param name="args"></param>
    
        static void Main(string[] args)
        {
            var workers = PopulateWorkers(18);
            foreach (var worker in workers)
            {
                Console.WriteLine("Worker Id: {0}, Name: {1}, Salary {2}, Type: {3}", worker.Id, worker.Name, worker.Salary, worker.GetType());
            }

            SerializeData("workers.xml", workers);

            Console.ReadLine();
        }
            /// <summary>
            ///  должно создавать woerkrs.xml файл с работниками, ну и закрывать по завершению. но запись он у меня не делает, либо я потеряла как это делается.
            /// </summary>
            /// <param name="filename"></param>
            /// <param name="workers"></param>
        private static void SerializeData(string filename, IEnumerable<SimpletWorker> workers)
        {
            var ser = new XmlSerializer(typeof(SimpletWorker));
            var writer = new StreamWriter(filename);
            foreach (var worker in workers)
            {
                Serializable.Write(writer, worker); // вот здесь косяк.
            }

            writer.Close();
        }

        private static IEnumerable<SimpletWorker> PopulateWorkers(int count)
        {
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                var type = rand.Next(0, 1);
                double rate;

                SimpletWorker worker;
                switch (type)
                {
                    case 0:
                        rate = (double)rand.Next(10, 100) / 10;
                        worker = new BasedOnTimeWorker(i, String.Format("{0}Worker", i), rate);
                        break;
                    case 1:
                        rate = rand.Next(100, 1000);
                        worker = new FixedWorker(i, String.Format("{0}Worker", i), rate);
                        break;
                    default:
                        throw new NotImplementedException("Not sure it's working right! Check this out!");
                        break;
                }
                yield return worker;
            }

        }
    }
}
