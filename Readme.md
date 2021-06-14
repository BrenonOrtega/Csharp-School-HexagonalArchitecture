# Project - Console Application -  .NET DI/PgSql/Dapper

<div>
    <img alt="C# logo" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSaA2RTJJGS7KHl7Lv1HpneTHBKM_yRUp8Q95q5bIGxUOR0axXXidgKzB48bhfhPhPEJVo&usqp=CAU" width="200" height="200">
    <img alt="Dapper NuGet logo" src="https://api.nuget.org/v3-flatcontainer/dapper/2.0.90/icon" width="200" height="200">
    <img alt="Serilog logo"src="https://camo.githubusercontent.com/61dbe65ee3b517d195b5791122ecaf42ba76be78eba921acaf112f096dc57d84/68747470733a2f2f736572696c6f672e6e65742f696d616765732f736572696c6f672d31383070782e706e67" width="200" height="200">
    <img alt="PostgreSQL logo"src="https://api.nuget.org/v3-flatcontainer/npgsql/5.0.5/icon" width="200" height="200">
</div>

## Objective

Development of a study application project that implements C# concepts like:
 - Configuration files.
 - Dependency Injection containers.
 - Logging.
 - Extension Methods.
 - Repository Pattern.
 - ORM Utilization.
 - Data Relationships.

## Technologies

 - [Dapper](https://dapperlib.github.io/Dapper/)
 - [Serilog](https://serilog.net/)
 - [Npgsql](https://www.npgsql.org/)
 - [PostgreSQL](https://www.postgresql.org/)

## Study Material

[Andre Secco - Construindo uma Web Api com ASP.NET Core](https://www.youtube.com/watch?v=J5Ek3vENG-Y)

[IAmTimCorey - .NET Core Console App with Dependency Injection, Logging, and Settings](https://www.youtube.com/watch?v=GAOCe-2nXqc)

[IAmTimCorey - How to connect C# to SQL (the easy way)](https://www.youtube.com/watch?v=Et2khGnrIqc&t=2327s)

### Configuration Files

The concept of configuration files evolved in .NET 5/Core, there is five standard ways to config an application. The most common is the way we commonly see in ASP.NET Apps and it is using "appsettings.json".

For this to work out we need to use the NuGet Package Microsoft.Extensions.Configuration, as we can see this in Program.cs and in Extensions/ConfigurationBuilderSetup.cs(we'll talk about this in the extension methods part) where we config the application to use json files for configuration and environment variables for the kind of environment we're running our app.

With this we're able to use the appsettings.json file to passa parameters to our application by default and even create appsettings.development.json/appsettings.production.json to run distinct configurations for our app.

### Dependency Injection Container

(To be written)

### Logging

(To be written)

### Extension Methods

The Creation of C# Extension Methods enables us to create new behaviors for a type of object that we're using, it's a thing pretty common in .NET applications since System.Linq is a must when working with databases or collections and it is an extension methods for interfaces that implement IEnumerable, ICollection, IQueryable and so forth.

To create an extension methods we need to follow some rules like:
 - The class that have the extension method must be a static class.
 - The method should know the type of object that it is extending.
 - In case of objects that implement builder patterns or fluentAPI the methoud should return the object itself.
 - the use of "this" alongside the method argument.

 ```CSharp  
    public static class ConfigurationBuilderSetup
    {
        public static IConfigurationBuilder SetupConfig(this IConfigurationBuilder builder)
        {
            //Implementation of the method here.
            return builder;
        }
    }
 ```


 ### Repository Pattern

(To be written)

 ### ORM Utilization

(To be written)

 ### Data Relationships

(To be written)

## Issues during development
### PostgreSQL

 - System.Data.DateTime converts directly to postgresql "timestamp without timezone" data type so a function with input "date" data type cannot insert it in a direct conversion, so turning the input data type to "timestamp" enabled to pass directly System.Data.DateTime to the postgre function and it would insert correctly, and stills return a table with "date" fields to dapper mapping function withou any more problems.

 - When using functions in postgre (or stored procedures in other db's) you should be aware of the kind of data that will be returned from each call. Dapper was not properly mapping Repository.GetAll method data return because in my db function call i did not asked for all fields that my function returns
 ```sql
 -- RETURNS THE FUNCTION CALL OR "A RECORD"
SELECT public.getallstudents(paging_page:=page, paging_size:=size);
 ```
 this did return me a "record", but was not returning the table with the fields, since the script was created to return a table with fields matching my model properties the correct function call is as follow:

 ```SQL
 -- RETURNS A TABLE CONTAINING "Id, FirstName, LastName, BirthDate" so dapper can do the entity mapping on it.
 SELECT * FROM public.getallstudents(paging_page:=page, paging_size:=size);
 ```
 ### A Huge thanks to [Tim Corey](https://github.com/TimCorey) and to [Andre Secco](https://github.com/andreluizsecco) for their teachings and for the content that they produce. <br/> Follow their channels for high quality .NET and general development content.
