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

//Grouping

//When you create a group, it builds two (2) components
// a) Key component (group by values)
//		reference this component using the groupname.Key[.Property]
//	(property < -> column <- > field < - > attribute < - > value)
// b) data of the group (instances of the collection)

//Ways to group
//a) by a single column (field, property, attribute, value)  -- this means u will use groupname.Key

//b) by a set of columns (anonymous dataset) -- you will use groupname.Key.PropertyName

//c) by using an entity (x.navproperty) as the item that you want *** try to avoid because the grouping will be done on everything in that entity including the primary key....but if you need to , use  groupname.Key.PropertyName

//Concept processing
//start with a "pile" of data (original collection)
//Specify the grouping property or property(ies)
// result of the group operation will be to "place the data into smaller piles"
//   the piles are dependednt on the grouping property(ies) vaslues(s)
//   the grouping property(ies) becomes the key
//   the individual instances of the data in the smaller piles
//   the entire individual instance are the original collection is placed in the  smaller pile
//Manipulate each of the "smaller piles" using your Linq commands

//grouping is an excellent way to organize your data especially if you need to process  data  on a property that is NOT a "relative key"
// such as a foreign key which forms a "natural" group using the navigational properties.

//grouping is different from Ordering

//Ordering is the re-sequencing of a collection for a display

//grouping re-organizes a collection into deparate, usually smaller collection for processing.

//Question

//Display albums by ReleaseYear

//This request does not need grouping
//  this request is an ordering of output (OrderBy)
// This affects display only


//Answer  -- Method syntax
Albums
	.OrderBy(x => x.ReleaseYear)

	//Display albums grouped by ReleaseYear

// This is an explicit request to breakup the display into desired "piles" (collections)
Albums
	.GroupBy(x => x.ReleaseYear)
	
	//Query syntax
	
from x in Albums
group x by x.ReleaseYear


//processing on the created groups of the GroupBy command

//Method syntax

Albums
	.GroupBy(x => x.ReleaseYear)    // this method returns a collection of mini-collections
	.OrderBy(bob => bob.Key)
	.Select(Igbo => new
				{
					Year = Igbo.Key,
					NumberofAlbums = Igbo.Count()
				}
			    ) //the select processes each mini-collection one at a time

	//Query syntax*************
     // Using this syntax, you must specify the name you wish to use to specify the  grouped (mini-collections) collections
	 //AFTER coding your group command, you must (are restricted to ) use the name you have given  your group collections.
from x in Albums
//orderby x.ReleaseYear  -- would be valid because "a" is still in context
group x by x.ReleaseYear into Igbo
//orderby x.ReleaseYear  -- would be invalid because "A" is out of context, group name is Igbo.
//orderby Igbo.Key  -- would need to use Igbo (in context) and reference the key value [.Key]
select( new
	{
	Year = Igbo.Key,
	NumberofAlbums = Igbo.Count()
	}
	)
	
	
	
//*********Use a multiple set of properties to form the group***********
	
	//inlcude a nested query to report on the "mini-collection" (small piles) of the grouping
	
	//Display albums grouped by ReleaseLabel, ReleaYear. Display the 
	//ReleaseYear and the number of albums. List only the years with 2
	// or more albums released.
	
	
	//Solution
	
	//Original Collection (large pile of data): Albums
	//filtering cannot be decided until the groups are created.
	//grouping: ReleaseLabel , ReleaseYear( an anonymous set)
	//filtering: group.Count >= 2
	//report: year, count of albums, list of albums in the group (nested query)
	
	Albums
	.GroupBy(a => new {a.ReleaseLabel, a.ReleaseYear})
	.Where(Igbo => Igbo.Count() >= 2)
	//.OrderBy(Igbo => Igbo.Key) ---- will not work because we did not specify the property
	.OrderBy(Igbo => Igbo.Key.ReleaseYear)
	.Select(Igbo => new
	{
		Label = Igbo.Key.ReleaseLabel,
		Year = Igbo.Key.ReleaseYear,
		NumberofAlbums = Igbo.Count(),
		AlbumGroupItems = Igbo
							.Select(IgboInstance => new
							{
								TitleOnAlbum = IgboInstance.Title,
								YearOnAlbum = IgboInstance.ReleaseYear,
								TrackCount = IgboInstance.Tracks.Count()
							})
	}
	)


	
