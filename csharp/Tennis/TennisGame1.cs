
namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const int LOVE = 0;
        private const int FIFTEEN = 1;
        private const int THIRTY = 2;
        private const int FORTY = 3;

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


        public string ManageEquality(Player leftPlayer)
        {
            string score = "";
            if (leftPlayer.Point == LOVE)
            {
                score = "Love-All";
            }
            else if (leftPlayer.Point == FIFTEEN)
            {
                score = "Fifteen-All";
            }
            else if (leftPlayer.Point == THIRTY)
                score = "Thirty-All";
            else
                score = "Deuce";

            return score;

        }
        public string GetScore()
        {
            string score = "";

            // Egalité 
            if (leftPlayer.Point == rightPlayer.Point)
            {
                score = ManageEquality(leftPlayer);

            }
            // AVantage + Gagnant 
            else if (APlayerHasAdvantage())
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
                else if (minusResult >= THIRTY)
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
                for (var i = 1; i < FORTY; i++)
                {
                    var tempScore = 0;
                    if (i == 1)
                    {
                        tempScore = leftPlayer.Point;
                    }
                    else
                    {
                        score += "-";
                        tempScore = rightPlayer.Point;
                    }

                    if (tempScore == 0)
                    {
                        score += "Love";
                    }
                    else if (tempScore == FIFTEEN)
                    {
                        score += "Fifteen";
                    }
                    else if (tempScore == THIRTY)
                    {
                        score += "Thirty";
                    }
                    else if (tempScore == FORTY)
                    {
                        score += "Forty";
                    }
                }
            }
            return score;
        }

        private bool APlayerHasAdvantage()
        {
            return leftPlayer.Point >= 4 || rightPlayer.Point >= 4;
        }

    }
}


