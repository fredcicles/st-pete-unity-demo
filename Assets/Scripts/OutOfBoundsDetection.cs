using UnityEngine;

namespace TBUUG.Rollerball
{
    public class OutOfBoundsDetection : MonoBehaviour
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
                gameController.PlayerDied();
            }
        }


        /// <summary>
        /// Called when another game object has collided with this game object.
        /// </summary>
        /// <param name="collision">Information about the collision of the two objects.</param>
        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                gameController.PlayerDied();
            }
        }
    }
}