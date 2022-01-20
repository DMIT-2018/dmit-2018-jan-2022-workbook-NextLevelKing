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

//Using the ternary operator

//tenary operator syntax
//  condition(s) ? true value : false value

// both true value and false value must resolve to a 
//SINGLE piece of data (a single value)

//compare to a conditional statement

//if(condition(s)
//[{]
//		true path(complex logic)
//[}]
//else
//	[{]
//		false path (complex logic)
//  [}]

//just like a conditional statement which can have nested logic, the true value and false value
// can have nested ternary operators as long as
// the final result resolves to a SINGLE value

//Questions

//List all albums by release label. Any album with
// no label should be indicated as Unknow. List Title, Label and Artist name.

//Solution

Albums
	//.OrderBy(x => x.ReleaseLabel)
	.Select(x => new
	{
		Title = x.Title,
		Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel,
		Name = x.Artist.Name
	})
	.OrderBy(x => x.Label)
		


//Questions

//List all albums showing the title, Artist name, Year and decade of release(oldies, 70s, 80s, 90s, or modern)
//Order by artist.

Albums
    .OrderBy(x => x.Artist.Name)
	.Select(x => new
	{
		Title = x.Title,
		Name = x.Artist.Name,
		Year = x.ReleaseYear,
		decade = x.ReleaseYear <=1969 ? "Oldies": 
                 x.ReleaseYear <=1979? "70s": 
                 x.ReleaseYear <=1989? "80s":
                 x.ReleaseYear <=1999? "90s" : "Mordern"
	})
	


//Order by the release decade (oldest to newest)
Albums
    
    .Select(x => new
    {
        Title = x.Title,
        Name = x.Artist.Name,
        Year = x.ReleaseYear,
        decade = x.ReleaseYear < 1970 ? "Oldies": 
                 x.ReleaseYear < 1980? "70s": 
                 x.ReleaseYear <1990? "80s":
                 x.ReleaseYear < 2000? "90s" : "Mordern"
    })
    .OrderBy(x => x.Year)
	
//This means
//if condition
//  	oldies
//else

