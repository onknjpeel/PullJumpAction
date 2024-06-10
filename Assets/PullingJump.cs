using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Vector3 clickPosition;
    private Rigidbody rb;
    private bool isCanJump;
    [SerializeField]
    private float jumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            if (dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("è’ìÀÇµÇΩ");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("ê⁄êGíÜ");

        ContactPoint[] contact = collision.contacts;

        Vector3 otherNormmal = contact[0].normal;

        Vector3 upVector = new Vector3(0, 1, 0);

        float dotUN = Vector3.Dot(upVector, otherNormmal); ;

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("ó£íEÇµÇΩ");
        isCanJump = false;
    }
}
