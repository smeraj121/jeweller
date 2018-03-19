Create procedure [dbo].[UpdateJeweller]  
(  
   @username varchar(50),  
   @password varchar(50),  
   @name varchar (50),  
   @contact1 varchar (15),
   @contact2 varchar (15),
   @email varchar (50),  
   @address varchar (255),
   @pincode varchar (10) 
)  
as  
begin  
   Update jeweller   
   set 
   password=@password,
   name=@name,
   contact1=@contact1,
   contact2=@contact2,
   email=@email,
   address=@address,
   pincode=@pincode
   where username=@username  
End