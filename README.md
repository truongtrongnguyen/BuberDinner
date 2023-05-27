# BuberDinner

- EF1: Setup, Login/Register, AddService
- EF2: Create Jwt
  - Create SecretKey in file csproj: dotnet user-secrets init --project ./BuberDinner.Api/
  - dotnet user-secrets set --project ./BuberDinner.Api/ "JwtSettings:Secret" "super-secret-key-from-user-secret"
  - dotnet user-secrets list --project .BuberDinner.Api/
