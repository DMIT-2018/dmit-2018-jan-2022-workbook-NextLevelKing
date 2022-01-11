<Query Kind="Expression">
  <Connection>
    <ID>63abe02c-188c-4c61-ac5b-ac85a66b33fd</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Our code is using C# grammar/syntax.

//comments are done with slashes
//hotkey to comment  cntrl+k, ctrl+c
//          uncomment ctrl+k, ctrl+u
//alternately use ctrl+ / as a toggle

//Expressions
// Single linq query statements without a semi-colon
//  you can have multiple statements in your file BUT 
//if you do so, you must highlight the statement to execute

 //executing using F5 or the green trianle on the query menu.
 
 //to toggle your results on and off (visible) use ctrl + r
 
 // Query Syntax
 // This uses a "sql-like" syntax
 //You can view the student notes for examples under
 //     Notes/Linq Intro
 // or Demo/eResturant/Linq Query and Method syntax
 
 //Question
 //query: Find all albums released in 2000. Display the entire album record.
 
 //Solution
 from instancerowofcollection in Albums
 where instancerowofcollection.ReleaseYear == 2000
 select instancerowofcollection

 //Method Syntax
 //Uses C# method syntax (OOP langauge grammar)
 //Start with collection
 //Collection(Albums)
 //to execute a method on the collection, you need to use 
 //     the access operator (dot operator)
 // this results in the returning of another collection from the method!!**
 //method name starts with a capital
 //method contains contents with a delegate
 //a delegate describes the action to be done.
 
 //C# method
 //access[static] void/datatype methodname([list of parameters])

 //Example - Solving the above question with method

   Albums
   .Where(instancerowofcollection => (instancerowofcollection.ReleaseYear == 2000))
   .Select(instancerowofcollection => instancerowofcollection)