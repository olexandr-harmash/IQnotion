# IQnotion API

## Описание

IQnotion API предоставляет возможность управления заметками, включая получение информации о документах и их загрузку.

## Запуск проекта

1. **Клонируйте репозиторий**:

```bash
   git clone https://github.com/olexandr-harmash/IQnotion.git
   cd IQnotion
```
## Установите зависимости:

Убедитесь, что у вас установлен .NET SDK. Установите необходимые зависимости:

```bash
    dotnet restore
```

## Настройте базу данных:

Если вы используете PostgreSQL, убедитесь, что база данных настроена. Для этого выполните команду:

```bash
    sudo docker run --name iqnotion-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -e POSTGRES_DB=IQnotion -d -p 5432:5432 postgres
```

## Запустите миграции и сидеры:

Запустите приложение, чтобы применить миграции и заполнить базу данных начальными данными:

```bash
    dotnet run
```

## Доступ к Swagger

Swagger UI доступен по адресу который выведут логи по умолчанию это:

```bash
    http://localhost:5169/swagger
```

Здесь вы можете просмотреть все доступные API и протестировать их.

## Доступные функции

1. *Получение информации о документах*: 
    Используйте соответствующий API, чтобы получить список заметок, которые пользователь еще не просмотрел.

2. *Загрузка документов*: 
    Вы можете запрашивать загрузку документов, передавая язык и путь к файлу.

## Примечания

1. *Убедитесь, что ваш PostgreSQL контейнер работает перед запуском приложения.*
2. *Все ошибки и предупреждения будут записываться в лог, так что вы сможете отследить возможные проблемы.*