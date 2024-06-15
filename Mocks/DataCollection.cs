using DiplomMag.models;

namespace DiplomMag.Mocks
{
    public static class DataCollection
    {
        public static Tournament DataCollect(Tournament tournament, Guid GameId) { 
            var data = tournament;
            if (data == null) return null;
            var game = data.Games.Find(x => x.Id == GameId);
            if (game == null) return null;
            var dataCollect = data.Games.Find(x => x == game).Players;
            foreach (var item in dataCollect)
            {
                var dataAnalysis = new DataAnalysis(game, item);
                item.Statistic.CalcUPer = double.IsNaN(dataAnalysis.CalcUPer()) || dataAnalysis.CalcUPer() < 0 ? 0 : dataAnalysis.CalcUPer();
            }
            foreach (var item in dataCollect)
            {
                var dataAnalysis = new DataAnalysis(game, item);
                item.Statistic.CalcPace = double.IsNaN(dataAnalysis.CalcPace()) ? 0 : dataAnalysis.CalcPace();
            }
            foreach (var item in dataCollect)
            {
                var dataAnalysis = new DataAnalysis(game, item);
                item.Statistic.CalcHollinger = double.IsNaN(dataAnalysis.CalcHollinger()) || dataAnalysis.CalcHollinger()<0 || item.Statistic.TimePlayed.Minute<10 ? 0 : dataAnalysis.CalcHollinger();
				item.Statistic.CalcTPA = double.IsNaN(dataAnalysis.CalcTPA()) ? 0 : dataAnalysis.CalcTPA()/1000.0;
				item.Statistic.CalcOffRating = double.IsNaN(dataAnalysis.CalcOffRating()) ? 0 : dataAnalysis.CalcOffRating()/1000.0;
				item.Statistic.CalcDefRating = double.IsNaN(dataAnalysis.CalcDefRating()) ? 0 : dataAnalysis.CalcDefRating()/1000.0;
				item.Statistic.CalcEFGProcent = double.IsNaN(dataAnalysis.CalcEFGProcent()) || double.IsInfinity(dataAnalysis.CalcEFGProcent()) ? 0 : dataAnalysis.CalcEFGProcent();
				item.Statistic.CalcTSProcent = double.IsNaN(dataAnalysis.CalcTSProcent()) || double.IsInfinity(dataAnalysis.CalcTSProcent()) ? 0 : dataAnalysis.CalcTSProcent();
			}

			return data;
        }
    }
}
