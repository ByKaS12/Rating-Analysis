using DiplomMag.models;
using DiplomMag.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DiplomMag.Mocks
{
    public class GetData
    {
        public string Url { get; set; }
        public Tournament Tournament { get; set; }
        public string GameDate { get; set; }
        public List<Team> teams { get; set; }
        public GetData(string url)
        {
            Url = url;
        }
        public ChromeDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            return driver;
        }
        public void WebSrap(CRUD db)
        {

            var driver = GetDriver();
            var nodesTeamA = driver.FindElements(By.XPath("/html/body/main/div/game-widget/div/div[3]/div[1]/div[2]/div/table/tbody/tr[position()>=1]"));
            var nodesTeamB = driver.FindElements(By.XPath("/html/body/main/div/game-widget/div/div[3]/div[2]/div[2]/div/table/tbody/tr[position()>=1]"));
            var nodesNameTeams = driver.FindElements(By.XPath("html/body/main/div/game-widget/div/div[1]/div/div/div/div[2]"));
            var nodesNameTournament = driver.FindElements(By.XPath("html/body/main/div/game-widget/div/div[1]/div/div/div/div[1]"));
            Tournament = new Tournament();
			Tournament.Name = nodesNameTournament[0].FindElements(By.XPath("div[2]"))[0].Text.Split(",")[0];
            db.AddTournament(Tournament);
            Game game = new Game();
            game.Tournament = Tournament;
            game.GameDate = nodesNameTournament[0].FindElements(By.XPath("div[1]"))[0].Text.Split(",")[0];
            db.AddGame(game);
            Team teamA = new Team();
            teamA.Name = nodesNameTeams[0].FindElements(By.XPath("div[1]"))[0].Text;
            Team teamB = new Team();
            teamB.Name = nodesNameTeams[0].FindElements(By.XPath("div[3]"))[0].Text;
            db.AddTeams(new List<Team> { teamA, teamB });

            List<Player> playersA = new List<Player>();
            for (int i = 0; i < nodesTeamA.Count - 1; i++)
            {
                var Name = nodesTeamA[i].FindElements(By.XPath("td[3]"))[0].Text.Split(" ");
                var Time = nodesTeamA[i].FindElements(By.XPath("td[4]"))[0].Text.Split(":");
                //var Points = nodesTeamA[i].FindElements(By.XPath("td[5]"))[0].Text;
                var TwoPoint = nodesTeamA[i].FindElements(By.XPath("td[6]"))[0].Text.Split("/");
                TwoPoint = TwoPoint[0] != "" ? TwoPoint : ["0", "0"];
                var ThreePoint = nodesTeamA[i].FindElements(By.XPath("td[7]"))[0].Text.Split("/");
                ThreePoint = ThreePoint[0] != "" ? ThreePoint : ["0", "0"];
                //var Shoots = nodesTeamA[i].FindElements(By.XPath("td[8]"))[0].Text.Split("/");
                var FreeThrows = nodesTeamA[i].FindElements(By.XPath("td[9]"))[0].Text.Split("/");
                FreeThrows = FreeThrows[0] != "" ? FreeThrows : ["0", "0"];
                var ReboundOur = nodesTeamA[i].FindElements(By.XPath("td[10]"))[0].Text;
                ReboundOur = ReboundOur != "" ? ReboundOur : "0";
                var ReboundEnemy = nodesTeamA[i].FindElements(By.XPath("td[11]"))[0].Text;
                ReboundEnemy = ReboundEnemy != "" ? ReboundEnemy : "0";
                //var ReboundAll = nodesTeamA[i].FindElements(By.XPath("td[12]"))[0].Text;
                var Assists = nodesTeamA[i].FindElements(By.XPath("td[13]"))[0].Text;
                Assists = Assists != "" ? Assists : "0";
                var Steals = nodesTeamA[i].FindElements(By.XPath("td[14]"))[0].Text;
                Steals = Steals != "" ? Steals : "0";
                var Losses = nodesTeamA[i].FindElements(By.XPath("td[15]"))[0].Text;
                Losses = Losses != "" ? Losses : "0";
                var Blockshots = nodesTeamA[i].FindElements(By.XPath("td[16]"))[0].Text;
                Blockshots = Blockshots != "" ? Blockshots : "0";
                var Fouls = nodesTeamA[i].FindElements(By.XPath("td[17]"))[0].Text;
                Fouls = Fouls != "" ? Fouls : "0";
                var FoulsEnemy = nodesTeamA[i].FindElements(By.XPath("td[18]"))[0].Text;
                FoulsEnemy = FoulsEnemy != "" ? FoulsEnemy : "0";
                var PlusMinus = nodesTeamA[i].FindElements(By.XPath("td[19]"))[0].Text;
                PlusMinus = PlusMinus != "" ? PlusMinus : "0";
                var KPI = nodesTeamA[i].FindElements(By.XPath("td[20]"))[0].Text;
                KPI = KPI != "" ? KPI : "0";
                Player player = new Player();
                player.Name = Name[1];
                player.Surname = Name[0];
                player.Game = game;
                player.Team = teamA;
                db.AddPlayer(player);
                Statistic statistic = new Statistic()
                {
                    
                    Player = player,
                    TimePlayed = new TimeOnly(0, Convert.ToInt32(Time[0]), Convert.ToInt32(Time[1])),
                    Assists = Convert.ToInt32(Assists),
                    Steals = Convert.ToInt32(Steals),
                    Losses = Convert.ToInt32(Losses),
                    Blockshots = Convert.ToInt32(Blockshots),
                    Fouls = Convert.ToInt32(Fouls),
                    FoulsOfEnemy = Convert.ToInt32(FoulsEnemy),
                    PlusMinus = Convert.ToInt32(PlusMinus),
                    KPI = Convert.ToInt32(KPI),



                };
                db.AddStatistic(statistic);
                Shoot shoots = new Shoot()
                {
                    Statistic = statistic,
                    StatisticId = statistic.Id,
                    TwoPointScoredPoints = Convert.ToInt32(TwoPoint[0]),
                    TwoPointAllPoints = Convert.ToInt32(TwoPoint[1]),
                    ThreePointScoredPoints = Convert.ToInt32(ThreePoint[0]),
                    ThreePointAllPoints = Convert.ToInt32(ThreePoint[1]),
                    FreeThrowsScoredPoints = Convert.ToInt32(FreeThrows[0]),
                    FreeThrowsAllPoints = Convert.ToInt32(FreeThrows[1])
                };
                db.AddShoot(shoots);
                var rebs = new Rebound()
                {
					Statistic = statistic,
					StatisticId = statistic.Id,
					RebOfAlien = Convert.ToInt32(ReboundEnemy),
                    RebOfOwn = Convert.ToInt32(ReboundOur)
                };
                db.AddRebound(rebs);
                statistic.Shoots = shoots;
                statistic.Rebounds = rebs;

               player.Statistic = statistic;
                playersA.Add(player);

            }
            //game.Players.AddRange(playersA);
            teamA.Players.AddRange(playersA);
            List<Player> playersB = new List<Player>();
            for (int i = 0; i < nodesTeamB.Count - 1; i++)
            {
                var Name = nodesTeamB[i].FindElements(By.XPath("td[3]"))[0].Text.Split(" ");
                var Time = nodesTeamB[i].FindElements(By.XPath("td[4]"))[0].Text.Split(":");
                var Points = nodesTeamB[i].FindElements(By.XPath("td[5]"))[0].Text;
                var TwoPoint = nodesTeamB[i].FindElements(By.XPath("td[6]"))[0].Text.Split("/");
                TwoPoint = TwoPoint[0] != "" ? TwoPoint : ["0", "0"];
                var ThreePoint = nodesTeamB[i].FindElements(By.XPath("td[7]"))[0].Text.Split("/");
                ThreePoint = ThreePoint[0] != "" ? ThreePoint : ["0", "0"];
                var Shoots = nodesTeamB[i].FindElements(By.XPath("td[8]"))[0].Text.Split("/");
                var FreeThrows = nodesTeamB[i].FindElements(By.XPath("td[9]"))[0].Text.Split("/");
                FreeThrows = FreeThrows[0] != "" ? FreeThrows : ["0", "0"];
                var ReboundOur = nodesTeamB[i].FindElements(By.XPath("td[10]"))[0].Text;
                ReboundOur = ReboundOur != "" ? ReboundOur : "0";
                var ReboundEnemy = nodesTeamB[i].FindElements(By.XPath("td[11]"))[0].Text;
                ReboundEnemy = ReboundEnemy != "" ? ReboundEnemy : "0";
                var ReboundAll = nodesTeamB[i].FindElements(By.XPath("td[12]"))[0].Text;
                var Assists = nodesTeamB[i].FindElements(By.XPath("td[13]"))[0].Text;
                Assists = Assists != "" ? Assists : "0";
                var Steals = nodesTeamB[i].FindElements(By.XPath("td[14]"))[0].Text;
                Steals = Steals != "" ? Steals : "0";
                var Losses = nodesTeamB[i].FindElements(By.XPath("td[15]"))[0].Text;
                Losses = Losses != "" ? Losses : "0";
                var Blockshots = nodesTeamB[i].FindElements(By.XPath("td[16]"))[0].Text;
                Blockshots = Blockshots != "" ? Blockshots : "0";
                var Fouls = nodesTeamB[i].FindElements(By.XPath("td[17]"))[0].Text;
                Fouls = Fouls != "" ? Fouls : "0";
                var FoulsEnemy = nodesTeamB[i].FindElements(By.XPath("td[18]"))[0].Text;
                FoulsEnemy = FoulsEnemy != "" ? FoulsEnemy : "0";
                var PlusMinus = nodesTeamB[i].FindElements(By.XPath("td[19]"))[0].Text;
                PlusMinus = PlusMinus != "" ? PlusMinus : "0";
                var KPI = nodesTeamB[i].FindElements(By.XPath("td[20]"))[0].Text;
                KPI = KPI != "" ? KPI : "0";
                Player player = new Player();
                player.Name = Name[0];
                player.Surname = Name[1];
                player.Game = game;
                player.Team = teamB;
                db.AddPlayer(player);
                Statistic statistic = new Statistic()
                {
                    Player = player,
                    TimePlayed = new TimeOnly(0, Convert.ToInt32(Time[0]), Convert.ToInt32(Time[1])),
                    Assists = Convert.ToInt32(Assists),
                    Steals = Convert.ToInt32(Steals),
                    Losses = Convert.ToInt32(Losses),
                    Blockshots = Convert.ToInt32(Blockshots),
                    Fouls = Convert.ToInt32(Fouls),
                    FoulsOfEnemy = Convert.ToInt32(FoulsEnemy),
                    PlusMinus = Convert.ToInt32(PlusMinus),
                    KPI = Convert.ToInt32(KPI),



                };
                db.AddStatistic(statistic);
                Shoot shoots = new Shoot()
                {
					Statistic = statistic,
					StatisticId = statistic.Id,
					TwoPointScoredPoints = Convert.ToInt32(TwoPoint[0]),
                    TwoPointAllPoints = Convert.ToInt32(TwoPoint[1]),
                    ThreePointScoredPoints = Convert.ToInt32(ThreePoint[0]),
                    ThreePointAllPoints = Convert.ToInt32(ThreePoint[1]),
                    FreeThrowsScoredPoints = Convert.ToInt32(FreeThrows[0]),
                    FreeThrowsAllPoints = Convert.ToInt32(FreeThrows[1])
                };
                db.AddShoot(shoots);
                var rebs = new Rebound()
                {
					Statistic = statistic,
					StatisticId = statistic.Id,
					RebOfAlien = Convert.ToInt32(ReboundEnemy),
                    RebOfOwn = Convert.ToInt32(ReboundOur)
                };
                db.AddRebound(rebs);
                statistic.Shoots = shoots;
                statistic.Rebounds = rebs;

                player.Statistic = statistic;
                playersB.Add(player);

            }
            //game.Players.AddRange(playersB);
            teamB.Players.AddRange(playersB);
            GameDate = game.GameDate;
            //Tournament.Games.Add(game);
            teams = [teamA, teamB];
            driver.Close();

        }
    }
}
