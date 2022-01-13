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
	//ProgramIDE
	//you can have multiple query in this IDE environment
	// this environment works "like" a console application.

	// this allows one to pre-test complete components that can be moved directly into your backend application (class Library)

	// IMPORTANT
	//queries in this environment must be written using the 
	//   C# language grammar for a statement. This means 
	//  that each statement must end in a semi-colon.

	//It appeasr that using LinqPad7 that a method syntax query 
	//deos NOT need the semi-colon. Be careful about trying to implement the query in a C# class Library project without the semi-colon.

	//   results MUST be placed in a receiving variables for query sytanx
	//  To display the results, use the linqpad method  .Dump()

	//Example

	var paramyear = 1990; //this value is being passed into the BLL method
	var resultscq = GetALLQ(paramyear);
		resultscq.Dump();

//Method
	var paramyearM = 2000; //this value is being passed into the BLL method
	var resultscqM = GetALLQM(paramyearM);
	resultscqM.Dump();

}

// You can define other methods, fields, classes and namespaces here

//imagine this is a method in your BLL service class

public List<Albums> GetALLQ(int paramyear)
{
	var resultscq = from x in Albums
					where x.ReleaseYear == paramyear
					select x;
	return resultscq.ToList();
	
}

//Method

public List<Albums> GetALLQM(int paramyearM)
{
	var resultscqM = Albums
					.Where (x => x.ReleaseYear == paramyearM)
					.Select(x => x);
	return resultscqM.ToList();

}

