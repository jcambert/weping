namespace WePing.Girpe.Clubs.Queries;

public interface IUpdateClubForJoueurQuery:IGirpeQuery<GetClubResponse>
{
    string Licence { get; set; }
}
