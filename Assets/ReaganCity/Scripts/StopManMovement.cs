using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StopManMovement : MonoBehaviour
{
    private Vector3 goalPosition;
    private float interval;
    private Rigidbody rb;
    public float maxSpeed;
    private float nextTime;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        interval = Random.Range(1.0f, 5.0f);
        float randX = Random.Range(-20.0f, 20.0f);
        float randZ = Random.Range(-20.0f, 20.0f);
        goalPosition = new Vector3(randX, gameObject.transform.position.y, randZ);
        nextTime = Time.time + interval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirecion = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        if (rb.velocity.magnitude > 0) { 
            gameObject.transform.rotation = Quaternion.LookRotation(lookDirecion) * Quaternion.Euler(0,-90,0);
        }

        rb.AddForce((goalPosition - gameObject.transform.position).normalized * force);
        rb.AddForce(new Vector3(0.0f, -9.8f * rb.mass, 0.0f));
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (gameObject.transform.position.y <= -100.0f)
        {
            gameObject.transform.position = new Vector3(-5.0f, 5.0f, -5.0f);
        }
        if (Time.time > nextTime)
        {
            interval = Random.Range(1.0f, 5.0f);
            nextTime = Time.time + interval;
            float randX = Random.Range(-20.0f, 20.0f);
            float randZ = Random.Range(-20.0f, 20.0f);
            goalPosition = new Vector3(randX, gameObject.transform.position.y, randZ);
        }
        //gameObject.transform.rotation = Quaternion.LookRotation(goalPosition) * Quaternion.Euler(0.0f, -90.0f, 0.0f);
    }
}
