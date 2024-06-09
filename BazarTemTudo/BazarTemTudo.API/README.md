dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.SQLiteContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.SQLiteContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API


dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialCreate --project BazarTemTudo.InfraData

dotnet ef database update  --project BazarTemTudo.InfraData


```csharp
    //Isolando o código

    #if TESTING
        public ClienteService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
    #endif
```
