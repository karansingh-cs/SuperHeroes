using System;

namespace SuperHeroAPIDotNet7.Services.SuperHeroService
{
	public class SuperHeroService : ISuperHeroService
	{
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New york"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Iron man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            }
        };

        public SuperHeroService()
		{
		}

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null; // NotFound("hero does not exist!");
            }
            superHeroes.Remove(hero);
            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return superHeroes;
        }
    }
}

