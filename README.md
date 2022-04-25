# CurrencyConverter
API to convert a value from one currency to another.

Como utilizar:

1. Criar uma base local chamada "CurrencyConverterDB", utilizando SQL Server.
2. Rodar script, que está no repositório, para criar as tabelas.
3. Criar um usuário com a senha encriptada em SHA256.

Exemplo:
user = rafael
password = 03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4

Desta forma, a senha descriptografada para autenticação fica definida como "1234".

4. Autenticar o usuário através do endpoint https://localhost:44322/v1/account/login
e um token será gerado referente ao usuário logado.

5. Utilizar o token para acessar os outros endpoints, que são:
   1. https://localhost:44322/v1/ExchangeRates/convert
   2. https://localhost:44322/v1/ExchangeRates/GetAllTransactions

O primeiro endpoint retorna os valores da conversão e salva a transação no banco de dados.
O segundo endpoint retorna todos as transações feitas pelo usuário.

Para este projeto, foi usada uma API em ASP.NET Core 3.1, divididas em Models, Controllers, Services, Repositories e DTOs.
O banco de dados foi o SQL Server, e o micro ORM usado, foi o Dapper, por ser haverem apenas consultas mais simples.
Também foi usado Middleware para tratamento de exceções.

Os endpoint, como citados anteriormente, são 3:

1. https://localhost:44322/v1/account/login (post) Para autenticar um usuário.

2. https://localhost:44322/v1/ExchangeRates/convert (post) Para fazer uma conversão de uma moeda para outra, e salvar esta transação no banco de dados.

3. https://localhost:44322/v1/ExchangeRates/GetAllTransactions (get) Para buscar todas as trasações feitas pelo usuário autenticado.
