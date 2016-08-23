Alter procedure LoadSupplierListDgv
as
begin
begin try
select SupplierInfo.id as SuppID,SupplierInfo.name, SupplierInfo.Company as Company
 ,SupplierInfo.Address as Address, SupplierInfo.Phone_Number as Phone_Number, 
 SupplierInfo.City as City, SupplierInfo.Country as Country, SupplierInfo.webAddress as webAddress,
 SupplierInfo.Email as Email, SupplierInfo.Contact_Person_Name as  Contact_Person_Name,
 UserInfo.id as createID,  UserInfo.name as createby
 
 from   SupplierInfo
 inner join
 UserInfo
 on
 SupplierInfo.createby = UserInfo.id
 where 
 SupplierInfo.createby = UserInfo.id

end try
begin catch
print 'error in LoadSupplierListDgv sp'
end catch
end