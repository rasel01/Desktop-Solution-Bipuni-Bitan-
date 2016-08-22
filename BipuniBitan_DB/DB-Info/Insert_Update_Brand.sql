
create proc [dbo].[Insert_Update_Brand]
@BrandID int,
@catagoryID int,
@Brandremarks nvarchar(100),
@BrandName nvarchar(100),
@createby varchar(10),
@createDate datetime,
@modifyby varchar(10),
@modifyDate datetime
as
if(@BrandID = '')
begin
	
			 begin try
				
					
				insert into Brand 
				(name
				,Catagory_id
				,createby
				,createDate
				,modifyby
				,modifyDate
				,Remarks)
				values
				(@BrandName
				,@catagoryID
				,@createby
				,@createDate
				,@modifyby
				,@modifyDate
				,@Brandremarks)


			

			

		
end try
 begin catch
 print 'error in Brand insert query'
 end catch
end

else

begin
		begin try
			update Brand
			set 
			name =@BrandName,
			Remarks = @Brandremarks
			where id = @BrandID
		end try

		begin catch
		print 'error in catagory Brand query'
		end catch
end
