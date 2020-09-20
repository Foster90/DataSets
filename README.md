# DataSets

Sencon Programming Exercises

Exercise 5:
Programmatically create a SQLServer database table called ‘TestTable’ with the following column definitions.
TestTableID – Guid (Primary Key)
Field1 – integer
Field2 – DateTime
Field3 – String (64 characters)
Add some test rows to the table with Field1 containing random values between 1 and 100.

Create in SQL table script and have random data script.

Exercise 6:
Using the table created in Exercise 5 create a typed dataset and add a function that allows a record to be selected given the primary key value.

Pulled my data from SQL databse test_db connections string and database will need to be updated for project to work on another PC.

Exercise 7:
Using the typed dataset from Exercise 6 return all records and then using LINQ extract a list of records from the dataset with a Field1 value greater than 50. Bind the list to a combo box to display the Field3 value in the drop down and set the primary key field as the selected value.

Linq query works as excepted.

Exercise 8:
Using the typed dataset from Exercise 6 return all records and then serialize the data to a file. Then clear the dataset and de-serialize the data from the file created.

Hard coded the file directory this will need to be updated depending your required location.
