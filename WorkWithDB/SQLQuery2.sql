select GoodsCategory.GoodsID as 'ID', Goods.name as 'Name', Category.name as 'Category' 
from GoodsCategory
join Goods
on GoodsCategory.GoodsID = Goods.ID
left join Category
on GoodsCategory.CategoryID = Category.ID