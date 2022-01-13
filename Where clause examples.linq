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

// Where clause
//This is a filter method
//the conditions are set up as you would in C#
//beware that Linqpad (Linq) may NOT like some C# syntax(DateTime)
//Beware that Linq is converted to SQL which may not like certain C# syntax
//because it could not be converted.

//Syntax

//For the Query
//where condition [logical operator condition2...]

//for method
//You notice that this syntax makes use of lambda expressions
//LambDa are common when performing Lind=f with the method syntax
//  .Where(LambDa experession) such as
// .Where(x => condition [logical operator condition2....]


// Find all albums released in a particular year. Display the
// entire album record.
//Example
// year 2000

Albums
	.Where(x => x.ReleaseYear == 2000)
	.Select(x => x)

//Find all albums released in the 90s (1990 - 1999)
//Display the entire album record

//Albums
//	.Where(x => x.ReleaseYear >= 1990 && x.ReleaseYear <= 1999)
//	.Select(x => x)

//Fina all the albums of the artist Queen
//Dispaly the entire album record.

Artists
	.Where(x => x.Name == "Queen")
	.Select(x => x)


//conern: The artist name is in another table
//      in an sql Select you would be suing an inner join
//      in Linq you Do not need to specifiy your inner joins
//      if there is an existing  "navigational properties" within
//       your entity that reflects the relationship between the tables.


//.Equals(....) is an exact match, in sql = or like 'string'
//.Contains(...) is a string match, in sql '%' + string + '%'
Albums
    .Where(x => x.Artist.Name.Contains("Queen"))
    .Select(x => x)


//Find all albums where the producer (Label) is unknown (null)
Albums
	.Where(x => x.ReleaseLabel == null)
	.Select(x => x)
	
