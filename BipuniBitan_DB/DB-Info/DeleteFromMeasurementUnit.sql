
create procedure [dbo].[DeleteFromMeasurementUnit]
@Mess_id int
as
if exists(select * from MeasurementUnit where id =@Mess_id)
begin
	begin try
	delete from MeasurementUnit where id =@Mess_id
	end try
	begin catch
	print 'error DeleteFromMeasurment sp '
	end catch
end