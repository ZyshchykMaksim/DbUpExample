# DbUpExample
Using Database Project and DbUp for database management

**DOCUMENTATION**
 https://dbup.readthedocs.io/en/latest/usage/
 
**SCRIPTS EXAMPLE**
  1. Create database: 000001-Create_Table_1 | naming_format {order-name}
  2. Insert table with data : 000001-Create_Table_2 | naming_format {order-name}
  3.  Insert data to table : 000001-Insert_Data_In_Table_1 | naming_format {order-name}
 
**POWERSHELL COMMANDS**
 * 1. cd D:\Programming\Examples\DbUpExample\src\DbUpExample\DbUpExample\bin\Debug\netcoreapp3.1
 * 2. dotnet DbUpExample.dll "Server=(localdb)\MSSQLLocalDB; Database=LD_TEST; Trusted_connection=true;" "D:\Programming\Examples\DbUpExample\src\DbUpExample\DbUpExample\SQL_SCRIPTS"