﻿using WebAPI_NationalPark_1035.Models;

namespace WebAPI_NationalPark_1035.Repository.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark>GetNationalParks();
        NationalPark GetNationalPark(int nationalParkId);
        bool NationalParkExists(int nationalParkId);
        bool NationalParkExists(string nationalParkName);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();
        bool CreateNatioanlPark(NationalPark nationalPark);
    }
}
 