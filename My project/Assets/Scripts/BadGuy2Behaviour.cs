using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy2Behaviour : MonoBehaviour
{
    float timer = 0f;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }
}