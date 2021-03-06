using AddressBook_ADO.NET;

Console.WriteLine("Welcome to AddressBook ADO.NET!");


AddressBookData addressBookData = new AddressBookData();


Console.WriteLine("Select option\n1)Create AddrssBookServiceDatabase\n2)Create AddressBookTable\n3)Inserting Details to DataBase\n4)retrieve Details From dataBase\n5)Update Contacts\n6)Delete Contact\n7)Get Contact By City\n8)Get Contact By State\n9)Size of addressbook by city/state" +
    "\n10)Get contact for city sorted by name\n11)Added Columns Of Type & Name\n12)Count records of family\n13)Add Contact to both family & friend");
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
        addressbook.FirstName = "Mitali";
        addressbook.LastName = "Jadhav";
        addressbook.Address = "Shelu";
        addressbook.City = "Panvel";
        addressbook.State = "Maharashtra";
        addressbook.Zip = "410206";
        addressbook.PhoneNumber = "1234567890";
        addressbook.Email = "mitalijadhav@gmail.com";
        addressBookData.AddContact(addressbook);
        Console.WriteLine("Record Inserted successfully");
        break;
    case 4:
        addressBookData.GetAllContact();
        break;
    case 5:
        string UpdatedAddress = addressBookData.updateEmployeeDetails();
        Console.WriteLine(UpdatedAddress);
        Console.WriteLine("Record Updated successfully");
        break;
    case 6:
        addressBookData.deleteEmployeeDetails();
        Console.WriteLine("Record deleted successfully");
        break;
    case 7:
        Console.WriteLine("Get Contacts by City name");
        addressBookData.GetAllContactByCity();
        break;
    case 8:
        Console.WriteLine("Get Contacts by State name");
        addressBookData.GetAllContactByState();
        break;
    case 9:
        int countCity = addressBookData.CountOfEmployeeDetailsByCity();
        Console.WriteLine("Count of Records for given City :" + countCity);
        int CountState = addressBookData.CountOfEmployeeDetailsByState();
        Console.WriteLine("Count of Records for given State :" + CountState);
        break;
    case 10:
        Console.WriteLine("Get Contacts for given City sorted by FirstName");
        addressBookData.GetAllContacsSortByName();
        break;
    case 11:
        Console.WriteLine("Adding Columns AddressBookName and AddressBookType to AddressBook Table");
        addressBookData.AddAddressBookNameAndType();
        break;
    case 12:
        int countByType = addressBookData.CountOfEmployeeDetailsByType();
        Console.WriteLine("Count of Records by Type Family :" + countByType);
        break;
    case 13:
        addressBookData.AddContactAsFriendAndFamily();
        Console.WriteLine("Added Contact to both Family and Friend");
        break;

    default:
        Console.WriteLine("Please choose the correct option!");
        break;
}