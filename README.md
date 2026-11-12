## Setup
1. Change the connection string in appsettings.json to match your machine's

2. Apply any migrations Update-Database -Context LibraryDbContext

3. Import onto the new machine:

Open SSMS on the new machine and connect to its SQL Server

Right-click the Databases folder and select Import Data-tier Application...

Browse to your .bacpac file(which contains the existing data in the database), give the database the same name, and click Finish.

Verification: Expand the newly imported database in SSMS, right-click a table (like Books), and click Select Top 1000 Rows to verify your data is intact.