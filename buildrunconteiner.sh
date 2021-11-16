#!/bin/bash

wget https://github.com/slavasnow/TelegramBot/releases/latest/download/TelegramBot

echo "скачивание завершено"

mkdir TGBOT
mv TelegramBot TGBOT

echo "перемещенение завершено"

podman build -t bot-image .

echo "сборка образа заврешена"

podman run -t -d --rm --name bot localhost/bot-image:latest

echo "запуск завершен заврешена"

rm -R TGBOT

echo "работа окончена"

