using System;
using System.Collections.Generic;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Interfaces;

namespace TournMan.Services
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository tournamentRepository;

        public TournamentService() { }

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public int Save(Tournament tournament)
        {
            if (IsValid(tournament))
            {
                return tournamentRepository.Save(tournament);
            }
            return 0;
        }

        private static bool IsValid(Tournament tournament)
        {
            return !(tournament.StartDate < DateTime.Now | string.IsNullOrEmpty(tournament.Name) | string.IsNullOrEmpty(tournament.Location));
        }

        public List<Tournament> FindAll()
        {
            return tournamentRepository.FindAll();
        }

        public List<Tournament> FindByDate(DateTime startDate)
        {
            return tournamentRepository.FindByDate(startDate);
        }

        public List<Tournament> FindByName(string name)
        {
            return tournamentRepository.FindByName(name);
        }

        public List<Tournament> FindByLocation(string location)
        {
            return tournamentRepository.FindByLocation(location);
        }

        public List<Tournament> FindById(int tournamentId)
        {
            return tournamentRepository.FindById(tournamentId);
        }
    }
}