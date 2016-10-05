using TBUUG.Rollerball.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TBUUG.Rollerball
{
    [RequireComponent(typeof(AudioSource))]
    public class GameController : MonoBehaviour
    {
        public AudioClip winSound;
        public AudioClip dieSound;
        public AudioClip coinCollectedSound;

        public GameObject spawnPoint;
        public GameObject player;

        public int startingBallCount = 2;
        public int coinsToWin = 10;

        public Scoreboard scoreboard;

        private new AudioSource audio;
        private Rigidbody playerRigidBody;

        private int currentBallCount;
        private int coinsCollected;


        public static GameState GameState = GameState.NotStarted;


        /// <summary>
        /// Called once when the script is activated.  Always called before first call to Update.
        /// </summary>
        void Start()
        {
            audio = GetComponent<AudioSource>();
            playerRigidBody = player.GetComponent<Rigidbody>();

            currentBallCount = startingBallCount;
            coinsCollected = 0;

            Debug.Log("Reset scoreboard");
            if (scoreboard != null)
            {
                scoreboard.Reset(currentBallCount, coinsCollected);
            }

            GameState = GameState.Playing;
        }


        /// <summary>
        /// Restart the game
        /// </summary>
        public void Restart()
        {
            SceneManager.LoadScene(0);
        }


        /// <summary>
        /// Called when the player dies
        /// </summary>
        public void PlayerDied()
        {
            PlaySound(dieSound);

            if (currentBallCount <= 0)
            {
                Debug.Log("Game over");
                GameState = GameState.GameOver;

                player.SetActive(false);

                if (scoreboard != null)
                {
                    scoreboard.ShowLose();
                }
            }
            else
            {
                Debug.Log("Respawn player");

                if (spawnPoint != null)
                {
                    player.transform.position = spawnPoint.transform.position;
                }

                playerRigidBody.velocity = Vector3.zero;

                Debug.Log("Player has " + currentBallCount + " balls left");

                currentBallCount--;

                if (scoreboard != null)
                {
                    scoreboard.SetBalls(currentBallCount);
                }
            }
        }


        /// <summary>
        /// Called when the player collects a coin
        /// </summary>
        public void CoinCollected()
        {
            Debug.Log("Player has collected a coin");

            PlaySound(coinCollectedSound);

            // Update the score
            coinsCollected++;

            if (scoreboard != null)
            {
                scoreboard.SetScore(coinsCollected);
            }

            if (coinsCollected >= coinsToWin)
            {
                Win();
            }
        }


        /// <summary>
        /// Called when the player wins
        /// </summary>
        private void Win()
        {
            Debug.Log("Player wins");
            GameState = GameState.GameOver;

            PlaySound(winSound);
            player.SetActive(false);

            if (scoreboard != null)
            {
                scoreboard.ShowWin();
            }
        }


        /// <summary>
        /// Plays an audio clip
        /// </summary>
        /// <param name="clip">audio clip to play</param>
        private void PlaySound(AudioClip clip)
        {
            if (audio != null)
            {
                audio.clip = clip;
                audio.Play();
            }
        }
    }
}