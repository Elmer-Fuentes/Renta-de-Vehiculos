select * from vehiculos

UPDATE vehiculos 
SET dias = 2,
    tipo_vehiculo = 'testvehiculo',
    tipo_plan = 'testplan',
    costo_dia = 10,
    costo_total_dia = 11,
    costo_tipo_plan = 12,
    total_a_pagar = 13,
    fecha = '2025-05-04'
     where codigo = 1




	 
UPDATE vehiculos SET dias = @dias,tipo_vehiculo = @tipo_vehiculo ,tipo_plan = @tipo_plan,costo_dia = @costo_dia,costo_total_dia = @costo_total_dia,costo_tipo_plan = @costo_tipo_plan,total_a_pagar = @total_a_pagar,fecha = @fecha where codigo = @codigo 
