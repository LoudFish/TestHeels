using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public Transform heels; //heels object which represents it`s collider
    public BoxCollider heelCollider;

    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private float playerYPosition;

    private bool isRotated = false;

    private void Start()
    {
        originalPosition = heels.localPosition;
        originalRotation = heels.localRotation;
    }

    private void Update()
    {
        if (!isRotated) playerYPosition = transform.position.y;

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    isRotated = true;

        //    float colliderCenter = heelCollider.size.y * 0.5f;
        //    RotateHeelsCollider(Quaternion.Euler(0f, 0f, 90f), new Vector3(-colliderCenter, -0.25f, 0f));
        //}

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    isRotated = false;

        //    transform.position = new Vector3(transform.position.x, playerYPosition, transform.position.z);

        //    RotateHeelsCollider(originalRotation, originalPosition);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SlideTrigger"))
        {
            isRotated = true;

            float colliderCenter = heelCollider.size.y * 0.5f;
            RotateHeelsCollider(Quaternion.Euler(0f, 0f, 90f), new Vector3(-colliderCenter, -0.25f, 0f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SlideTrigger"))
        {
            isRotated = false;

            float height = Mathf.Abs(playerYPosition) - Mathf.Abs(transform.position.y);

            transform.position += new Vector3(0f, height, 0f);

            RotateHeelsCollider(originalRotation, originalPosition);
        }
    }

    private void RotateHeelsCollider(Quaternion rotation, Vector3 desiredPosition)
    {
        heels.localRotation = rotation;

        heels.localPosition = desiredPosition;
    }
}
