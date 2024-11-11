# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Устанавливаем рабочую директорию для сборки
WORKDIR /app

# Копируем все файлы проекта в контейнер
COPY . ./

RUN dotnet restore

RUN dotnet publish ./src/IQnotion.Presentation/ -c Release -o out

# Используем официальный образ .NET Runtime для продакшн окружения
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Устанавливаем рабочую директорию для сборки
WORKDIR /app

# Копируем собранное приложение из предыдущего шага
COPY --from=build-env /app/out ./

COPY --from=build-env /app/notions ./notions

# Указываем команду для старта приложения
ENTRYPOINT ["dotnet", "IQnotion.Presentation.dll"]
