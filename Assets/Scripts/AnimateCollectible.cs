using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCollectible : MonoBehaviour
{
    public int xRotate = 15;
    public int yRotate = 30;
    public int zRotate = 45;
    public float yMoveSpeed = 0.5f;
    public float moveDuration = 1.5f;
    private float time;
    private float moveSign = 1;

    void Start()
    {
        time = moveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle vertical movement bobbing.
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = moveDuration;
            moveSign *= -1;
        }

        // Handle slow rotation.
        transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * Time.deltaTime);
        transform.position += new Vector3(0, yMoveSpeed * moveSign, 0) * Time.deltaTime;
    }
}
