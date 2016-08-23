Create proc LoadBrandListDgv
as

begin
begin try
	select Brand.id as Brand_id,Brand.name as Brand_Name,Catagory.id as catagory_id,Catagory.name as Catagory_Name,
UserInfo.createby as Creationby,Brand.Remarks as Brand_Remarks
 from Brand
 inner join
 Catagory 
 on
 Catagory.id = Brand.Catagory_id
 inner join
 UserInfo 
 on
 UserInfo.id = Brand.createby
end try 
begin catch
print 'errror in LoadBrandListDgv sp'
end catch


end
