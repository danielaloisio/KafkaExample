using InsideTechConf.Library.KafkaLite;
using System;
using System.Threading.Tasks;

namespace KafkaExample
{
    class Program
    { 
        static void Consumer()
        {
            string topic = "insidetech-5";
            int countMessage = 0;
            var consumerSettings = new ConsumerSettings(
                "127.0.0.1:9092");

            var consumer = new Consumer(consumerSettings);

            Task.Run(() =>
            {
                consumer.Subscriber<Model.User>(topic,
                (receive) =>
                {
                    if (receive != null)
                    {
                        Console.WriteLine($"Message: {++countMessage}, Date: {receive.CreatedAt}, Email: {receive.Email}, Name: {receive.Name}, Key: {receive.Key}");
                    }

                    return true;
                },
                (error) =>
                {
                    Console.WriteLine(((Exception)error).Message);
                });
            });
        }

        static void Main(string[] args)
        {
            Consumer();
            Console.ReadKey();
        }
    }
}
