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

//Aggregates
//.Count()		Counts number of instances in the collection
//.Sum(x => ...)		sums(totals) a numeric field(numeric expression) in the collection
//.Min(x => ...)		Finds the minimum value of a collection of values based on a field
//Max(x => ...) 	Finds the maximum values of a collection  of values based om a field
//Average(x => ...)  Finds the numeric average value of a collection of numeric values 

//IMPORTANT!!!

//Aggregates work only on a collection of values for a particular field
//Aggregates DO NOT work on a single instance(based on data type)

//Syntax
//query
//To create a collection using a query, we do
//  (from.....
//      ....
//   select expression).aggregate()

//method ... we will concentrate on method syntax

//   collectionset.aggregate(x => expression)

//  OR

//	 collection.Select(x => expression).aggregate()

//Exception
//Count does not need an expression(delegate)
//collectionset.Count()
//remember the expression is resolved to a single field value per instance for Sum, Min, Max and Average

//Question

//Find the average playing time(length) of tracks in our music collection

//Solution 
//thought process
//recall average is an aggregate
//ask what is the collection? - a track is a member of the Tracks table
//What is the expression? Millisecond indicates track playing time(lenght)

//using query syntax

(from tr in Tracks
select tr.Milliseconds).Average()
//note, the bracket runs first before the aggregate applies.

//Using Method syntax

Tracks.Average()
//we cannot use only tracks becus it returns more than one value. Average does not know what property to use. Therefore Tracks.Average will not work so we modify it as

Tracks.Select(tr => tr.Milliseconds).Average()  //works because we took in the collection and averaged it

//Or we use

Tracks.Average(tr => tr.Milliseconds) // works because we are thelling it to average the instances of the Milliseconds

//Let us try count

Tracks.Count()   // this counts the instances of track

//trying SUM

Tracks.Sum(tr => tr.Name) // Can work because of it is not a numeric so we do

Tracks.Sum(tr => tr.Milliseconds) //let us divide by 60000 to conver to minutes, the by 60 to convert to hrs then by 24 to get in days
Tracks.Sum(tr => tr.Milliseconds) / 60000 /60/24

//let us try Track ID
Tracks.Sum(tr => tr.TrackId)  // As long as it is numeric, sum works on it but the thing is sum does not ask if the value is meaningful to you or not.


//Question List all albums of the 60s showing the title, artist and various 
//aggregates for the albums containing the tracks.

//For each album, show the number of tracks, the longest playing track,
//the shortest playing track, the total price of all tracks and the
//average playing lenght of the album tracks.

//Hint: Albums has two navigational properties
//		Artist: points to the single parent record
//		Tracks: points to the collection of child records(tracks) of the album.


//Solution

Albums
	.Where(x => x.ReleaseYear >= 1960 && x.ReleaseYear < 1970 && x.Tracks.Count() > 0)
	.Select(x => new{
		Title = x.Title,
		Artist = x.Artist.Name,
		NoTracks = x.Tracks.Count(),
		LongTrack = x.Tracks.Max(tr => tr.Milliseconds),
		ShortTrack = x.Tracks.Min(tr => tr.Milliseconds),
		//LongTrack = (from t in x.Tracks select tr.Milliseconds).Min(),
		TotalPrice = x.Tracks.Select(tr => tr.UnitPrice).Sum(),
		AverageTrack = x.Tracks.Average(tr => tr.Milliseconds)
	})
		
		
Albums












