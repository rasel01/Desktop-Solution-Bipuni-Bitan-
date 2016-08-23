
create proc [dbo].[Insert_Update_Measurement]
@Measurement_id int,
@Measurement_name nvarchar(100),
@Measurement_remarks nvarchar(100),
@createby varchar(10),
@createDate datetime,
@modifyby varchar(10),
@modifyDate datetime
as
if(@Measurement_id = '')
begin
	
			 begin try
				
					
				insert into MeasurementUnit 
				(name
				,createby
				,createDate
				,modifyby
				,modifyDate
				,Remarks)
				values
				(@Measurement_name
				,@createby
				,@createDate
				,@modifyby
				,@modifyDate
				,@Measurement_remarks)
	
end try
 begin catch
 print 'error in Measurement insert query'
 end catch
end

else

begin
		begin try
			update MeasurementUnit
			set 
			name =@Measurement_name,
			Remarks = @Measurement_remarks
			where id = @Measurement_id
		end try

		begin catch
		print 'error in Measurement update query'
		end catch
end