using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotNet7.Services.SuperHeroService;

namespace SuperHeroAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = _superHeroService.GetAllHeroes();
            if (result is null)
                return NotFound("Heroes not found!");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found!");

            return Ok(result);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> AddHero(string name, string firstName, string lastName, string place)
        {
            var hero = new SuperHero();
            hero.Name = name;
            hero.FirstName = firstName;
            hero.LastName = lastName;
            hero.Place = place;
            superHeroes.Add(hero);
            return Ok("Hero is Added");
        }
        */

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found!");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found!");

            return Ok(result);
        }

    }
}
