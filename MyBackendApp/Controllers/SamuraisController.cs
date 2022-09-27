﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DAL;
using MyBackendApp.Models;

namespace MyBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurai;
        public SamuraisController(ISamurai samurai)
        {
            _samurai = samurai;
        }

        [HttpGet]
        public IEnumerable<Samurai> Get()
        {
            var results = _samurai.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public Samurai Get(int id)
        {
            return _samurai.GetById(id);
        }
    }
}
