

ALTER procedure [dbo].[DeleteFromBrand]
@Brand_id int
as
if exists(select * from Brand where id =@Brand_id)
begin
	begin try
	delete from Brand where id =@Brand_id
	end try
	begin catch
	print 'error DeleteFromCatagory sp '
	end catch
end