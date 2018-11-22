﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan.Controllers {
    [Route ("api/[controller]")]
    public class TournamentController : Controller {
        private ITournamentService service;

        public TournamentController (ITournamentService service) {
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Tournament> Get () {
            // var service = new TournamentService (new TournamentRepository ());
            return this.service.FindAll ();
        }

        // GET api/values/5
        [HttpGet ("find/by/name/{name}")]
        public IEnumerable<Tournament> FindByName (string name) {

            // var service = new TournamentService (new TournamentRepository ());
            return this.service.FindByName (name);
        }

        [HttpGet ("find/by/id/{id}")]
        public IEnumerable<Tournament> FindById (int id) {
            // var service = new TournamentService (new TournamentRepository ());
            return this.service.FindById (id);
        }

        [HttpPost ("find/by/location")]
        public IEnumerable<Tournament> FindByLocation ([FromBody] string location) {
            // var service = new TournamentService (new TournamentRepository ());
            return this.service.FindByLocation (location);
        }

        [HttpGet ("{year}/{month}/{day}")]
        public List<Tournament> Get (int year, int month, int day) {
            var date = new DateTime (year, month, day);
            // var service = new TournamentService (new TournamentRepository ());
            return this.service.FindByDate (date);
        }

        [HttpPost]
        public void Post ([FromBody] Tournament tournament) {
            // var service = new TournamentService (new TournamentRepository ());
            this.service.Save (tournament);
        }

        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}