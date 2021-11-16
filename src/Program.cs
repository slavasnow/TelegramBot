using System;
using System.Collections.Generic;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        private static string tocken { get; set; } = "";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("==========>> Ожидание сообщений <<===========");
            client = new TelegramBotClient(tocken);
            client.StartReceiving();
            
            client.OnMessage += OnMassageHandler;
            
            
            Console.ReadLine();
            client.StopReceiving();
            //Console.WriteLine("Hello World!");
        }

        private static async void OnMassageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                switch (msg.Text)
                {
                    case "/start":
                        Console.WriteLine("Начало работы");
                        await client.SendTextMessageAsync(msg.Chat.Id, $"Что тебе нужно?", replyMarkup: GetButtons()); //ответ на сообщение например
                        return;
                    
                    case "Мой IP": // определения моего ip
                        Console.WriteLine($"Пришло сообщение: {msg.Text}"); //отображение сообщения в консоли
                        string myip = new WebClient().DownloadString("http://icanhazip.com/");
                        Console.WriteLine(myip);
                        await client.SendTextMessageAsync(msg.Chat.Id, $"{myip}"); //ответ на сообщение например
                        return;
                    
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, msg.Date.ToString()); //ответ на сообщение например
                        Console.WriteLine($"Пришло сообщение: {msg.Text}"); //отображение сообщения в консоли
                        return;
                }
            }
        }
        private static  IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton {Text = "Мой IP"}}
                }
            };
        }
    }
}
