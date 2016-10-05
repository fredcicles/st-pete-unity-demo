using UnityEngine;

namespace TBUUG.Rollerball
{
    public class Collectable : MonoBehaviour
    {
        public GameController gameController;


        /// <summary>
        /// Called when another game object has collided with this game object.
        /// </summary>
        /// <param name="other">Collider of the other game object that has collided with this game object.</param>
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameController.CoinCollected();
                Destroy(gameObject);
            }
        }
    }
}