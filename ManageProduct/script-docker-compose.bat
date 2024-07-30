@echo off
:: Iniciando os cont�ineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...

:: Executando o comando docker-compose para iniciar os cont�ineres
docker-compose up -d

:: Informando que os cont�ineres est�o iniciando
echo Containers are starting up...

:: Pausando para que a janela do prompt de comando n�o feche imediatamente
pause