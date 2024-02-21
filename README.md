# Library Management System

The Library Management System is built using the Model-View-Controller (MVC) architectural pattern with C# .NET and Entity Framework 6 Code First, employing MVC 5. It allows librarians to efficiently manage books, borrowers, and borrowing activities. The system includes the following features:

CRUD Operations:

Create, Read, Update, and Delete operations for books, borrowers, and borrowing activities.
List Books by Category:

The system allows librarians to list books based on their categories, facilitating easier navigation and search for specific genres or subjects.
List Currently Borrowed Books:

Librarians can view a list of books that are currently borrowed by borrowers. This feature helps in tracking the status of books and managing borrowing activities effectively.
List Overdue Borrowed Books:

The system provides a feature to list currently borrowed books that are overdue. It helps librarians identify books that need to be returned promptly and manage overdue fines efficiently.
Key Components:

Model:

The model represents the data entities of the library system, including books, borrowers, and borrowing activities. These entities are defined using Entity Framework 6 Code First approach.
View:

Views represent the user interface components of the application. They include forms, pages, and controls through which librarians interact with the system. Views are designed using Razor syntax and HTML to ensure a user-friendly experience.
Controller:

Controllers act as intermediaries between the model and view components. They handle user requests, process data, and orchestrate interactions between the model and view layers. Controllers implement CRUD operations and business logic to ensure proper functioning of the application.
Technologies Used:

C# .NET Framework
ASP.NET MVC 5
Entity Framework 6 (Code First)
Razor View Engine
HTML, CSS, JavaScript (for frontend interactions)
