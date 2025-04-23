using WebAPI_NationalPark_1035.Models;

namespace WebAPI_NationalPark_1035.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trail>GetTrails();
        ICollection<Trail> GetTrailsInNationalPark(int nationalParkId);
        Trail GetTrail(int trailId);
        bool TrailExists(int trailId);
        bool TrailExists(string trailName);
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);
        bool DeleteTrail(Trail trailId);
        bool Save();
         
    }
}
 