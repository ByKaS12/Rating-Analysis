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
        public void AddTournament(Tournament tournament)
        {
            var obj = db.Tournaments.FirstOrDefault(x=>x.Name == tournament.Name);
            if (obj == null)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
            }else
            {
                obj.Games = tournament.Games;
                db.Tournaments.Update(obj);
                db.SaveChanges();
            }
 //           db.SaveChanges();
        }
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
