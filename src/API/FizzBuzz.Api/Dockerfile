#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/API/FizzBuzz.Api/FizzBuzz.Api.csproj", "src/API/FizzBuzz.Api/"]
COPY ["src/API/FizzBuzz.Application/FizzBuzz.Application.csproj", "src/API/FizzBuzz.Application/"]
COPY ["src/API/FizzBuzz.Core/FizzBuzz.Core.csproj", "src/API/FizzBuzz.Core/"]
RUN dotnet restore "src/API/FizzBuzz.Api/FizzBuzz.Api.csproj"
COPY . .
WORKDIR "/src/src/API/FizzBuzz.Api"
RUN dotnet build "FizzBuzz.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FizzBuzz.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FizzBuzz.Api.dll"]