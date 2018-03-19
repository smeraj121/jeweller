Create procedure [dbo].[UpdateProduct]  
(  
   @product_id int,    
   @product_name VARCHAR (50),  
   @weight VARCHAR (15),
   @purity varchar (50),  
   @descrip varchar (255),
   @rate varchar (50) ,
   @price varchar(10)
)  
as  
begin  
   Update product   
   set 
   product_name=@product_name,
   weight=@weight,
   purity=@purity,
   description =@descrip,
   rate=@rate
   where product_id=@product_id  
End