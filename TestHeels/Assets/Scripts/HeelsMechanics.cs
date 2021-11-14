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

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        //rise player and make heel collider bigger
    //        RiseUpPlayer(_heelSize);

    //        GrowHeelsCollider(1);

    //        //make heel graphics bigger
    //        GrowHeelsGraphics(leftHeel, 1);
    //        GrowHeelsGraphics(rightHeel, 1);

    //        heelsCount++;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HeelsPickUp"))
        {
            //rise player and make heel collider bigger
            RiseUpPlayer(_heelSize);

            GrowHeelsCollider(1);

            //make heel graphics bigger
            GrowHeelsGraphics(leftHeel, 1);
            GrowHeelsGraphics(rightHeel, 1);

            heelsCount++;

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Stepp"))
        {
            //from wich direction we hit obstacle
            float angle = Vector3.Dot(collision.GetContact(0).normal, Vector3.forward);

            float wallSizeInHeels = collision.transform.localScale.y * 2f;

            for (int i = 0; i < wallSizeInHeels; i++)
            {
                if (heelsCount > 0 && angle != 0)
                {
                    RiseUpPlayer(0.09f);

                    //heels collider
                    GrowHeelsCollider(-1);

                    //heels graphics
                    GrowHeelsGraphics(leftHeel, -1);
                    GrowHeelsGraphics(rightHeel, -1);

                    heelsCount--;
                }
                else return;
            }
        }
    }

    private void RiseUpPlayer(float height)
    {
        transform.position += new Vector3(0f, height, 0f);
    }

    private void GrowHeelsCollider(int sign)
    {
        _heelsCollider.size += _colliderHeight * sign;
        _heelsCollider.center -= _colliderOffset * sign;
    }

    private void GrowHeelsGraphics(Transform heel, int sign)
    {
        heel.localScale += new Vector3(0f, _heelSize, 0f) * sign;
        heel.localPosition -= new Vector3(0f, _colliderCenterOffset, 0f) * sign;
    }
}
