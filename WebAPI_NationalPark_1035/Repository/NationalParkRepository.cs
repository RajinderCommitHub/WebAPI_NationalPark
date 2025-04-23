﻿using Microsoft.EntityFrameworkCore;
using WebAPI_NationalPark_1035.Data;
using WebAPI_NationalPark_1035.Models;
using WebAPI_NationalPark_1035.Repository;
using WebAPI_NationalPark_1035.Repository.IRepository;

namespace WebAPI_NationalPark_1035.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly AppllicationDbContext _context;
        public NationalParkRepository(AppllicationDbContext context)
        {
            _context = context;     
        }

        public bool CreateNatioanlPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();

        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();

        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
           _context.NationalParks.Remove(nationalPark);
            return Save();

        }
        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.NationalParks.Find(nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.ToList();
        }

        public bool NationalParkExists(int nationalParkId)
        {
          return _context.NationalParks.Any(np=>np.Id == nationalParkId);
        }

        public bool NationalParkExists(string nationalParkName)
        {
           return _context.NationalParks.Any(np=>np.Name == nationalParkName);
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
        _context.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}


