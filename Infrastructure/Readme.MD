### Dotnet Migration Script Generation and Applying

- Navigate to the Infrastructure project via terminal
- dotnet ef migrations add InitialMigration --startup-project ../API
- dotnet ef database update --startup-project ../API
