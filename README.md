# ManageProduct - Backend

Este projeto é uma aplicação backend desenvolvida com ASP.NET Core 8.0 para gerenciar produtos e departamentos,
além de fornecer autenticação e autorização de usuários. O projeto adota uma arquitetura em camadas e segue o padrão SOLID,
além de utilizar o padrão UnitOfWork para gerenciar transações e operações de banco de dados.
Ele utiliza uma série de tecnologias e bibliotecas para garantir eficiência, segurança e escalabilidade.

## Funcionalidades

- **Gerenciamento de Produtos**: Criação, atualização, exclusão e listagem de produtos.
- **Gerenciamento de Departamentos**: Listagem de departamentos.
- **Autenticação e Autorização**: Registro, login e geração de tokens JWT para autenticação segura.

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**: Framework para construção de aplicações web robustas e escaláveis.
- **Entity Framework Core 8.0.7**: ORM para facilitar a interação com o banco de dados.
- **Dapper**: Micro ORM para consultas rápidas e eficientes ao banco de dados.
- **FluentValidation**: Biblioteca para validação de modelos.
- **AutoMapper**: Ferramenta para mapeamento de objetos.
- **JWT (JSON Web Tokens)**: Para autenticação e autorização seguras.
- **PostgreSQL**: Banco de dados relacional utilizado para armazenar as informações.

### Pacotes e Bibliotecas

- **Microsoft.AspNetCore.Authentication.JwtBearer**: Suporte para autenticação via JWT.
- **Microsoft.AspNetCore.Identity**: Sistema de identidade para gerenciar usuários, senhas e funções.
- **Swashbuckle.AspNetCore**: Integração com Swagger para geração de documentação de APIs.
- **Dapper.Contrib.Extensions.Tablename**: Extensões para Dapper que facilitam o uso de tabelas.
- **FluentValidation**: Validação de modelos.
- **AutoMapper.Extensions.Microsoft.DependencyInjection**: Integração do AutoMapper com o ASP.NET Core.
- **Npgsql.EntityFrameworkCore.PostgreSQL**: Provedor do Entity Framework Core para PostgreSQL.

### Estrutura do Projeto

- **Controllers**: Responsáveis por receber as requisições HTTP e interagir com os serviços.
  - `ProductsController`: Gerencia as operações relacionadas a produtos.
  - `DepartmentController`: Gerencia as operações relacionadas a departamentos.
  - `AuthController`: Gerencia a autenticação e autorização de usuários.
- **ViewModels**: Modelos utilizados para transferir dados entre o cliente e o servidor.
- **Services**: Contém a lógica de negócio e interage com os repositórios.
- **Repositories**: Responsáveis por interagir com o banco de dados.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/lucashfdeus/backend-manage-product.git

## Observação Importante

**⚠️ Certifique-se de executar a aplicação em modo Self-Hosting para garantir que a porta disponibilizada para o serviço esteja corretamente configurada e acessível. Isso é crucial para o funcionamento adequado da aplicação.**

2. Certifique-se de que o Docker esteja instalado na sua máquina para executar o próximo comando.
   - **Instruções**: Abra o prompt de comando (cmd) na raiz do projeto (Soluction) e navegue até o diretório onde estão localizados os arquivos `start_containers.bat` e `docker-compose.yml`.
   -  Em seguida, execute o script de inicialização dos containers Docker:
     ```bash
     start_containers.bat
     ```

3. Execute o comando para atualizar o banco de dados com as migrations geradas pelo Entity Framework Core. O comando a ser utilizado é:
   ```bash
   update-database --initial


