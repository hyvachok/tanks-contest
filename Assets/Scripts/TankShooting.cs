using UnityEngine;

namespace Complete
{
    public class TankShooting : MonoBehaviour
    {
        public int m_PlayerNumber = 1;
        public Rigidbody m_Shell;
        public Transform m_FireTransform;
        public AudioSource m_ShootingAudio;
        public AudioClip m_FireClip;
        public float m_LaunchForce = 20.0f;

        private string m_FireButton;
        private bool m_Fired;

        private void Start()
        {
            m_FireButton = "Fire" + m_PlayerNumber;
        }

        private void Update()
        {
            if (Input.GetButtonDown(m_FireButton))
            {
                m_Fired = false;
            }
            else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
            {
                Fire();
            }
        }

        private void Fire()
        {
            m_Fired = true;
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
        }
    }
}