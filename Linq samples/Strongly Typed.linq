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
	//Strongly typed query datasets
	
	//strongly typed refers to a C# defined datatype(int, string, decimal, ..)
	// OR developer defined datatype (class, struct, array)
	
	//Anonymous data set from a query does NOT have a specified class definition.
	//Strongly typed query datasets HAS a specified class definition.
	
	
	//Question
	
	//Find all songs that contain a partial string of the Track name.
	//List Album, Song, and Artist Name.
	
	//Imagine the following is in the code-behind of our Razor page
	
	string partialSongName = "dance"; //[BindProperty] partialSongName{get; set;}
	List<SongList> results = SongByPartialName(partialSongName);
	results.Dump();
}

// You can define other methods, fields, classes and namespaces here

public class SongList
{
	public string Title{get; set;}
	public string Song{get; set;}
	public string Artist  { get; set; }
}

//imagine you have the following method in a BLL service class, what will we send back.

//We will send back the below

List<SongList> SongByPartialName(string partialSongName)
{
	IEnumerable<SongList> songCollection = Tracks
						 .Where(t => t.Name.Contains(partialSongName))
						 .Select(t => new SongList
						 {
						 	Title = t.Album.Title,
							Song = t.Name,
							Artist = t.Album.Artist.Name
						
						 });
		
	return songCollection.ToList();
}
