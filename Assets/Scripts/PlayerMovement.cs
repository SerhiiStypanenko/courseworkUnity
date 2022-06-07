using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator m_Animator;
    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity;
    private Rigidbody m_Rigidbody;
    private AudioSource _audioSource;
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();
        m_Movement *= speed;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal,0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical,0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", isWalking);

        if(isWalking){
            if(!_audioSource.isPlaying){
                _audioSource.Play();
            }
        }
        else _audioSource.Stop();
            

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement,turnSpeed*Time.deltaTime,0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

    }
    
    private void OnAnimatorMove() {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}

