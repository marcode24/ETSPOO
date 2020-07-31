create database miTienda
go 
use miTienda
go

create table Productos(

	id_Producto int not null,
	nombre varchar(max) not null,
	precio money not null,
	descripcion varchar(max)

)
