namespace GeneratorsData;


[Queryable]
public class Dto
{
    public string Identifiant { get; set; }


    public string Name { get; set; }
}
public class GetQuery
{
    public string Identifiant { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }
}


public class BrowseQuery
{
    public string Id { get; set; }
}