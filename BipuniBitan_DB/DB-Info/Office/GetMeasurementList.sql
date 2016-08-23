create procedure [dbo].[GetMeasurementList]
as
begin
begin try
select id as Mess_id ,name as Mess_name from MeasurementUnit
end try
begin catch
print 'error in GetMeasurementList sp'
end catch
end