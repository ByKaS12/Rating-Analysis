using DiplomMag.models;
using DiplomMag.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomMag.Mocks
{
    public class CRUD
    {
        public ApplicationContext db;

        public CRUD(ref ApplicationContext context)
        {
            db = context;
        }
        public void AddPlayer(Player player) {

            db.Players.Add(player);
            db.SaveChanges();
        }
        public void AddGame(Game game)
        {

            db.Games.Add(game);
            db.SaveChanges();
        }
        public void AddStatistic(Statistic stat)
        {

            db.Statistics.Add(stat);
            db.SaveChanges();
        }
        public void AddShoot(Shoot shoot)
        {

            db.Shoots.Add(shoot);
            db.SaveChanges();
        }
        public void AddRebound(Rebound reb)
        {

            db.Rebounds.Add(reb);
            db.SaveChanges();
        }
        public void AddTeams(List<Team> teams)
        {

            db.Teams.AddRange(teams);
            db.SaveChanges();
        }
        public Tournament? GetTournamentName(string Name)=> db.Tournaments.FirstOrDefault(x => x.Name == Name);
        public Game? GetGameDate(string GameDate,Tournament tournament)=> db.Games.FirstOrDefault(x => x.GameDate == GameDate || x.Tournament == tournament);
        public void UpdateStatistic(Statistic statistic)
        {
            db.Statistics.Update(statistic);
            db.SaveChanges();
        }
        public Player? GetPlayer(string name, string surname) => db.Players.Include(x=>x.Statistic).ToList().FirstOrDefault(x => x.Name == name || x.Surname == surname);
        public List<Player> GetPlayersGame(Game game) => db.Players.Include(x=>x.Statistic).ToList().FindAll(x=>x.Game == game);
        public Statistic GetStatistic(Player player) => db.Statistics.FirstOrDefault(x => x.Player == player);
        public Guid AddTournament(Tournament tournament)
        {

            Tournament? obj = db.Tournaments.ToList().Find(x => x.Name == tournament.Name);
            if (obj == null)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return Guid.Empty;
            }
            else if(obj.Games.Count > 0)
            {
                return obj.Games[0].Id;

            } else 
                return Guid.Empty;
        }
        //       public Guid AddTournament(Tournament tournament,List<Team> teams)
        //       {
        //           Tournament? obj = db.Tournaments.ToList().Find(x => x.Name == tournament.Name);
        //           if (obj == null)
        //           {
        //               db.Tournaments.Add(tournament);
        //               db.SaveChanges();
        //               return Guid.Empty;
        //           }else
        //           {
        //               var gameFind = obj.Games.Find(x => x.GameDate == tournament.Games[0].GameDate);

        //			if (gameFind!=null) return gameFind.Id;
        //               var game = tournament.Games[0];
        //               game.Tournament = obj;
        //               game.TournamentId = obj.Id;
        //               obj.Games.Add(game);
        //               db.Tournaments.Update(obj);
        //               db.Games.Add(game);
        //               db.Players.AddRange(game.Players);
        //			//db.Teams.AddRange(teams);
        //               db.SaveChanges();
        //               return Guid.Empty;
        //           }
        ////           db.SaveChanges();
        //       }
        public List<Player> ViewGame(Guid gameId) => db.Players.ToList().FindAll(x=>x.GameId == gameId);
        

        //public void AddTeams(List<Team> teams)
        //{
        //    foreach (var team in teams)
        //    {
        //        var obj = db.Teams.FirstOrDefault(x => x.Id == team.Id);
        //        if (obj != null)
        //        {
        //            db.Teams.Add(team);
        //        }
        //    }
            

        //    db.SaveChanges();
        //}
    }
}
