:: Abra o prompt de comando (cmd) e navegue at� o diret�rio onde o arquivo start_containers.bat e o docker-compose.yml
:: ...\ManageProduct\docker-compose.yml

@echo off
:: Iniciando os cont�ineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...

:: Executando o comando docker-compose para iniciar os cont�ineres
docker-compose up -d

:: Informando que os cont�ineres est�o iniciando
echo Containers are starting up...

:: Pausando para que a janela do prompt de comando n�o feche imediatamente
pause
