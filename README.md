<h1 align="center">Parking management system<h1>
<h4 align="center">Made in .Net Core V3.1</h4>


### Technologies
- [.Net Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.1)
- [Swagger](https://swagger.io/) 


### Estabelecimento:
- List establishments: `http://localhost:44354/estabelecimento`
- Create establishments: `http://localhost:44354/estacionamento`
- _Header: Contet-Type application/json_
- Update establishments: `http://localhost:44354/estabelecimento/{id}`
- _Header: Contet-Type application/json_
- Delete establishments: `http://localhost:44354/estabelecimento/{id}`
- ById establishments: `http://localhost:44354/estabelecimento/{id}`

### Veiculo:
- List vehicles: `http://localhost:44354/veiculo`
- Create vehicles: `http://localhost:44354/veiculo}`
- _Header: Contet-Type application/json_
- Update vehicles: `http://localhost:44354/veiuculo/{id}`
- _Header: Contet-Type application/json_
- Delete vehicles: `http://localhost:44354/veiculo/{id}`
- ById vehicles: `http://localhost:44354/veiculo/{id}}`


### Relatorio:
- Summary: `http://localhost:44354/relatorio`
- Summary entrance and exit: `http://localhost:44354/relatorio/entradaSaida`
- Summary entrance and exit per hour: `http://localhost:44354/relatorio/entradaSaidaHora`
