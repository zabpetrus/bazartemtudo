dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.SQLiteContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.SQLiteContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API


dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialCreate --project BazarTemTudo.InfraData

dotnet ef database update  --project BazarTemTudo.InfraData


dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.ApplicationDBContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.ApplicationDBContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API


dotnet ef database drop --context BazarTemTudo.InfraData.Context.ApplicationDBContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API --force





dotnet ef migrations add InitialMigration --context BazarTemTudo.TesteConsole.Context.TestContext --project BazarTemTudo.TesteConsole --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.TesteConsole.Context.TestContext --project BazarTemTudo.TesteConsole --startup-project BazarTemTudo.API


```csharp
    //Isolando o c�digo

    #if TESTING
        public ClienteService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
    #endif
```
