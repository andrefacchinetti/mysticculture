using UnityEngine;

   
    public class CameraMove : MonoBehaviour
    {

        private GameObject camera;
        private Vector3 offset;


        private void Start()
        {
            this.camera = GameObject.FindGameObjectWithTag("MainCamera");
            offset = camera.transform.position - transform.position;
        }

        void LateUpdate()
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            camera.transform.position = transform.position + offset;
            
        }

    }

