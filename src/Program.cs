// See https://aka.ms/new-console-template for more information
using System.Net;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;



var client = new TelegramBotClient("1922620877:AAHd6M7t1DAAhnG6XhwymQmdYgjJmUZv0wc"); //токен для подключения 
using var cts = new CancellationTokenSource();

var receiverOption = new ReceiverOptions
{
    AllowedUpdates = { }
};

client.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOption, cancellationToken: cts.Token);

var me = await client.GetMeAsync();

Console.WriteLine("==========>> Ожидание сообщений <<===========");
Console.ReadLine();

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
{
    if (update.Message!.Type != MessageType.Text)
    {
        return;
    }

    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;
    string ip = "";


    ReplyKeyboardMarkup getButton = new(new []
    {
        new KeyboardButton[] { "Мой IP", "Jenkins" },
    })
    {
        ResizeKeyboard = true
    };


    switch (messageText)
                {
                    case "/start":
                        Console.WriteLine("Начало работы");
                        await client.SendTextMessageAsync(chatId, $"Что тебе нужно?",replyMarkup: getButton ,cancellationToken: cancellationToken); //ответ на сообщение например
                        return;
                    
                    case "Мой IP": // определения моего ip
                        Console.WriteLine($"Пришло сообщение: {messageText}"); //отображение сообщения в консоли
                        ip = new WebClient().DownloadString("http://icanhazip.com/");
                        Console.WriteLine(ip);
                        await client.SendTextMessageAsync(chatId, $"{ip}"); //ответ на сообщение например
                        return;
                    
                    case "Jenkins": // определения моего ip
                        Console.WriteLine($"Пришло сообщение: {messageText}"); //отображение сообщения в консоли
                        ip = new WebClient().DownloadString("http://icanhazip.com/");
                        string jenkinsip = String.Concat(ip, ":8880");
                        Console.WriteLine(jenkinsip);
                        await client.SendTextMessageAsync(chatId, $"{jenkinsip}"); //ответ на сообщение например
                        return;

                    default:
                        await client.SendTextMessageAsync(chatId, update.Message.Date.ToString()); //ответ на сообщение например
                        Console.WriteLine($"Пришло сообщение: {messageText}"); //отображение сообщения в консоли
                        return;
                }

}


Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}