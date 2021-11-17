#!/bin/bash

wget https://github.com/slavasnow/TelegramBot/releases/latest/download/TelegramBot

echo "=============="
echo "скачивание завершено"
echo "=============="

mkdir TGBOT
mv TelegramBot TGBOT

echo "=============="
echo "перемещенение завершено"
echo "=============="

podman build -t bot-image .

echo "=============="
echo "сборка образа заврешена"
echo "=============="

podman run -t -d --rm --name bot localhost/bot-image:latest

echo "=============="
echo "запуск завершен заврешена"
echo "=============="

rm -R TGBOT

echo "=============="
echo "работа окончена"
echo "=============="

podman ps -a
