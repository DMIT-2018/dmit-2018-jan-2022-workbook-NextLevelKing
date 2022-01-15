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

//Sorting

//There is a significant difference in query and method syntax.

//query syntax is much like sql
//      orderby field {[ascending]|descending}, [,field{[ascending]|descending},....]    baracket means that you have to choose one of them.
// ascending is the default.

//method sytanx is a series of individual methods
//  .OrderBy(x => x.field)
//  .OrderByDescendingBy(x => x.field)
//after pne of these two begining methods
//if you have any othe field(s)
//  .ThenBy(x => x.field)
//  .ThenDescendingBy(x => x.field)


//Example

//Find all albums release in the 90's (1990 - 1999)
//Order the album by ascending year and then  alpabetically by Album title
// Display the entire album record.

//often the ordering phrase may be done with the word "within"
//with the "within" the implied order is minor to major in the list of fields
//  (order by alphabetically by album title withing year)
//without the "within" the implied order is major to minor in the list fields.

//in this case, 
//major: year       minor: title

//query syntax 
from x in Albums
where x.ReleaseYear > 1989 && x.ReleaseYear <= 1999
orderby x.ReleaseYear ascending, x.Title
select x

//method syntax

Albums
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
	.OrderBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => x)

//The result is still the same as below but it is always better to think of processing

Albums
	.OrderBy(x => x.ReleaseYear)
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
	.ThenBy(x => x.Title)
	.Select(x => x)