﻿using Microsoft.EntityFrameworkCore;
using RacersCommunity.Data;
using RacersCommunity.Interfaces;
using RacersCommunity.Models;

namespace RacersCommunity.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDBContext _context;

        public LocationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByZipCode(int zipCode)
        {
            return await _context.City.FirstOrDefaultAsync(x => x.Zip == zipCode);
        }
        public async Task<List<City>> GetLocationSearch(string location)
        {
            List<City> result;
            if (location.Length > 0 && char.IsDigit(location[0]))
            {
                return await _context.City.Where(x => x.Zip.ToString().StartsWith(location)).Take(4).Distinct().ToListAsync();
            }
            else if (location.Length > 0)
            {
                result = await _context.City.Where(x => x.CityName == location).Take(10).ToListAsync();
            }
            result = await _context.City.Where(x => x.StateCode == location).Take(10).ToListAsync();

            return result;
        }
    }
}
