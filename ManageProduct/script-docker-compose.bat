@echo off
:: Iniciando os cont�ineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...
docker-compose up -d

:: Informando que os cont�ineres est�o iniciando
echo Containers are starting up...

:: Verificando o estado dos cont�ineres
docker ps

:: Informando que a configura��o est� completa
echo Containers have been started and are running.

:: Pausando para que a janela do prompt de comando n�o feche imediatamente
pause
