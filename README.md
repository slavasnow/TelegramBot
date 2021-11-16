# TelegramBot
Telegram Bot

# CL commad build

dotnet publish -r linux-x64 

# Dockerfile

FROM mcr.microsoft.com/dotnet/runtime:5.0 //среда выполнения

RUN chmod +x (a+rx) Файл бота //давать права на на чтение и запись

CMD "файл бота" //просто исполняемый файл

# скриптам необходимо разрешение на испорлнение

chmod +x "имя скрипта" 
