FROM mcr.microsoft.com/dotnet/runtime:5.0

COPY TGBOT/ App/

WORKDIR /App

RUN chmod a+xr TelegramBot

CMD "TelegramBot"
