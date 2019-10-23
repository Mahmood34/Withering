<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime , 0 , 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime , 0 , 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0 , 0 , forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0 , 0 , -forwardForce * Time.deltaTime);
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime , 0 , 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime , 0 , 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0 , 0 , forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0 , 0 , -forwardForce * Time.deltaTime);
        }
    }
}
>>>>>>> Stashed changes
