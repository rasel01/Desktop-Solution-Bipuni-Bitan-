create procedure LoadSupplierListDgv
as
begin
begin try
select * from SupplierInfo
end try
begin catch
print 'error in LoadSupplierListDgv sp'
end catch
end