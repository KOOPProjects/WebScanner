
![logo](https://i.imgur.com/2nu3hX1.png)

WebScanner project - tool for monitoring servers, websites and services.

#  Version

v0.1.0

#  Goal

Main goal is to provide server utility which can send requests in order specified by implemented Scheduler. Specific responses will be saved in database operated by WebScanner. 

#  Language

C# 7.0

#  Platform

.NET Core 2.1

#  Scope(still open)

* Repository structure in a manner of S. Allen's approach
* C# naming conventions
* Using c# design patterns
* Usage of FluentAssertions
* DDD
* Reference materials (e.g. books, articles, lectures)
* Readme-driven development

#  Reason for creating the application

Application is aimed at people who want to manage their network resources by sending specific requeststo endpoints. Application is also can be used by developers, we try to build app in DDD aproach, so it will be easy to maintain and expand. All people who want to work with us or personalize WebScanner are welcome to do so! Feel free to contact us!

#  Technologies

* Quartz.NET for scheduling tasks
* PostgreSQL for saving configuration and responses
* RESTful api for serving endpoints for configuring application

#  Application interface

* Adding order: `POST [host]/order/add`
ARGUMENT: Order order ( MUST ADD A MODEL STRUCTURE )
* Deleting order: `POST [host]/order/delete`
ARGUMENT: int orderId

 #  Solution Structure

 #  Project schedule
