namespace SnakesAndLadders
{
    public class SnakesLadders
    {
        public SnakesLadders()
        {
            isGameOver = false;
            playerTracker = PlayerTrackerDic();
        }

        public string play(int die1, int die2)
        {
            //Code here
            if (isGameOver)
            {
                return "Game over!";
            }
            //check player 1 moves
            if (playerTracker[player1][0] == 1)
            {
                playerTracker[player1][1] += (die1 + die2);
                if (playerTracker[player1][1] > 100)
                {
                    var diff = playerTracker[player1][1] - 100;
                    playerTracker[player1][1] = 100;
                    playerTracker[player1][1] -= diff;
                }
                if (isPlayerWon(player1))
                {
                    return "Player 1 Wins!";
                }

                if (GameBoardLadderDic().ContainsKey(playerTracker[player1][1]))
                {
                    playerTracker[player1][1] = GameBoardLadderDic()[playerTracker[player1][1]];

                }
                else if (GameBoardSnakeDic().ContainsKey(playerTracker[player1][1]))
                {
                    playerTracker[player1][1] = GameBoardSnakeDic()[playerTracker[player1][1]];

                }
                else
                {

                    return HandlePlayer1OnFinish(die1, die2);
                }



                return HandlePlayer1OnFinish(die1, die2);

            }
            else if (playerTracker[player2][0] == 1)
            {
                playerTracker[player2][1] += (die1 + die2);
                if (playerTracker[player2][1] > 100)
                {
                    var diff = playerTracker[player2][1] - 100;
                    playerTracker[player2][1] = 100;
                    playerTracker[player2][1] -= diff;
                }
                if (isPlayerWon(player2))
                {
                    return "Player 2 Wins!";
                }
                if (GameBoardLadderDic().ContainsKey(playerTracker[player2][1]))
                {
                    playerTracker[player2][1] = GameBoardLadderDic()[playerTracker[player2][1]];

                }
                else if (GameBoardSnakeDic().ContainsKey(playerTracker[player2][1]))
                {
                    playerTracker[player2][1] = GameBoardSnakeDic()[playerTracker[player2][1]];

                }
                else
                {

                    return HandlePlayer2OnFinish(die1, die2);
                }

                return HandlePlayer2OnFinish(die1, die2);
            }
            return "";
        }



        private bool isGameOver;

        private string player1 = "player 1";
        private string player2 = "player 2";

        private Dictionary<string, List<int>> playerTracker;

        private bool isPlayerWon(string player)
        {
            if (playerTracker[player][1] >= 100)
            {
                isGameOver = true;
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool TakeAnotherTry(int die1, int die2)
        {
            return die1 == die2;
        }

        private Dictionary<string, List<int>> PlayerTrackerDic()
        {
            var playerTrackerDic = new Dictionary<string, List<int>>();

            playerTrackerDic[player1] = new List<int>() { 1, 0 };

            playerTrackerDic[player2] = new List<int>() { 0, 0 };

            return playerTrackerDic;
        }

        private string HandlePlayer1OnFinish(int die1, int die2)
        {
            playerTracker[player1][0] = 0;
            playerTracker[player2][0] = 1;
            if (TakeAnotherTry(die1, die2))
            {
                playerTracker[player1][0] = 1;
                playerTracker[player2][0] = 0;
            }
            return $"Player 1 is on square {playerTracker[player1][1]}";
        }
        private string HandlePlayer2OnFinish(int die1, int die2)
        {
            playerTracker[player1][0] = 1;
            playerTracker[player2][0] = 0;

            if (TakeAnotherTry(die1, die2))
            {
                playerTracker[player2][0] = 1;
                playerTracker[player1][0] = 0;
            }
            return $"Player 2 is on square {playerTracker[player2][1]}";
        }

        private Dictionary<int, int> GameBoardLadderDic()
        {
            var ladderDic = new Dictionary<int, int>();

            ladderDic[2] = 38;
            ladderDic[7] = 14;
            ladderDic[8] = 31;
            ladderDic[15] = 26;
            ladderDic[21] = 42;
            ladderDic[28] = 84;
            ladderDic[36] = 44;
            ladderDic[51] = 67;
            ladderDic[78] = 98;
            ladderDic[71] = 91;
            ladderDic[87] = 94;

            return ladderDic;
        }


        private Dictionary<int, int> GameBoardSnakeDic()
        {
            var snakeHeadDic = new Dictionary<int, int>();

            snakeHeadDic[99] = 80;
            snakeHeadDic[95] = 75;
            snakeHeadDic[92] = 88;
            snakeHeadDic[89] = 68;
            snakeHeadDic[74] = 53;
            snakeHeadDic[64] = 60;
            snakeHeadDic[62] = 19;
            snakeHeadDic[46] = 25;
            snakeHeadDic[49] = 11;
            snakeHeadDic[16] = 6;

            return snakeHeadDic;
        }


    }
}