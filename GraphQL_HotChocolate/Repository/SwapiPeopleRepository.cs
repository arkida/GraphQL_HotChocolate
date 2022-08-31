using Microsoft.EntityFrameworkCore;
using System;
using GraphQL_HotChocolate.DAL;
using GraphQL_HotChocolate.Model;
using Newtonsoft.Json;
using static HotChocolate.ErrorCodes;
using RestSharp;

namespace GraphQL_HotChocolate.Repository
{
    public class SwapiPeopleRepository : ISwapiPeopleRepository
    {
        private readonly DatabaseContext _db;

        public SwapiPeopleRepository(IDbContextFactory<DatabaseContext> db)
        {
            _db = db.CreateDbContext();
        }

        public async Task<List<SwapiPeople>> GetSwapiPeople()
        {
            return await _db.SwapiPeople.ToListAsync();

        }

        public async Task<SwapiPerson> GetSwapiPersonByID(int id)
        {
            return await _db.SwapiPerson.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DoesExist(int id)
        {
            bool isexist = false;
            var result = await _db.SwapiPerson.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                isexist = true;
            }
            return isexist;
        }

        public async Task<SwapiPerson> Add(SwapiPerson person)
        {
            _db.SwapiPerson.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<SwapiPerson> Update(SwapiPerson person)
        {
            var result = await _db.SwapiPerson.FirstOrDefaultAsync(p => p.Id == person.Id);
            result.Name = person.Name;
            result.Mass = person.Mass;
            result.BirthYear = person.BirthYear;           
            result.Height = person.Height;
            result.EyeColor = person.EyeColor;
            result.SkinColor = person.SkinColor;
            result.HairColor = person.HairColor;
            result.Gender = person.Gender;
            result.HomeworId = person.HomeworId;           
            result.Vehicles = person.Vehicles;
            result.Films = person.Films;
            result.Edited = person.Edited;
            result.Url = person.Url;
            await _db.SaveChangesAsync();
            return result;
        }

    }
}
