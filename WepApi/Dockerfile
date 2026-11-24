FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src 

COPY ["Application/Application.csproj","Application/"]
COPY ["Domain/Domain.csproj","Domain/"]
COPY ["Infrastructure/Infrastructure.csproj","Infrastructure/"]
COPY ["WepApi/WepApi.csproj","WepApi/"]

RUN dotnet restore "WepApi/WepApi.csproj"

COPY . .
WORKDIR "/src/WepApi/"
RUN dotnet publish "WepApi.csproj" -c Release -o /app/publish 


FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet","WepApi.dll" ]



