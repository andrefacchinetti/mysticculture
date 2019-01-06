using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class PlayerController : MonoBehaviour
    {

        PlayerName playerName;
        private NetworkSocketIO socket;

        public float moveSpeed;
        private Joystick joystick;

        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.


        private void Start()
        {
            socket = FindObjectOfType(typeof(NetworkSocketIO)) as NetworkSocketIO;
            playerName = GetComponentInChildren<PlayerName>() as PlayerName;
            playerName.setName(this.name);

            this.joystick = FindObjectOfType(typeof(Joystick)) as Joystick;
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

        }

        void Update()
        {
            Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

            if (moveVector != Vector3.zero) 
            {//movimentacao de giro, virar o player de pra um lado e pro outro
                transform.rotation = Quaternion.LookRotation(moveVector);
                transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            }

            // read inputs
            //  float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C); //abaixar

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = moveVector;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = moveVector;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;

            socket.EmitPosition(transform.position); //emitir movimentacao pro servidor
            socket.EmitRotation(transform.rotation); // emitir rotacao pro servidor
        }
    }
}
