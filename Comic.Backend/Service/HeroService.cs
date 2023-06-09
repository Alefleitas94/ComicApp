﻿using Comic.Backend.Model;
using Comic.Backend.Model.Filter;
using Comic.Backend.Repository.Interface;
using Comic.Backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Comic.Backend.Service
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync(HeroFilter filter)
        {
            return await _heroRepository.GetAllAsync(filter);
        }

        public async Task<Hero> GetByIdAsync(HeroFilter filter)
        {
            return await _heroRepository.GetByIdAsync(filter);
        }

        public async Task<GenericResult> SaveCharacterAsync(Hero hero)
        {
            return await _heroRepository.SaveCharacterAsync(hero);

        }

        public async Task<GenericResult> DeleteCharacterAsync(int id)
        {
            return await _heroRepository.DeleteCharacterAsync(id);

        }
    }
}
