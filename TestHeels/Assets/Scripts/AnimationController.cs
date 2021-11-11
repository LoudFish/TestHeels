using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigidBody;

    private void Update()
    {
        playerAnimator.SetFloat("ForwardVelocity", playerRigidBody.velocity.z);
    }
}
