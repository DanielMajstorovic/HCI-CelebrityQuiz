using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrityQuiz.Model
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public GameMode Mode { get; set; }
    }

    public enum GameMode
    {
        Standard,
        Timed
    }
}
