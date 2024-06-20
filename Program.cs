using System.Net;

using System.Text;


namespace dc
{
    class WebhookDestroyer
    {
        static void SendMs(string message, string webhook)
        {


            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string payload = "{\"content\": \"" + message + "\"}";
            client.UploadData(webhook, Encoding.UTF8.GetBytes(payload));

        }

        public static void main()
        {
            Console.Title = "Webhook Destroyer by z.lit";
            Console.WriteLine("Message: ");
            string message = Console.ReadLine();
            Console.WriteLine("Webhook: ");
            string webhook = Console.ReadLine();
            Console.WriteLine("Number to messages: ");
            string number = Console.ReadLine();

            try
            {
                int total = Convert.ToInt32(number);

                for (int i = 0; i <= total; i++)
                {
                    try
                    {
                        SendMs(message, webhook);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(String.Format("[{0}] Message Send", i));
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(String.Format("[{0}] Error to send Message", i));
                    }
                    Thread.Sleep(100);
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Number dont valid");
            }
            Console.ReadKey();
        }


    }
}

