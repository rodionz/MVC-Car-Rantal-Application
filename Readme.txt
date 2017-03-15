1. Please note that, there is 2 version (sql and bak) of the same database.

2.Libriaries and plugins used:

-jQuery
-jQuery UI:
*date picker,
*autocomplete (for free text search of cars),
* pop-up windows
-DataTable: for design and functionality of tables: https://www.datatables.net/
-Moment.js : for parsing datetime formats (SQL-C#-Javascript): http://momentjs.com/


Regarding the role managment:
There are 3 kinds of roles: Manager, Employee, Guest.

Every authiticated user recieves the role of guest.
When manager adds new employee he automaticaly recieves role of Employee.
Manager us only one and can't be asign 