using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelsMechanics : MonoBehaviour
{
    private BoxCollider _heelsCollider;

    public Transform leftHeel;
    public Transform rightHeel;

    private const float _heelSize = 0.5f;
    private const float _colliderCenterOffset = 0.25f;
    private Vector3 _colliderHeight = new Vector3(0f, _heelSize, 0f);
    private Vector3 _colliderOffset = new Vector3(0f, _colliderCenterOffset, 0f);

    private int heelsCount = 0;

    private void Awake()
    {
        _heelsCollider = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //rise player and make heel collider bigger
            RiseUpPlayer();

            GrowHeelsCollider();

            //make heel graphics bigger
            GrowHeelsGraphics(leftHeel);
            GrowHeelsGraphics(rightHeel);

            heelsCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            float angle = Vector3.Dot(collision.GetContact(0).normal, Vector3.forward);

            float wallSizeInHeels = collision.transform.localScale.y * 2f;

            for (int i = 0; i < wallSizeInHeels; i++)
            {
                if (heelsCount > 0 && angle != 0)
                {
                    transform.position += new Vector3(0f, 0.08f, 0f);

                    //heels collider
                    _heelsCollider.size -= _colliderHeight;
                    _heelsCollider.center += _colliderOffset;

                    //heels graphics
                    leftHeel.localScale -= new Vector3(0f, _heelSize, 0f);
                    leftHeel.localPosition += new Vector3(0f, _colliderCenterOffset, 0f);

                    rightHeel.localScale -= new Vector3(0f, _heelSize, 0f);
                    rightHeel.localPosition += new Vector3(0f, _colliderCenterOffset, 0f);

                    heelsCount--;
                }
                else return;
            }
        }
    }

    private void RiseUpPlayer()
    {
        transform.position += new Vector3(0f, _heelSize, 0f);
    }

    private void GrowHeelsCollider()
    {
        _heelsCollider.size += _colliderHeight;
        _heelsCollider.center -= _colliderOffset;
    }

    private void GrowHeelsGraphics(Transform heel)
    {
        heel.localScale += new Vector3(0f, _heelSize, 0f);
        heel.localPosition -= new Vector3(0f, _colliderCenterOffset, 0f);
    }
}
