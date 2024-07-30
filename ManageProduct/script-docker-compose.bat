@echo off
:: Iniciando os contêineres PostgreSQL e pgAdmin
echo Starting PostgreSQL and pgAdmin containers...
docker-compose up -d

:: Informando que os contêineres estão iniciando
echo Containers are starting up...

:: Pausando para garantir que os contêineres tenham tempo para inicializar
timeout /t 30

:: Executando o script SQL para configurar o banco de dados
echo Configuring the database...

:: Substitua o <db_user>, <db_password>, <db_host>, e <db_name> pelos valores adequados
psql -U <db_user> -h <db_host> -d <db_name> -f setup.sql

:: Informando que a configuração foi concluída
echo Database configuration complete.

:: Pausando para que a janela do prompt de comando não feche imediatamente
pause
