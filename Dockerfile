FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["SSPTraining.sln", "SSPTraining.sln"]
COPY ["SSPTraining.Web/", "SSPTraining.Web/"]
COPY ["SSPTraining.Api/", "SSPTraining.Api/"]
COPY ["SSPTraining.Model/", "SSPTraining.Model/"]
COPY ["SSPTraining.Common/", "SSPTraining.Common/"]
COPY ["SSPTraining.Business/", "SSPTraining.Business/"]
COPY ["SSPTraining.DataAccess/", "SSPTraining.DataAccess/"]

# Test Projects
COPY ["SSPTraining.Test.Unit/", "SSPTraining.Test.Unit/"]
COPY ["SSPTraining.Test.Integration/", "SSPTraining.Test.Integration/"]

RUN dotnet restore --disable-parallel --packages packages --ignore-failed-sources "SSPTraining.sln"

RUN dotnet test "SSPTraining.Test.Unit" -c Release --no-restore
RUN dotnet test "SSPTraining.Test.Integration" -c Release --no-restore

COPY . .

WORKDIR "/src/SSPTraining.Web"

RUN dotnet build "SSPTraining.Web.csproj" -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish "SSPTraining.Web.csproj" -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSPTraining.Web.dll"]