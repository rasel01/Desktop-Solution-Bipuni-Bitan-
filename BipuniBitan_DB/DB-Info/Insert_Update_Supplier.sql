
Create proc [dbo].[Insert_Update_Supplier]
@SuppID int,
@SuppName nvarchar(20),
@suppAddress nvarchar(100),
@suppCompanyName nvarchar(50),
@suppContactPersonName nvarchar(20),
@suppPhoneNumber nvarchar(15),
@suppCountry nvarchar(15),
@suppCity nvarchar(20),
@suppEmail varchar(30),
@suppWebAddress varchar(30),
@createby varchar(10),
@createDate datetime,
@modifyby varchar(10),
@modifyDate datetime
as
if(@SuppID = '')
begin
	
			 begin try
				
					
				insert into SupplierInfo 
				(name
				,Company
				,Address
				,Phone_Number
				,City
				,Country
				,webAddress
				,Email
				,Contact_Person_Name
				,createby
				,createDate
				,modifyby
				,modifyDate
				
				)
				values
				(@SuppName
				,@suppCompanyName
				,@suppAddress
				,@suppPhoneNumber
				,@suppCity
				,@suppCountry
				,@suppWebAddress
				,@suppEmail
				,@suppContactPersonName
				,@createby
				,@createDate
				,@modifyby
				,@modifyDate
				
				)


			

			

		
end try
 begin catch
 print 'error in SupplierInfo insert query'
 end catch
end

else

begin
		begin try
			update SupplierInfo
			set 
			name =@SuppName,
			Company = @suppCompanyName,
			Address = @suppAddress,
			Phone_Number = @suppPhoneNumber,
			City = @suppCity,
			Country = @suppCountry,
			webAddress = @suppWebAddress,
			Email = @suppEmail,
			Contact_Person_Name =@suppContactPersonName
			where id = @SuppID
		end try

		begin catch
		print 'error in SupplierInfo update query'
		end catch
end