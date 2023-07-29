using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float targetrotation;
    public Rigidbody2D rb;
    public float force;

    private void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetrotation, force * Time.fixedDeltaTime));
    }
}
