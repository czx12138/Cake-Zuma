using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public Transform target;
    public float mass = 100;

    void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        float distance = direction.magnitude;
        float forceMagnitude = mass / (distance * distance);
        Vector2 force = direction.normalized * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

}
