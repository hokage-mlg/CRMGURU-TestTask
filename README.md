# CRMGURU-TestTask
The task which I have done for CRMGURU.
# Test task for CRMguru via **ASP.NET Core MVC**
> Language: English.

Hi everyone! I present to you my contest project.

**Task conditions (*on russian*):**

*Приложение по получению информации о странах. Нужно сделать приложение, в котором пользователь по введенной стране будет получать по ней информацию (Название, Код страны, Столица, Площадь, Население, Регион).*

***Требования к заданию:***

*1. При запуске приложения должно быть 2 функциональности на выбор пользователя: Ввод названия страны; вывод всех стран с БД. После ввода страны должно выдать информацию о стране (Название, Код страны, Столица, Площадь, Население, Регион) либо если страна не найдена выдать об этом сообщение.*

*2. Далее выдать предложение пользователю сохранить информацию в базу (MS SQL). Если пользователь отказывается - не сохранять.*

  - *a. В БД должно быть 3 таблицы: Регионы(Id - идентификатор, Название - строка), Города(Id - идентификатор, Название - строка), Страны – (Id - идентификатор, Название – строка, Код страны – строка, Столица – идентификатор с таблицы Города, площадь – дробное число, Население – целое число, Регион – идентификатор с таблицы Регионы)*

  - *b. Алгоритм добавления, следующий:*

    - *i. проверяем наличие Столицы в таблице Города, если найдена, то берем её идентификатор, если нет, то добавляем;*

    - *ii. проверяем наличие Региона в таблице Регионов, если найден, то берем его идентификатор, если нет, то добавляем;*

    - *iii. Проверяем наличие Страны в таблице стран по коду страны, если страна не найдена – добавляем с идентификаторами, полученными выше, если найдена обновляем значения.*

*3. При выборе вывода всех стран БД должен вывестись список всех стран в БД со следующими полями: Название, Код страны, Столица, Площадь, Население, Регион. Прошу обратить внимание, что Столицу и Регион тут нужно выводить название.*

## Folder Description

- **BackedUpDatabase** - Database backup folder
- **TestTask.Domain** - Class Library. Contains the entities and logic of the subject area; tuned for persistence through storage.Using ***ORM Dapper*** technology
- **TestTask.WebUI** - ASP.NET Core MVC Web Application. Contains controllers and views; acts as the user interface for the TestTask application
- **sqlQueries** - Contains a SQL query for creating database and tables, also seeding tables by data (~~just in case~~).

## Programming Languages

- JS
- C#
- Html and CSS
- SQL

## Architecture

- DAL (Data Access Layer) via MS SQL and ORM Dapper
- BLL (Business Logic Layer)
- PL (Presentation Layer)

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

[MIT](https://choosealicense.com/licenses/mit/)
