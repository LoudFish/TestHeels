using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public HeelsMechanics heelsMechanics;

    public delegate void OnFinish(bool finished);
    public event OnFinish OnFinishEvent;

    private Rigidbody _playerRigidbody;

    [SerializeField] private float _strafeSpeed = 10f;
    [SerializeField] private float _forwardSpeed = 5f;

    public bool onFinish = false;
    public bool pose = false;
    public bool finished = false;

    private void Awake()
    {
        Instance = this;

        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!finished) _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y, _forwardSpeed);

        OnFinishEvent?.Invoke(finished);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_playerRigidbody.velocity.x) < 4.5f) ResetVelocity(new Vector3(0f, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("Finish"))
        {
            onFinish = true;
        }

        if(other.gameObject.CompareTag("PoseTrigger"))
        {
            pose = true;
            finished = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stepp"))
        {
            float angle = Vector3.Dot(collision.GetContact(0).normal, Vector3.forward);

            //if(angle != 0 && onFinish)
            //{
            //    finished = true;
            //}
            if (heelsMechanics.heelsCount == 0 && onFinish)
            {
                finished = true;
            }
        }
    }

    public void Move(float direction)
    {
        _playerRigidbody.velocity = new Vector3(direction * _strafeSpeed, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z);
    }

    public void ResetVelocity(Vector3 velocity)
    {
        _playerRigidbody.velocity = velocity;
        _playerRigidbody.angularVelocity = Vector3.zero;
    }
}
