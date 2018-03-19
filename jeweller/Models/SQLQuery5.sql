Create procedure [dbo].[regcustomer]  
( 
   @Name varchar (50), 
   @Contact varchar (15), 
   @Email varchar (50),  
   @Address varchar (255) ,
   @Pincode varchar(10)
)  
as  
begin  
   Insert into customer values( @Name,@Contact, @Email, @Address, @Pincode)  
End
