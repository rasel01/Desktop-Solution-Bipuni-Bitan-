Alter proc GetBrandNameListCatagoryWise
@catagory_Id int 
as
begin
begin try
select id as brand_id,name as Brand_Name  from Brand where Brand.Catagory_id = @catagory_Id
end try
begin catch
print 'error in GetBrandNameListCatagoryWise sp'
end catch
end