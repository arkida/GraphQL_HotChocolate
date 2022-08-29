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

        public async Task<SwapiPerson> Add(SwapiPerson person)
        {
            await _db.SwapiPerson.AddAsync(person);
            await _db.SaveChangesAsync();
            return person;
        }

        //public async Task<People> GetAll()
        //{
        //    //return await _db.People.ToListAsync();
        //}

        public People? List()
        {
            var client = new RestClient("https://swapi.dev/api/people/");
            var request = new RestRequest();
            var response = client.Execute(request);


            try
            {
                return JsonConvert.DeserializeObject<People?>(response.Content);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

            public async Task<SwapiPerson> GetByID(int id)
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

        public int Count()
        {
            return _db.SwapiPerson.Count();
        }

        public async Task<SwapiPerson> Update(SwapiPerson person)
        {
            //_db.Entry(person).State = EntityState.Modified;
            var result = await _db.SwapiPerson.FirstOrDefaultAsync(p => p.Id == person.Id);
            result.Name = person.Name;
            result.Mass = person.Mass;
            //result.Edited = person.Edited;
            //result.BirthYear = person.BirthYear;
            //result.Url = person.Url;
            //result.EyeColor = person.EyeColor;
            //result.Height = person.Height;
            //result.HomeworId = person.HomeworId;
            //result.HairColor = person.HairColor;
            result.Vehicles = person.Vehicles;
            //result.Created = person.Created;
            result.Films = person.Films;
            result.Gender = person.Gender;
            //result.SkinColor = person.SkinColor;
            await _db.SaveChangesAsync();
            return result;
        }

    }
}
