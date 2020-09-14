# API para cadastrar pessoas

> O projeto foi desenvolvido com .Net Core, Entity Framework e Banco de dados MySQL.

## Executar o projeto

### Download

git clone https://github.com/mateusvilione/PersonWebAPI.git

> cd ../PersonWebAPI/PersonWebAPI
 
ou 

Download do projeto em .zip
> Descompactar o projeto
  
> cd ../PersonWebAPI-master/PersonWebAPI

### String Connection

Trocar na `ConnectionStrings` o **usuario** e **senha** no arquivo appsettings.json

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=people;Uid=<USUARIO>;PWD=<SENHA>;"
  }
```

### Verifica se há o Entity Framework (3.1.8)

> dotnet ef --version

Se não estiver instalado executar o comando no cmd

> dotnet tool install --global dotnet-ef

### Criar as tabelas no banco

> dotnet ef database update

### Executar Servidor

> dotnet run

Host: http://localhost:5000/

Swagger: http://localhost:5000/swagger

API: http://localhost:5000/v1/person

## Rotas

API                    | Descrição
-----------------------|--------------
GET /v1/person         | Obter todas as pessoas cadastradas por filtro de resultados.
POST /v1/person        | Obter uma pessoa por Id.
GET /v1/person{id}     | Adicionar uma pessoa.
PUT /v1/person{id}     | Atualizar uma pessoa específica.
DELETE  /v1/person{id} | Excluir uma pessoa.


