:: Abra o prompt de comando (cmd) e navegue até o diretório onde o arquivo start_containers.bat e o docker-compose.yml
:: ...\ManageProduct\docker-compose.yml

@echo off
:: Iniciando os contêineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...

:: Executando o comando docker-compose para iniciar os contêineres
docker-compose up -d

:: Informando que os contêineres estão iniciando
echo Containers are starting up...

:: Pausando para que a janela do prompt de comando não feche imediatamente
pause
