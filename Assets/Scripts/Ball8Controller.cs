using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Ball8Controller : MonoBehaviour
{
    [Serializable] private class GameEvent : UnityEvent { }
    [SerializeField] private GameEvent ScoreBall8;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            Debug.Log($"Score! {gameObject.name}");
            ScoreBall8.Invoke();
        }
    }
}
