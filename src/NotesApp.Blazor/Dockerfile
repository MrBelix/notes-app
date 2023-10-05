# Use the ASP.NET Core SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/NotesApp.Blazor/NotesApp.Blazor.csproj", "src/NotesApp.Blazor/"]
COPY ["src/NotesApp.Application/NotesApp.Application.csproj", "src/NotesApp.Application/"]
COPY ["src/NotesApp.Persistence/NotesApp.Persistence.csproj", "src/NotesApp.Persistence/"]
RUN dotnet restore "src/NotesApp.Blazor/NotesApp.Blazor.csproj"
COPY . .
WORKDIR "/src/src/NotesApp.Blazor"
RUN dotnet build "NotesApp.Blazor.csproj" -c Release -o /app/build


# Continue with the rest of the Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM build AS publish
RUN dotnet publish "NotesApp.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApp.Blazor.dll"]