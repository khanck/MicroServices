# MicroServices (.Net Core Micro Services)
.Net Core Micro Services  
Basic structure of microservices developed using .Net core C#, entity framework and Microsoft SQL server, including code first migration.
this application will run in docker containers 

Steps for creating new object and database table corresponding to the object 
1)	Add new objects in model project 
2)	Add the reference of the new objects in CoreDbContext in DAL project 
3)	implement corresponding repository in DAL project same as employee 
4)	create controller for new objects
5)	Create migration- for creating database scripts corresponding to new objects
      i)	Got to > Package manager console in API project 
      ii)	Run > EntityFrameworkCore\Add-Migration firstMigration
6)	Update Migration to database -for creating database tables corresponding to above migration
      i)	Got to > Package manager console in API project 
      ii)	Run > EntityFrameworkCore\Update-Database
