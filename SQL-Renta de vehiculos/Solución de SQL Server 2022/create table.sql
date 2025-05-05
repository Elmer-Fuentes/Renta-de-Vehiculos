use renta_vehiculos
go
create table vehiculos (
codigo int identity (1,1) primary key
,dias int
,tipo_vehiculo varchar (20),
tipo_plan varchar(20)
,costo_dia decimal (10,2),
costo_total_dia decimal (10,2)
,costo_tipo_plan decimal(10,2)
,total_a_pagar decimal (10,2),
fecha datetime
						)
