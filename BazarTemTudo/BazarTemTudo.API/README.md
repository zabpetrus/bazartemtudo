dotnet ef migrations add InitialMigration --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API

dotnet ef database update --context BazarTemTudo.InfraData.Context.PostgresContext --project BazarTemTudo.InfraData --startup-project BazarTemTudo.API