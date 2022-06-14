using AddressBook_ADO.NET;

Console.WriteLine("Welcome to AddressBook ADO.NET!");


AddressBookData addressBookData = new AddressBookData();


Console.WriteLine("Select option\n1)Create AddrssBookServiceDatabase\n2)Create AddressBookTable\n3)Inserting Details to DataBase\n4)retreiv Details From dataBase");
int op = Convert.ToInt16(Console.ReadLine());
switch (op)
{
    case 1:
        addressBookData.Create_Database();
        break;
    case 2:
        addressBookData.CreateTables();
        break;
    case 3:
        AddressBookModel addressbook = new AddressBookModel();
        addressbook.FirstName = "Viraj";
        addressbook.LastName = "Jadhav";
        addressbook.Address = "Panvel";
        addressbook.City = "Panvel";
        addressbook.State = "Maharashtra";
        addressbook.Zip = "410206";
        addressbook.PhoneNumber = "1234567890";
        addressbook.Email = "virajjadhav@gmail.com";
        addressBookData.AddContact(addressbook);
        Console.WriteLine("Record Inserted successfully");
        break;
    case 4:
        addressBookData.GetAllContact();
        break;
    default:
        Console.WriteLine("Please choose the correct option!");
        break;
}