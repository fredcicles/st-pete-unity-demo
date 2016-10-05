using UnityEngine;

namespace TBUUG.Rollerball
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
	{
        // How fast the ball reacts to input
        public float force = 5f;

        private Rigidbody rb;


        /// <summary>
        /// Called once when the script is activated.  Always called before first call to Update.
        /// </summary>
        void Start()
		{
            rb = GetComponent<Rigidbody>();
        }


		/// <summary>
		/// Called every frame, if the script is enabled.
		/// </summary>
		void Update()
		{
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(direction * force);
        }
	}
}