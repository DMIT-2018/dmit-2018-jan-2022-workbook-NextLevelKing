<Query Kind="Statements">
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

//Statement IDE

//We can have multiple queries written in this IDE environment.
//We can execute a query individually by highlighting the desired query first
//BY DEFAULT executing the file in this environment execute all queries
//  FROM TOP TO BOTTOM.

//IMPORTANT
//queries in this environment must be written using the 
//   C# language grammar for a statement. This means 
//  that each statement must end in a semi-colon.

//It appeasr that using LinqPad7 that a method syntax query 
//deos NOT need the semi-colon. Be careful about trying to implement the query in a C# class Library project without the semi-colon.

//   results MUST be placed in a receiving variables for query sytanx
//  To display the results, use the linqpad method  .Dump()

// query  syntax
// Find all albums released in a particular year. Display the
// entire album record.

// year 2000

//Example

var resultsq = from x in Albums
				where x.ReleaseYear == 2000
				select x;
resultsq.Dump();

// We can do this

var paramyear = 1990; //this value is being passed into the BLL method
var resultscq = from x in Albums
			   where x.ReleaseYear == paramyear
			   select x;
resultscq.Dump();

//Method syntax

Albums
    .Where(x => x.ReleaseYear == 2000)
	.Select(x => x)
	.Dump();


