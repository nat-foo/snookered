using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Serializable] private class GameEvent : UnityEvent { }
    [SerializeField] private GameEvent GameOver;
    public float speed = 20;
    public GameObject cameraObject;
    private Rigidbody rb;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Move Event
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        Vector3 moveX = cameraObject.transform.right * movementVector.x;
        Vector3 moveZ3D = cameraObject.transform.forward * movementVector.y;
        Vector3 moveZ = new Vector3(moveZ3D.x, 0, moveZ3D.z);
        moveDirection = moveX + moveZ;
    }
    void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            GameOver.Invoke();
            gameObject.SetActive(false);
        }
        rb.AddForce(moveDirection * speed);
        transform.Rotate(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            GameOver.Invoke();
        }
    }
}
