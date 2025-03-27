using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Rigidbody rb;

    private const float MIN_FORCE_AMOUNT = 0.2f;
    private const float MAX_FORCE_AMOUNT = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (transform.parent == null) { return; }

        if (transform.parent.localPosition.z < 0)
        {
            rb.AddForce(Vector3.forward * Random.Range(MIN_FORCE_AMOUNT, MAX_FORCE_AMOUNT), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(Vector3.back * Random.Range(MIN_FORCE_AMOUNT, MAX_FORCE_AMOUNT), ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("road")) { Destroy(gameObject); }
    }
}
