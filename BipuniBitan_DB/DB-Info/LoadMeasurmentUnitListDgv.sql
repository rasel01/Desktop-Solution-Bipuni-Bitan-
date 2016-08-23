
ALTER proc [dbo].[LoadMeasurmentUnitListDgv]
as
begin

begin try
select MeasurementUnit.id as Mess_ID, MeasurementUnit.name as Measurment_Name, UserInfo.createby as CreationBy,
UserInfo.id as CreationID ,MeasurementUnit.Remarks as Measurement_Remarks 
from MeasurementUnit
inner join 
UserInfo 
on
MeasurementUnit.createby = UserInfo.id
where 
MeasurementUnit.createby = UserInfo.id
end try
begin catch
print 'error in LoadMeasurmentUnitListDgv sp'
end catch

end
