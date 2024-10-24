using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuyBehaviour : MonoBehaviour
{
    float timer = 0f;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 4f)
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }
}
