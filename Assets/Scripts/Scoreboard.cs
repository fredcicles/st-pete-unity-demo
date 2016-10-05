using UnityEngine;
using UnityEngine.UI;

namespace TBUUG.Rollerball
{
	public class Scoreboard : MonoBehaviour
	{
        public Text ballsText;
        public Text scoreText;
        public GameObject gameOverBox;
        public GameObject winBox;
        public GameObject loseBox;


        /// <summary>
        /// Clears the score and resets to the default number of players available
        /// </summary>
        public void Reset(int balls, int score)
		{
            gameOverBox.SetActive(false);
            winBox.SetActive(false);
            loseBox.SetActive(false);

            SetBalls(balls);
            SetScore(score);
		}


        /// <summary>
        /// Set the score
        /// </summary>
        public void SetScore(int score)
		{
            scoreText.text = score.ToString();
        }



        /// <summary>
        /// Set the number of balls
        /// </summary>
        public void SetBalls(int balls)
		{
            ballsText.text = balls.ToString();
        }


        /// <summary>
        /// Shows the win message
        /// </summary>
        public void ShowWin()
        {
            gameOverBox.SetActive(true);
            winBox.SetActive(true);
        }


        /// <summary>
        /// Shows the lose message
        /// </summary>
        public void ShowLose()
        {
            gameOverBox.SetActive(true);
            loseBox.SetActive(true);
        }
    }
}