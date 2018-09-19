
using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const int LOVE = 0;
        private const int FIFTEEN = 1;
        private const int THIRTY = 2;
        private const int FORTY = 3;
        private const int POINTS_AHEAD_OPPONENT = 2;
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
                score = ManageEquality(leftPlayer);
            }
            // AVantage + Gagnant 
            else if (APlayerHasAdvantage())
            {
                var gapBetweenPlayerPoints = leftPlayer.Point - rightPlayer.Point;
                if (Math.Abs(gapBetweenPlayerPoints) >= POINTS_AHEAD_OPPONENT)
                {
                    score = ManageWinning(gapBetweenPlayerPoints);
                }
                else
                {
                    score = ManageAdvantage(gapBetweenPlayerPoints);
                }

            }
            else
            {
                // Déroulement d'une partie
                score = PlayUntilAdvantagePoint(score);
            }
            return score;
        }

        private string PlayUntilAdvantagePoint(string score)
        {
            for (var i = 1; i < FORTY; i++)
            {
                var tempScore = MakeFirstPoint(ref score, i);

                score = AttributePoints(score, tempScore);
            }

            return score;
        }

        private int MakeFirstPoint(ref string score, int i)
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

            return tempScore;
        }

        private static string AttributePoints(string score, int tempScore)
        {
            if (tempScore == LOVE)
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

            return score;
        }

        private string ManageAdvantage(int gapBetweenPlayerPoints)
        {
            if (gapBetweenPlayerPoints == 1)
            {
                return "Advantage player1";
            }
            return "Advantage player2";

        }

        private string ManageWinning(int gapBetweenPlayerPoints)
        {
            if (gapBetweenPlayerPoints >= POINTS_AHEAD_OPPONENT)
            {
                return "Win for player1";
            }
            return "Win for player2";

        }

        public string ManageEquality(Player leftPlayer)
        {
            if (leftPlayer.Point == LOVE)
            {
                return "Love-All";
            }

            if (leftPlayer.Point == FIFTEEN)
            {
                return "Fifteen-All";
            }

            if (leftPlayer.Point == THIRTY)
                return "Thirty-All";
            return "Deuce";
        }

        private bool APlayerHasAdvantage()
        {
            return leftPlayer.Point >= 4 || rightPlayer.Point >= 4;
        }

    }
}


