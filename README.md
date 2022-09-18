# S3 Security System

## How to install
clone the github repo or download zip file

open the solution `S3 Security System.sln` with Visual Studio

### Connect Database

To connect the database, right click on `connected Services` to add database

![Screenshot (14)](https://user-images.githubusercontent.com/62944890/190926078-d07a3ab9-b8e9-46b8-b2f1-a80cecf025f5.png)

![Screenshot (15)](https://user-images.githubusercontent.com/62944890/190926089-2f9ba72d-bb45-431d-97d0-07e40f57cd2d.png)

Once in the `Connect to Dependency` window, select `SQL Server Express localDB(local)` then Next
![Screenshot (18)](https://user-images.githubusercontent.com/62944890/190926205-10918ad1-7185-4125-96c2-b0a6b07f387f.png)

In the following menu change connection string name to `ConnectionStrings:S3_Security_SystemContextConnection`

Select the database file by selecting `...` next to connection string value input

![Screenshot (19)](https://user-images.githubusercontent.com/62944890/190926451-c03a96a9-1fba-4490-a5de-b06c27e3675f.png)

And select `Attach a database file`, 
![Screenshot (20)](https://user-images.githubusercontent.com/62944890/190926628-28457a20-6a34-42fb-a574-eea1e4df2c54.png)

use `Browse` file picker to select the database file, which is located in the base of the project folder

![Screenshot (21)](https://user-images.githubusercontent.com/62944890/190926690-ee656eee-a2c3-4cd6-8dda-a62051c20ce6.png)

Test connection

Select okay, then Finish

Now replace the the old ConnectionString with the new one in the `appsettings.json` file
![Screenshot (22)](https://user-images.githubusercontent.com/62944890/190926856-6d89622f-5fb1-423f-b3b6-391ede947850.png)

The  ConnectionString can be found in the SQL Server Object Explorer under the database's properties
![Screenshot (25)](https://user-images.githubusercontent.com/62944890/190927004-b3f67463-a8e2-49c4-863e-b66192b2831f.png)
![Screenshot (26)](https://user-images.githubusercontent.com/62944890/190927007-a30a84a4-e8d1-4584-b7cf-fd801b89e4f2.png)

Start the Application
