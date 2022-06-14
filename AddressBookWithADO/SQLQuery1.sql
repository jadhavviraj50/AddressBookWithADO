create procedure [SpAddressBook]
 (
 @FirstName varchar(100),
 @LastName varchar(100),
 @Address varchar(100),
 @City varchar(100),
 @State varchar(100),
 @Zip varchar(200),
 @PhoneNumber varchar(100),
 @Email varchar(100)
 )
 as
 begin
  Insert into AddressBook values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email)
 End

 SELECT * FROM AddressBook;