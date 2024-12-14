# TaskManagmenetAPI
1. Covered all the scenarios that are mentioned in the Task assignment PDF document.

2. Instructions to run the Project :
      - clone the project in your local drive

              - Install Git in your Machine (_https://git-scm.com/downloads/win_)

              - Open the GitBash on your local folder and type the below command
                - git clone https://github.com/manjunnaath/TaskManagmenetAPI.git

              - Open the solution in Visual Studio 2022

              - Build the solution

              - Run the Solution through IIS Express.

              - It will run on the localhost:<port_number>  (It will show as Localhost page not found . Do not panic ! ! ) Just add **_/swagger_** in that URL like below:

                    - _**https://localhost:<port_number>/swagger/index.html**_

3. Created 2 users as said in the Document - Admin and Normal User.

3. **AuthController** - For Login
                Admin Username: admin@admin.com;
                      Password: Admin@123
                Normal Username:  user@gmail.com
                       Password: User123!
4. Non-functional Requirements : 
      - Used .Net 9
      - Implemented Entity Framework Core with an in-memory database
      - IDE : Visual Studio 2022
      - ASP.Net Core , Entity Framework Core and In Memory Database
      - **Architecture : Dependency Injection + Repository Pattern + Service Layer Pattern**
5. Unit Test: Unit testing done for One Service layer and Controller


      
                       

