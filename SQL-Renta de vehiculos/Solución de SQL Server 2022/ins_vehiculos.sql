use renta_vehiculos
go
select * from vehiculos

insert into vehiculos (dias,tipo_vehiculo,tipo_plan,costo_dia,costo_total_dia,costo_tipo_plan,total_a_pagar,fecha)
			values(2,'testvehiculo','testplan',10,11,12,13,'2025-05-04')



			
insert into vehiculos (dias,tipo_vehiculo,tipo_plan,costo_dia,costo_total_dia,costo_tipo_plan,total_a_pagar,fecha) values(@dias,@tipo_vehiculo,@tipo_plan,@costo_dia,@costo_total_dia,@costo_tipo_plan,@total_a_pagar,@fecha)
