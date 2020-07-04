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

## Description

On the main window, the user can select the section of the site he needs: show all countries, find a country by name, add a new country and of course go to the main page. Thus, the main window on the desktop computer looks like this:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/MainPage.PNG">
</p>

This image shows what the list of all countries looks like:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/CountryList.PNG">
</p>

This image shows how the country search bar by name looks:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/SearchPanel.PNG">
</p>

In the case when this country is not in the list, the user can see the corresponding message:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/NotFound.PNG">
</p>

The page for adding a country is as follows:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/AddCountry.PNG">
</p>

Also, this application is fully adapted for all modern smartphones. The same page, but already on the screen of the Pixel 2 phone:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/AddCountryMobile.PNG">
</p>

Application validates input:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/ValidationMsg.PNG">
</p>

Country Add Success Message:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/SuccessAddMsg.PNG">
</p>

Search for a newly added country:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/SearchNewCountry.PNG">
</p>

Now update the information about the country, change the name of the capital and population:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/UpdateCountry.PNG">
</p>

Now the new list of all countries is as follows:

<p align="center">
<img src="https://github.com/hokage-mlg/CRMGURU-TestTask/blob/master/Screenshots/NewCountryList.PNG">
</p>

## Instructions

You need to change the connection string in the **appsettings.json** (*located at **TestTask.WebUI***) file to your own:

```json
 "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=testTaskDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```
And of course, don't forget to install the necessary packages using the NuGet package manager, they are indicated in the technology section.

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

## Technology

- bootstrap
- FontAwesome
- Dapper
- jQuery
- Microsoft.AspNetCore.Mvc
- Microsoft.EntityFrameworkCore
- System.Data.SqlClient
- Microsoft.VisualStudio.Web.CodeGeneration.Design

## Architecture

- DAL (Data Access Layer) via MS SQL and ORM Dapper
- BLL (Business Logic Layer)
- PL (Presentation Layer)

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

[MIT](https://choosealicense.com/licenses/mit/)
