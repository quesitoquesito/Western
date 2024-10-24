using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SheriffBehaviour : MonoBehaviour
{
    float timer = 0f;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }
}
