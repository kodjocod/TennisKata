
namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _mScore1;
        private int _mScore2;

        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _mScore1 += 1;
            else
                _mScore2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            // Egalité 
            if (_mScore1 == _mScore2)
            {
                if (_mScore1 == 0)
                {
                    score = "Love-All";
                }
                else if (_mScore1 == 1)
                {
                    score = "Fifteen-All";
                }
                else if (_mScore1 == 2)
                    score = "Thirty-All";
                else
                    score = "Deuce";
            }
            // AVantage + Gagnant 
            else if (_mScore1 >= 4 || _mScore2 >= 4)
            {
                var minusResult = _mScore1 - _mScore2;
                if (minusResult == 1)
                {
                    score = "Advantage player1";
                }
                else if (minusResult == -1)
                {
                    score = "Advantage player2";
                }
                else if (minusResult >= 2)
                {
                    score = "Win for player1";
                }
                else
                {
                    score = "Win for player2";
                }
            }
            else
            {
                // Déroulement d'une partie
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = _mScore1;
                    else { score += "-"; tempScore = _mScore2; }

                    if (tempScore == 0)
                    {
                        score += "Love";
                    }
                    else if (tempScore == 1)
                    {
                        score += "Fifteen";
                    }
                    else if (tempScore == 2)
                    {
                        score += "Thirty";
                    }
                    else if (tempScore == 3)
                    {
                        score += "Forty";
                    }
                }
            }
            return score;
        }

      
    }
}


