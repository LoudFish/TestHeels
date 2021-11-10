using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private Rigidbody _playerRigidbody;

    [SerializeField] private float _strafeSpeed = 10f;

    private void Awake()
    {
        Instance = this;

        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_playerRigidbody.velocity.x) < 8.5f) ResetVelocity();
    }

    public void Move(float direction)
    {
        _playerRigidbody.velocity = new Vector3(direction * _strafeSpeed, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z);
    }

    public void ResetVelocity()
    {
        _playerRigidbody.velocity = new Vector3(0f, _playerRigidbody.velocity.y, 0f);
        _playerRigidbody.angularVelocity = Vector3.zero;
    }
}
