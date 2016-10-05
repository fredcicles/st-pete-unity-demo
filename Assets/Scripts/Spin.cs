using UnityEngine;

namespace TBUUG.Rollerball
{
	public class Spin : MonoBehaviour
	{
        public float speed = 1f;

        public bool xAxis = false;
        public bool yAxis = false;
        public bool zAxis = false;

        private float speedMultiplier = 10;

        /// <summary>
        /// Called every frame, if the script is enabled.
        /// </summary>
        void Update()
        {
            if (GameController.GameState != Enums.GameState.Playing)
            {
                return;
            }

            float xRotation = xAxis ? speed * speedMultiplier : 0;
            float yRotation = yAxis ? speed * speedMultiplier : 0;
            float zRotation = zAxis ? speed * speedMultiplier : 0;

            Vector3 rotation = new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime;

            gameObject.transform.Rotate(rotation);
        }
    }
}