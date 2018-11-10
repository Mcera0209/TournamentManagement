using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace TournMan.Tests.Services
{
    public class TournamentServiceTests
    {
        [Fact]
        public void Save_GivenNewTournament_ShouldSave () {
            //Given
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths (1), Location = "Mqanduli" };
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            //When
            tournamentService.Save (tournament);
            //Then
            tournamentRepository.Received (1).Save (tournament);
        }

        [Fact]
        public void Save_GivenTournamentDateIsInThePast_ShouldNotSave () {
            //Given
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths (-1), Location = "Mqanduli" };
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            //When
            tournamentService.Save (tournament);
            //Then
            tournamentRepository.DidNotReceive ().Save (tournament);
        }

        [Fact]
        public void Save_GivenNoTournamentName_ShouldNotSave () {
            //Given
            var tournament = new Tournament { Name = "", StartDate = DateTime.Now.AddMonths (1), Location = "Mqanduli" };
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            //When
            tournamentService.Save (tournament);
            //Then
            tournamentRepository.DidNotReceive ().Save (tournament);
        }

        [Fact]
        public void Save_GivenNoTournamentLocation_ShouldNotSave () {
            //Given
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths (1), Location = "" };
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            //When
            tournamentService.Save (tournament);
            //Then
            tournamentRepository.DidNotReceive ().Save (tournament);
        }

        [Fact]
        public void FindAll_GivenItemsExist_ShouldReturnAll () {
            //Given
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths (1), Location = "" };
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            var tournaments = new List<Tournament> () {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1"),
                new Tournament ("Tournament 2", DateTime.Now.AddMonths (2), "Location 2"),
                new Tournament ("Tournament 3", DateTime.Now.AddYears (2), "Location 3")
            };
            tournamentRepository.FindAll ().Returns (tournaments);
            //When
            var results = tournamentService.FindAll ();
            //Then
            results.Should().BeEquivalentTo(tournaments);
             
        }

        [Fact]
        public void Search_GivenExistingTournamentAndSearchByName_ShouldReturnTournament () {
            //Given
            var name = "Tournament 1";
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            var tournaments = new List<Tournament> () {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1")
            };
            tournamentRepository.FindByName (name).Returns (tournaments);
            //When
            var results = tournamentService.FindByName (name);
            //Then
            results.Should().BeEquivalentTo(tournaments);
             
        }

         [Fact]
        public void Search_GivenExistingTournamentAndSearchByLocation_ShouldReturnTournament () {
            //Given
            var Location = "Location 1";
            var tournamentRepository = Substitute.For<ITournamentRepository> ();
            var tournamentService = new TournamentService (tournamentRepository);
            var tournaments = new List<Tournament> () {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1")
            };
            tournamentRepository.FindByLocation (Location).Returns (tournaments);
            //When
            var results = tournamentService.FindByLocation (Location);
            //Then
            results.Should().BeEquivalentTo(tournaments);
             
        }
    }
}