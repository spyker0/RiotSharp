﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static string name = ConfigurationManager.AppSettings["Summoner1Name"];
        private static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        private static string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
        private static string team = ConfigurationManager.AppSettings["Team1Id"];
        private static string team2 = ConfigurationManager.AppSettings["Team2Id"];
        private static RiotApi api = RiotApi.GetInstance(apiKey, false);

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var summoner = api.GetSummoner(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            var summoners = api.GetSummoners(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var summoner = api.GetSummoner(Region.euw, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            var summoners = api.GetSummoners(Region.euw, new List<string>() { name, name2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, new List<string>() { name, name2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var summoner = api.GetSummonerName(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var summoner = api.GetSummonerNameAsync(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            var summoners = api.GetSummonersNames(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            var summoners = api.GetSummonersNamesAsync(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(Region.euw);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(Region.euw);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var champion = api.GetChampion(Region.euw, 12);

            Assert.IsNotNull(champion);
            Assert.AreEqual<long>(champion.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champion = api.GetChampionAsync(Region.euw, 12);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual<long>(champion.Result.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(masteries);
            Assert.IsTrue(masteries.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(masteries.Result);
            Assert.IsTrue(masteries.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeaguesV24(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesV24Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesV24(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesV24Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetLeagues_ByTeam_Test()
        {
            var leagues = api.GetLeaguesV24(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetLeaguesV24Async(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetEntireLeagues_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesV24(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesV24Async(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeagueV24(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueV24Async(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetTeams_Summoners_Test()
        {
            var teams = api.GetTeamsV23(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetTeamsAsync_Summoners_Test()
        {
            var teams = api.GetTeamsV23Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetTeams_Test()
        {
            var teams = api.GetTeamsV23(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetTeamsAsync_Test()
        {
            var teams = api.GetTeamsV23Async(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }
    }
}
