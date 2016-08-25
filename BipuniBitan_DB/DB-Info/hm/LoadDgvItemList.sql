create proc LoadDgvItemList
as
begin
begin try
select Item.id as itemID, Item.name as item_name, Item.item_description as ides,Item.Item_Image as ItemImage,Item.Catagory_id as ItemCatID,Catagory.name as CatagoryName,
 Item.Brand_id as ItemBrandId,Brand.name as BrandName, Item.Munit_id as ItemMessID,MeasurementUnit.name as MessName  from Item
inner join
Catagory
on
Catagory.id = Item.Catagory_id
inner join
Brand 
on
Brand.id = Item.Brand_id
inner join 
MeasurementUnit
on
MeasurementUnit.id  = Item.Munit_id
end try
begin catch
print 'error in LoadDgvItemList sp';
end catch

end
