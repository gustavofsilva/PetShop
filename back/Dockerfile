FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
LABEL version="1.0.1" description="PetShop API"
COPY dist /app
WORKDIR /app
ENTRYPOINT ["dotnet", "back.dll"]