# Product List Manager
##Description
A simple application for managing products by storing them in a list.
## Features
- Simple to use interactive interface
- Persistence, can save a list to a .json file and restore it on startup
## Technologies
- .NET
- C#
- LINQ
- JSON
## Installation
Clone the repository:

	git clone https://github.com/delindblad/Product-List-Manager.git

For some reason I got an error message when testing and had to run:

	dotnet restore
	
first.

Then build the project in the folder with the command:

	msbuild "Product List Manager.slnx" -p:Configuration=Release



The resulting executable will be under "\bin\Release\net10.0\".

## How to run
Just run the executable "Product List Manager.exe". And follow the instructions

## Screenshots

<img width="546" height="388" alt="image" src="https://github.com/user-attachments/assets/cd572171-5ab1-402f-98e6-2569036f7833" />

<img width="1138" height="670" alt="image" src="https://github.com/user-attachments/assets/4475ca90-6b5f-487f-8b35-a5868f7af053" />

<img width="819" height="229" alt="image" src="https://github.com/user-attachments/assets/b0b8de96-3ee6-4f4c-a900-b29875b92e90" />

## Team members
Only me.

## Future improvements
Nothing planned.

## Answers to "Interview-Style Questions"

### Beginner Questions

What is the difference between List and Array?
	
	Arrays store the data sequentially in memory, whilw lists uses references.
	Lists are in many ways more robust, but access can be slower compared to arrays since the list will have to be traversed.
	With an array elements can be accessed in constant time, but inserting and deleting can be slower since the wole array has to be copied.

What does int.TryParse() do?

	It checks if the argument string can be pased as an int and returns a bolean value. If successful, it returns true and stores the result in the second argument, which is a reference.

Why should validation be separated into methods?

    It will make the code easier to read and manage, and will make things more modular.

### Intermediate Questions

What is encapsulation?
	
    It's a concept used in Object oriented programming. It is basically a way to hide the internals, provide an interface to the programmer, and prevent bugs by restricting access.


Why use classes instead of plain strings?
	
    Classes have associated methods which makes them more convenient to use.

What is LINQ?
	
    A declarative query language that can be embedded in C# code. It is used to extract data from structures.

### Advanced Questions



What design improvements would you make?
	
    I would use a proper DBMS and make it more asynchronous. I would also design it as a client/server application.
  


How would you store products in a database?
	
    I would use a relational model.
  


How would you unit test validation logic?
	
    By continuously running assertion tests.





  
