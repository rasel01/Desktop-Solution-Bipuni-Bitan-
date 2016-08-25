
ALTER proc [dbo].[Insert_Update_Item]
@image varbinary(MAX),
@ItemName nvarchar(100),
@catagoryId int,
@branID int,
@unitID int,
@itemDes nvarchar(1000),
@itemID int,
@createby varchar(10),
@createDate datetime,
@modifyby varchar(10),
@modifyDate datetime
as
if(@itemID = '')
begin
	
			 begin try
				
					
				insert into Item 
				(name
				,item_description
				,Item_Image
				,Brand_id
				,Catagory_id
				,Munit_id
				,createby
				,createDate
				,modifyby
				,modifyDate
				
				)
				values
				(@ItemName
				,@itemDes
				,@image
				,@branID
				,@catagoryId
				,@unitID
				,@createby
				,@createDate
				,@modifyby
				,@modifyDate
				
				)

		
end try
 begin catch
 print 'error in Item insert query'
 end catch
end

else

begin
		begin try
			update Item
			set 
			name =@ItemName,
			Item_Image = @image,
			Catagory_id = @catagoryId,
			Brand_id = @branID,
			Munit_id = @unitID,
			item_description = @itemDes
			where id = @itemID
		end try

		begin catch
		print 'error in Item update query'
		end catch
end