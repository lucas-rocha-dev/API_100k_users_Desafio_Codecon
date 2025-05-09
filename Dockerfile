# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia o conteúdo da pasta src/Codecon_API_100k_users para dentro do container
COPY src/Codecon_API_100k_users ./Codecon_API_100k_users

# Entra no diretório do projeto
WORKDIR /app/Codecon_API_100k_users

# Restaura as dependências e publica a aplicação
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build-env /app/out .

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "Codecon_API_100k_users.dll"]
