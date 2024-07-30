@echo off
:: Iniciando os contêineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...
docker-compose up -d

:: Informando que os contêineres estão iniciando
echo Containers are starting up...

:: Verificando o estado dos contêineres
docker ps

:: Informando que a configuração está completa
echo Containers have been started and are running.

:: Pausando para que a janela do prompt de comando não feche imediatamente
pause
