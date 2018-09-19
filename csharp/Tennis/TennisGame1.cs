
namespace Tennis
{
    class TennisGame1 : ITennisGame
    {

        public Player leftPlayer;
        public Player rightPlayer;
        public TennisGame1(string player1Name, string player2Name)
        {
            leftPlayer = new Player("leftPlayer");
            rightPlayer = new Player("rightPlayer");
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                leftPlayer.Point += 1;
            else
                rightPlayer.Point += 1;
        }

        public string GetScore()
        {
            string score = "";
            // Egalité 
            if (leftPlayer.Point == rightPlayer.Point)
            {
                if (leftPlayer.Point == 0)
                {
                    score = "Love-All";
                }
                else if (leftPlayer.Point == 1)
                {
                    score = "Fifteen-All";
                }
                else if (leftPlayer.Point == 2)
                    score = "Thirty-All";
                else
                    score = "Deuce";
            }
            // AVantage + Gagnant 
            else if (leftPlayer.Point >= 4 || rightPlayer.Point >= 4)
            {
                var minusResult = leftPlayer.Point - rightPlayer.Point;
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
                    if (i == 1) tempScore = leftPlayer.Point;
                    else { score += "-"; tempScore = rightPlayer.Point; }

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


