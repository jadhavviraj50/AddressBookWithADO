using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    public class AddressBookData
    {
        public void Create_Database()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =master; Integrated Security = True;");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create database AddressbookForADO;", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressbookService Database created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating database:" + e.Message + "\t");
            }
        }

        /// Created Table in addressbook service database
        public void CreateTables()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressbookForADO; Integrated Security = True;");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create table AddressBook(id int identity(1,1)primary key,FirstName varchar(200),LastName varchar(200),Address varchar(200), City varchar(200), State varchar(200), Zip varchar(200), PhoneNumber varchar(50), Email varchar(200)); ", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressBook table has been  created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t");
            }
        }


        //Created Connection file

        public const string ConnFile = @"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressbookForADO; Integrated Security = True;";
        SqlConnection connection = new SqlConnection(ConnFile);
        /// <summary>
        /// Method to insert data in database
        /// </summary>
        /// <param name="model"></param>
        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddressBook", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Zip", model.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", model.Email);


                    this.connection.Open();

                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        /// Fetching all data from Database

        public void GetAllContact()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.AddressBookId = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine(addressmodel.FirstName + " " +
                                addressmodel.LastName + " " +
                                addressmodel.Address + " " +
                                addressmodel.City + " " +
                                addressmodel.State + " " +
                                addressmodel.Zip + " " +
                                addressmodel.PhoneNumber + " " +
                                addressmodel.Email + " "

                                );
                            Console.WriteLine();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        // method to Update detail of already existing details
        public string updateEmployeeDetails()
        {
            AddressBookModel addressmodel = new AddressBookModel();

            SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            SqlCommand command = new SqlCommand("update AddressBook set Address='Rasayani' where FirstName='Mayuri'", connection);

            int effectedRow = command.ExecuteNonQuery();
            if (effectedRow == 1)
            {
                string query = @"Select Address from AddressBook where FirstName='Mayuri';";
                SqlCommand cmd = new SqlCommand(query, connection);
                object res = cmd.ExecuteScalar();
                connection.Close();
                addressmodel.Address = (string)res;
            }
            connection.Close();
            return (addressmodel.Address);
        }


        // method to Delete employee details
        

        public void deleteEmployeeDetails()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True; TrustServerCertificate=True;");
            connection.Open();
            string query = @"DELETE FROM AddressBook where FirstName = 'Mitali'";
            SqlCommand cmd = new SqlCommand(query, connection);
            object res = cmd.ExecuteScalar();
            connection.Close();
            
        }

        public void GetAllContactByCity()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook where City='Panvel';";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.ID = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressmodel.ID, addressmodel.FirstName, addressmodel.LastName, addressmodel.Address, addressmodel.City, addressmodel.State, addressmodel.Zip, addressmodel.PhoneNumber, addressmodel.Email);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetAllContactByState()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook where State='Alberta';";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.ID = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressmodel.ID, addressmodel.FirstName, addressmodel.LastName, addressmodel.Address, addressmodel.City, addressmodel.State, addressmodel.Zip, addressmodel.PhoneNumber, addressmodel.Email);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //UC7-Size of AddressBook by city and state
        public int CountOfEmployeeDetailsByCity()
        {
            int count;
            SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string query = @"Select count(*) from AddressBook where City='Panvel';";
            SqlCommand command = new SqlCommand(query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
            int Count = (int)res;
            return Count;
        }
        public int CountOfEmployeeDetailsByState()
        {
            int count;
            SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string query = @"Select count(*) from AddressBook where State='Alberta';";
            SqlCommand command = new SqlCommand(query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
            int Count = (int)res;
            return Count;
        }

        public void GetAllContacsSortByName()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook where City='Panvel' order by FirstName;";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.ID = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressmodel.ID, addressmodel.FirstName, addressmodel.LastName, addressmodel.Address, addressmodel.City, addressmodel.State, addressmodel.Zip, addressmodel.PhoneNumber, addressmodel.Email);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Add AddressBookName and Type as Columns
        public void AddAddressBookNameAndType()
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string query = @"alter table AddressBook add AddressBookName Varchar(50), AddressBookType Varchar(50);";
            SqlCommand command = new SqlCommand(query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
        }

        //Count Records by AddressBookType
        public int CountOfEmployeeDetailsByType()
        {
            int count;
            SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string Query = @"Select count(*) from AddressBook where AddressBookType='Family';";
            SqlCommand command = new SqlCommand(Query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
            int Count = (int)res;
            return Count;
        }
    }
}
    



