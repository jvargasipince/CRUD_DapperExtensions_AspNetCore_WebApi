# CRUD_DapperExtensions_AspNetCore_WebApi
Demo de como hacer un CRUD usando la libreria Dapper &amp;Dapper Extensions, siendo expuestas a través de un Web Api en AspNetCore 2.0

ScriptDB

create database DemoDapper
go

use DemoDapper
go

create table dbo.Usuario(
Id int primary key identity(1,1),
Nombre nvarchar(100) not null,
ApellidoPaterno nvarchar(100) not null,
ApellidoMaterno nvarchar(100) not null,
Email nvarchar(100) not null,
Status bit not null
)
go

select * from Usuario
go
