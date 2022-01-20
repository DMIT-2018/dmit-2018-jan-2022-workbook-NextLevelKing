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
	//Nested queries
	//sometimes referred to as subqueries

	//simply put, it is a query within a query [...]

	//Examples

	//Question

	//List all sales support employees showing their
	//full name (last, first), title, phone.
	//For each employee, show a list of the customers
	//they support. List the customer fullname(Last, first),
	//City and State.


	//Solution
	//take for example for sample data

	//Smith, Bob Sales Support 7801236542 // this is employee
	//        Kan, Jerry Edmonton Ab  	// this is customer
	//		  Ujest, Shirley Edmonton Ab  	// this is customer
	//		  Stewant, Ian Edmonton Ab  	// this is customer
	//		  Behold, Lowan Edmonton Ab  	// this is customer


	//Kake, Patty Sales Support  Supervisor 7801236542 // this is employee
	//        Kan, Jerry Edmonton Ab  	// this is customer
	//		  Ujest, Shirley Edmonton Ab  	// this is customer
	//		  Stewant, Ian Edmonton Ab  	// this is customer
	//		  Behold, Lowan Edmonton Ab  	// this is customer


	//Jones, Mike Sales Support 7801236542 // this is employee
	//        Kan, Jerry Edmonton Ab  	// this is customer
	//		  Ujest, Shirley Edmonton Ab  	// this is customer
	//		  Stewant, Ian Edmonton Ab  	// this is customer
	//		  Behold, Lowan Edmonton Ab  	// this is customer

	//The problem is that there appears to be 2 separate lists that need to be 
	//within one final dataset collection
	//one for employees
	//one for customers
	//Conern here: the list are intermixed!!!
	
	// Let us think of it from a C# point of view in a class definition
	//Recall Composite classes have single occuring fields AND uses other classess
	//the other class maybe a single instance OR List<T>
	//List<T> is a collection with a defined datatype of <T>
	//Classname
	//		property
	//		property
	//		...
	//		collection<T> (set of records)
	
	var results = Employees
					.Where(e => e.Title.Contains("Sales Support"))
					.Select(e => new
					{
						FullName = e.LastName + "," + e.FirstName,
						Title = e.Title,
						Phone = e.Phone,
						results = Customers
									.Where(c => c.SupportRepId == e.EmployeeId)
									.Select(c => new
									{
										FullName = c.LastName + "," + c.FirstName,
										City= c.City,
										State = c.State,
										repname = c.SupportRep.LastName

									})

						});
	
					results.Dump();

	//OR

	var results = Employees
					.Where(e => e.Title.Contains("Sales Support"))
					.Select(e => new
					{
						FullName = e.LastName + "," + e.FirstName,
						Title = e.Title,
						Phone = e.Phone,
						results = e.SupportRepCustomers
									//.Where(c => c.SupportRepId == e.EmployeeId)
									.Select(c => new
									{
										FullName = c.LastName + "," + c.FirstName,
										City = c.City,
										State = c.State,

									})

					});

	results.Dump();

	var results = Employees
				.Where(e => e.Title.Contains("Sales Support"))
				.Select(e => new 
				{
					FullName = e.LastName + "," + e.FirstName,
					Title = e.Title,
					Phone = e.Phone,
					CustomerList = e.SupportRepCustomers
								//.Where(c => c.SupportRepId == e.EmployeeId)
								.Select(c => new CustomerItem
								{
									FullName = c.LastName + "," + c.FirstName,
									City = c.City,
									State = c.State,

								})

				});

	results.Dump();

	// Re-code this without anonymous set. Strongly type the solution.


}

public class EmployeeItem
{
	public string FullName { get; set; }
	public string Title { get; set; }
	public string Phone { get; set; }
	//how to declare the nested query definition
	//remember the results of a nested query is a collection
	public IEnumerable<CustomerItem>CustomerList{get; set;}
	
	
}
public class CustomerItem
{
	public string FullName { get; set; }
	public string City { get; set; }
	public string State { get; set; }
}


	

// You can define other methods, fields, classes and namespaces here