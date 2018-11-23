# webscanner changelog

## 0.4.0
- added models for managing Orders and Responses in Db, Added Trigger and JobDetail Composers in purpose of scheduling Orders
- added implementations of Job and Composers for HtmlOrders managing
- added Managers for adding and deleting orders from scheduler
- implemented database layer with usage of Repository and UnitOfWork pattern
- added example showing adding and deleting Orders from Scheduler
- added and implemented API actions
- added ServiceCollectionProvider for providing DI features
- implemented ResponseService for adding responses from Jobs to Database
- implemented StartupConfigurator 

## 0.3.1
- fix Dockerfile path

## 0.3.0
- added docker support

## 0.2.0
- added initial project structure, added git ignore

## 0.1.0
- Initial release

