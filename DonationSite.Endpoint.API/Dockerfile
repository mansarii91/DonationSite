#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DonationSite.Endpoint.API/DonationSite.Endpoint.API.csproj", "DonationSite.Endpoint.API/"]
COPY ["DonationSite.Core.Services/DonationSite.Core.Services.csproj", "DonationSite.Core.Services/"]
COPY ["DonationSite.Core.Contracts/DonationSite.Core.Contracts.csproj", "DonationSite.Core.Contracts/"]
COPY ["DonationSite.Core.Entities/DonationSite.Core.Entities.csproj", "DonationSite.Core.Entities/"]
COPY ["DonationSite.DataAccess.EF/DonationSite.DataAccess.EF.csproj", "DonationSite.DataAccess.EF/"]
RUN dotnet restore "DonationSite.Endpoint.API/DonationSite.Endpoint.API.csproj"
COPY . .
WORKDIR "/src/DonationSite.Endpoint.API"
RUN dotnet build "DonationSite.Endpoint.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DonationSite.Endpoint.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DonationSite.Endpoint.API.dll"]
EXPOSE 80
#EXPOSE 443