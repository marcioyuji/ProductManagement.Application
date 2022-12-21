# ProductManagement.Application
Documentação API ProductManagment
API foi desenvolvida em .NET 6 utilizando o modelo DDD (Domain-Driven-Design)
separada em quatro camadas API, Application, Core e Infrastructure:
               
Configurando banco de dados
1- Abrir Console do Gerenciador de Pacotes 
2- Selecionar projeto ProductManagement.WebAPI
3- Executar migration com o comando: Add-Migration InitialCreate
4- Executar comando para atualizar a base: Update-Database (Base ProductManagement e tabelas: TB_PRODUCT, TB_CATEGORY vão ser criadas)

                         
Executando Projeto ProductManagement.WebAPI
1- Selecione ProductManagement.WebAPI como projeto de inicialização, após a execução swagger irá abrir na porta https://localhost:7022/swagger/index.html
