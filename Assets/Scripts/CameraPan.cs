using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed = 1;
    public float rotateSpeed = 1;
    private bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            // Pan left
            transform.position += new Vector3(-panSpeed * Time.deltaTime, 0, 0);

            // Rotate right
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            if (transform.rotation.y > 0.08)
            {
                moveRight = false;
            }
        }
        else
        {
            // Pan left
            transform.position += new Vector3(panSpeed * Time.deltaTime, 0, 0);

            // Rotate right
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
            if (transform.rotation.y < -0.08)
            {
                moveRight = true;
            }
        }
    }
}
