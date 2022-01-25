using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [Serializable] private class GameEvent : UnityEvent { }
    [SerializeField] private GameEvent ScorePoint;
    MeshRenderer rend;
    private bool once = true; // Used to disappear only once (quirk caused by shadow child triggers scoring twice).
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            if (f < 0.25f)
            {
                // Remove shadows after 50% transparent since underlying sphere
                // creating the shadow is opaque.
                transform.GetChild(0).gameObject.SetActive(false);
            }
            Material[] mats = rend.materials;
            int matCount = rend.materials.Length;
            for (int i=0; i < matCount; i++)
            {
                Material mat = mats[i];
                Color c = mat.color;
                c.a = f;
                mat.color = c;
            }
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (once && other.gameObject.CompareTag("OutOfBounds"))
        {
            Debug.Log($"Score! {gameObject.name}");
            once = false;
            StartCoroutine(FadeOut());
            ScorePoint.Invoke();
        }
    }
}
