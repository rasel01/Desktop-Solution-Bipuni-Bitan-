

create procedure [dbo].[DeleteFromSupply]
@Supp_id int
as
if exists(select * from SupplierInfo where id =@Supp_id)
begin
	begin try
	delete from SupplierInfo where id =@Supp_id
	end try
	begin catch
	print 'error DeleteFromSupply sp '
	end catch
end