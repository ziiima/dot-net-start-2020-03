FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

RUN apt-get update && apt-get install -y make
