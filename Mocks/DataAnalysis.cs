using DiplomMag.models;
using DiplomMag.Models;


namespace DiplomMag.Mocks
{
    public class DataAnalysis
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public double CalclgAST { get; set; }
        public double CalclgFG { get; set; }
        public double CalclgFGA { get; set; }
        public double CalclgFT { get; set; }
        public double CalclgFTA { get; set; }
        public double CalclgPTS { get; set; }
        public double CalclgORB { get; set; }
        public double CalclgTO { get; set; }
        public double CalclgTRB { get; set; }
        public double CalclgPF { get; set; }
        public double CalctmAST { get; set; }
        public double CalctmFG { get; set; }
        public double CalctmFGA { get; set; }
        public double CalctmFTA { get; set; }
        public double CalctmORB { get; set; }
        public double CalcOppDRB { get; set; }
        public double CalctmTOV { get; set; }
        public double CalctmDRB { get; set; }
        public double CalcOppFGA { get; set; }
        public double CalcOppFG { get; set; }
        public double CalcOppFTA { get; set; }
        public double CalcOppORB { get; set; }
        public double CalcOppTOV { get; set; }
        public double CalctmMP { get; set; }
        public double CalctmPace { get; set; }
        public double CalclgPace { get; set; }
        public double CalclgUPer { get; set; }
        public DataAnalysis(Game game, Player player)
        {
            Game = game;
            if (Game.Players.FirstOrDefault(x => x.Id == player.Id) == null) return;
            Player = player;
            CalclgAST = Game.Players.Average(x => x.Statistic.Assists);
            CalclgFGA = Game.Players.Average(x => x.Statistic.Shoots.FieldGoalsAllPoints);
            CalclgFTA = Game.Players.Average(x => x.Statistic.Shoots.FreeThrowsAllPoints);
            CalclgFG = Game.Players.Average(x => x.Statistic.Shoots.FieldGoalsScoredPoints);
            CalclgFT = Game.Players.Average(x => x.Statistic.Shoots.FreeThrowsScoredPoints);
            CalclgPTS = Game.Players.Average(x => x.Statistic.Points);
            CalclgORB = Game.Players.Average(x => x.Statistic.Rebounds.RebOfAlien);
            CalclgTO = Game.Players.Average(x => x.Statistic.Losses);
            CalclgTRB = Game.Players.Average(x => x.Statistic.Rebounds.AllReb);
            CalclgPF = Game.Players.Average(x => x.Statistic.Fouls);
            CalclgPace = Game.Players.Average(x => x.Statistic.CalcPace);
            CalclgUPer = Game.Players.Average(x => x.Statistic.CalcUPer);
            CalctmAST = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Assists);
            CalctmFG = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Shoots.FieldGoalsScoredPoints);
            CalctmFGA = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Shoots.FieldGoalsAllPoints);
            CalctmFTA = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Shoots.FreeThrowsAllPoints);
            CalctmORB = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Rebounds.RebOfAlien);
            CalcOppDRB = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Rebounds.RebOfOwn);
            CalcOppFGA = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Shoots.FieldGoalsAllPoints);
            CalcOppFG = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Shoots.FieldGoalsScoredPoints);
            CalcOppFTA = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Shoots.FreeThrowsAllPoints);
            CalcOppORB = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Rebounds.RebOfAlien);
            CalcOppTOV = Game.Players.FindAll(x => x.TeamId != Player.TeamId).Average(x => x.Statistic.Losses);
            CalctmTOV = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Losses);
            CalctmDRB = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Rebounds.RebOfOwn);
            CalctmMP = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => (x.Statistic.TimePlayed.Minute + x.Statistic.TimePlayed.Second / 60));
            CalctmMP = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => (x.Statistic.TimePlayed.Minute + x.Statistic.TimePlayed.Second / 60));
            CalctmPace = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.CalcPace);

        }


        public double CalcFactor() => (double)(2.0 / 3.0) - ((0.5 * CalclgAST / CalclgFG) / (2.0 * CalclgFG / CalclgFT));
        public double CalcVOP() => (CalclgPTS / (CalclgFGA - CalclgORB + CalclgTO + 0.44 * CalclgFT));
        public double CalcDRBP() => (CalclgTRB - CalclgORB) / (CalclgTRB);
        public double CalcUPer()
        {
            double MP = ((Player.Statistic.TimePlayed.Minute*60.0) + Player.Statistic.TimePlayed.Second )/ 60.0;
            if (MP >= 0)
                MP = Math.Pow(((Player.Statistic.TimePlayed.Minute * 60.0) + Player.Statistic.TimePlayed.Second) / 60.0, -1);
            else
                MP = 0;
            MP = MP == double.PositiveInfinity ? 0 : MP;    
            var _3P = Player.Statistic.Shoots.ThreePointScoredPoints;
            var PF = Player.Statistic.Fouls;
            var FT = Player.Statistic.Shoots.FreeThrowsScoredPoints;
            var FTA = Player.Statistic.Shoots.FreeThrowsAllPoints;
            var FG = Player.Statistic.Shoots.FieldGoalsScoredPoints;
            var FGA = Player.Statistic.Shoots.FieldGoalsAllPoints;
            var AST = Player.Statistic.Assists;
            var ORB = Player.Statistic.Rebounds.RebOfAlien;
            var BLK = Player.Statistic.Blockshots;
            var TRB = Player.Statistic.Rebounds.AllReb;
            var TO = Player.Statistic.Losses;
            var STL = Player.Statistic.Steals;

            var uPER = MP *
                (_3P - (PF * CalclgFT / CalclgPF) + (FT / 2.0 * (2 - (CalctmAST / (3.0 * CalctmFG)))) + (FG * (2 - (CalcFactor() * CalctmAST / CalctmFG)))
                + (2.0 * AST / 3.0) + CalcVOP() * (CalcDRBP() * (2.0 * ORB + BLK - 0.2464 * (FTA - FT) - (FGA - FG) - TRB) + ((0.44 * CalclgFTA * PF) / CalclgPF) - (TO + ORB) + STL + TRB - 0.1936 * (FTA - FT)));
            return uPER;
        }
        public double CalctmPOSS() => 0.5 * ((CalctmFGA + 0.4 * CalctmFTA - 1.07 * (CalctmORB / (CalctmORB + CalcOppDRB)) *
            (CalctmFGA - CalctmFG) + CalctmTOV) + (CalcOppFGA + 0.4 * CalcOppFTA - 1.07 * (CalcOppORB / (CalcOppORB + CalctmDRB)) *
            (CalcOppFGA - CalcOppFG) + CalcOppTOV));
        public double CalcOppPOSS() => 0.5 * ((CalcOppFGA + 0.4 * CalcOppFTA - 1.07 * (CalcOppORB / (CalcOppORB + CalctmDRB)) *
    (CalcOppFGA - CalcOppFG) + CalcOppTOV) + (CalctmFGA + 0.4 * CalctmFTA - 1.07 * (CalctmORB / (CalctmORB + CalcOppDRB)) *
    (CalcOppFGA - CalcOppFG) + CalcOppTOV));

        public double CalcPace() => 40.0 * ((CalctmPOSS() + CalcOppPOSS()) / (2.0 * (CalctmMP / 5.0)));
        // 
        public double CalcHollinger() => 0.8*(CalcUPer() * (CalclgPace / CalctmPace)*15.0/CalclgUPer);
        public double CalcTPA() => Player.Statistic.PlusMinus*Player.Statistic.CalcPace*(Player.Statistic.TimePlayed.Minute+ Player.Statistic.TimePlayed.Second/60.0);
        public double CalcOffRating() => Game.Players.FindAll(x => x.TeamId == Player.TeamId).Sum(x => x.Statistic.Points)*100/CalctmPOSS();
        public double CalcDefRating() => Game.Players.FindAll(x => x.TeamId != Player.TeamId).Sum(x => x.Statistic.Points) * 100 / CalctmPOSS();
        public double CalcEFGProcent() => (Player.Statistic.Shoots.FieldGoalsScoredPoints+ 0.5*Player.Statistic.Shoots.ThreePointScoredPoints)/Player.Statistic.Shoots.FieldGoalsAllPoints;
        public double CalcTSProcent() => Player.Statistic.Points/(2*(Player.Statistic.Shoots.FieldGoalsAllPoints+(0.44* Player.Statistic.Shoots.FreeThrowsAllPoints)));


	}
}
