using DiplomMag.models;
using DiplomMag.Models;

namespace DiplomMag.Mocks
{
    public class CRUD
    {
        public ApplicationContext db;

        public CRUD(ApplicationContext context)
        {
            db = context;
        }
        public Guid AddTournament(Tournament tournament)
        {
            Tournament? obj = db.Tournaments.ToList().Find(x => x.Name == tournament.Name);
            if (obj == null)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return Guid.Empty;
            }else
            {
                var gameFind = obj.Games.Find(x => x.GameDate == tournament.Games[0].GameDate);

				if (gameFind!=null) return gameFind.Id;
                var game = tournament.Games[0];
                game.Tournament = obj;
                game.TournamentId = obj.Id;
                obj.Games.Add(game);
                db.Tournaments.Update(obj);
                db.Games.Add(game);
                db.SaveChanges();
                return Guid.Empty;
            }
 //           db.SaveChanges();
        }
        public List<Player> ViewGame(Guid gameId) => db.Players.ToList().FindAll(x=>x.GameId == gameId);

        public void AddTeams(List<Team> teams)
        {
            foreach (var team in teams)
            {
                var obj = db.Teams.FirstOrDefault(x => x.Id == team.Id);
                if (obj != null)
                {
                    db.Teams.Add(team);
                }
            }
            

            db.SaveChanges();
        }
    }
}
