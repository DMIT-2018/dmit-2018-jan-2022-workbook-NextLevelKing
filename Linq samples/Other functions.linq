<Query Kind="Program">
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

void Main()
{
	//Conversions
	//.ToList
	//can convert a collection to a list at any time
	
	
	//Example
	
	//Display all albums and tracks. display the album title
	//artist anme and album tracks. For each track, display the song.
	//name and playtime in seconds. Show only albums with 25 or more tracks
	
	//Soluntion
	
	
	List<AlbumTracks> albumlist = Albums
					.Where(a => a.Tracks.Count() >= 25)
					.Select(a => new AlbumTracks
					{
						Title = a.Title,
						Artist = a.Artist.Name,
						Songs = a.Tracks
									.Select(t => new SongItem
										{
											Song = t.Name,
											Playtime = t.Milliseconds/1000.0
										})
										.ToList()
						
					})
					.ToList()
					.Dump()
					;
					
	//If done in a BLL service method, typically
	//you would be returning the collection as a List<T>
	//return statement: return albumlist.ToList();
	
	//So let us do tightly typed...go back up.
	
	
	
	//Using FirstOrDefault()
	//this method returns the first instance of a collection
	//the expected collection may have 0, 1, or more instances(rows)
	//if there is a row, the first is used
	//if there is no row(s), using(), one get an Exception error
	//if there is a row(s), using FirstOrDefault, one gets an object default which is null... that is the default of an object.
	
	
	//Question
	string artistparam = "Deep Purple";
	var resultsFOD = Albums
						.Where(a => a.Artist.Name.Equals(artistparam))
						.Select(a => a)
						.OrderBy(a => a.ReleaseYear)
						.FirstOrDefault()
						//.Dump()
						;
	//after the query, I am going to do further processing...like
	if(resultsFOD != null)
		resultsFOD.Dump();
	else
		Console.WriteLine($"No albums found for artist {artistparam}");
		
		
		//Using Single or Default()
		//This method is similar to FirstOrDefualt in all aspects except:
		//		the collection is expecting only 0 or 1 instance(row)
		//If your collection can possibly have more than one instance, DO NOT USE,
		//	you will generate an Exception
		
		//Question
		
		//Find the album by albumid
		
	//Solution
	
	int albumid = 100;
	var resultsSOD = Albums	
						.Where(a => a.AlbumId == albumid)
						.Select(a => a)
						.Single()
						;
	if (resultsSOD != null)
		resultsSOD.Dump();
	else
		Console.WriteLine($"No albums found for artist {albumid}");
		
	//Using Distinct()
	//removes duplicate collection instances
	
	
	//Question
	
	var resultsC = Customers
						.OrderBy(c => c.Country)
						.Select(c => c.Country)
						.Distinct()
						.Dump()
						;
						
						
	// Using .Take() and .Skip()
	
	//These expect a positive numeric value
	//.TakeWhile(delegate) and .SkipWhile(delegate), action continues while delegate is true
	
	//In 1517, when using the paginator to do paging on your web page
	//you called your BLL service method with additional parameters
	//(pagesize, pagenumber) so that only need instances from your query collection were actually returned to the web page for dispaly.
	
	//a) service method receive: query parameter, pagesize, pagenumber
	//b) your query was executed
	//c) obtained the total count of the return collection(.Count())
	//d) calculated the number of records to skip (pagenumber - 1)* pagesize
	//e) on the return statement , you selected a certain set of rowsa of the collection using
	//		collection using
	//		return variablename.Skip(skipRows).Take(pagesize).ToList();
	
	
	
//Any and ALL
	
	Genres.Count().Dump();
	

//Question
//Let us show genres that have tracks which are not on any playlist
	Genres
		.Where(g => g.Tracks.Any(tr => tr.PlaylistTracks.Count() == 0))
		.Select(g => g)
		.Dump()
		;


	//Let show genres that have all their tracks appearing at least once on a playlist

	Genres
		.Where(g => g.Tracks.All(tr => tr.PlaylistTracks.Count() > 0))
		.Select(g => g)
		.Dump()
		;

	//Let show what ! will do


	Genres
		.Where(g => !g.Tracks.All(tr => tr.PlaylistTracks.Count() > 0))
		.Select(g => g)
		.Dump()
		;

	Genres
	.Where(g => !g.Tracks.Any(tr => tr.PlaylistTracks.Count() == 0))
	.Select(g => g)
	.Dump()
	;
	
	
	
	//there may be times that using a !Any() gives you All() and a !All() gives you Any() result.
}

public class SongItem
{
	public string Song {get; set;}
	public double Playtime {get; set;}

}


public class AlbumTracks
{
	public string Title{get; set;}
	public string Artist { get; set; }
	public List<SongItem>Songs {get; set;}
}

// You can define other methods, fields, classes and namespaces here