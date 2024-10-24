using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBehaviour : MonoBehaviour
{
    float timer = 0f;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }
}
