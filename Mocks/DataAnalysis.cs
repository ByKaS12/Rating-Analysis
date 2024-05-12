using DiplomMag.models;


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
        public DataAnalysis(Game game,Player player)
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
            CalctmAST = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Assists);
            CalctmFG = Game.Players.FindAll(x => x.TeamId == Player.TeamId).Average(x => x.Statistic.Shoots.FieldGoalsScoredPoints);
        }


        public double CalcFactor() => 2 / 3 - ((0.5*CalclgAST/CalclgFG)/(2*CalclgFG/CalclgFT));
        public double CalcVOP() => (CalclgPTS/(CalclgFGA-CalclgORB+CalclgTO+0.44*CalclgFT));
        public double CalcDRBP() => (CalclgTRB-CalclgORB)/(CalclgTRB);
        public double CalcUPer()
        {
            var MP = 1 / (Player.Statistic.TimePlayed.Minute + Player.Statistic.TimePlayed.Second / 60);
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
                (_3P - (PF*CalclgFT/CalclgPF)+(FT/2*(2-(CalctmAST/(3*CalctmFG))))+(FG*(2-(CalcFactor()*CalctmAST/CalctmFG)))
                +(2*AST/3)+CalcVOP()*(CalcDRBP()*(2*ORB+BLK-0.2464*(FTA-FT)-(FGA-FG)-TRB)+((0.44*CalclgFTA*PF)/CalclgPF)-(TO+ORB)+STL+TRB-0.1936*(FTA-FT)));
            return uPER;
        }
        public double CalcPOSS()
        {
            //TODO
            return 0;
        }
        
 
        public double CalcHollinger()
        {

            return 0;
        }

    }
}
