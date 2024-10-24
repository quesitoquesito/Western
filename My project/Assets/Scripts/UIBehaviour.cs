using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI rewardArchived;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject[] targetPositions;

    bool gameStarted = false;
    public float countdown = 60f;
    public float timer = 0f;
    float money = 0f;
    bool newTarget;
    float timeToChange;

    int randomTargetSelectedID;
    int randomPositionSelectedID;
    GameObject randomTargetSelected;
    GameObject randomPositionSelected;
    void Start()
    {
        endScreen.SetActive(false);
        startScreen.SetActive(true);
        newTarget = false;
    }

    void Update()
    {
        if (gameStarted == true)
        {
            timer += Time.deltaTime;
            countdown -= Time.deltaTime;
            countdownText.text = countdown.ToString("00");
            if (timer >= timeToChange)
            {
                newTarget = true;
            }
            if (countdown <= 0f)
            {
                gameStarted = false;
                EndGame();
            }
            if (newTarget == true)
            {
                newTarget = false;
                timeToChange = Random.Range(5f, 10f);
                ChangeTarget();
            }
        }
    }

    public void ChangeTarget()
    {
        randomTargetSelectedID = Random.Range(0, targets.Length);
        randomTargetSelected = targets[randomTargetSelectedID];
        if (randomTargetSelected.activeSelf)
        {
            ChangeTarget();
        }
        else
        {
            ChangePosition();
        }
    }

    public void ChangePosition()
    {
        randomPositionSelectedID = Random.Range(0, targetPositions.Length);
        randomPositionSelected = targetPositions[randomPositionSelectedID];
        if (randomPositionSelected.activeSelf)
        {
            ChangePosition();
        }
        else
        {
            randomTargetSelected.transform.position = randomPositionSelected.transform.position;
            randomTargetSelected.SetActive(true);
            randomPositionSelected.SetActive(true);
            Debug.Log("cambia");
            timer = 0f;
        }
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        rewardArchived.text = money.ToString() + " S";
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameStarted = true;
        newTarget = true;
    }

    public void RestartGame()
    {
        endScreen.SetActive(false);
        gameStarted = true;
        newTarget = true;
        money = 0f;
        moneyText.text = "xxx S";
        countdown = 60f;
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < targetPositions.Length; i++)
        {
            targetPositions[i].gameObject.SetActive(false);
        }
    }

    public void BadGuy()
    {
        money += 500f;
        MoneyChange();
    }

    public void BadGuy2()
    {
        money += 750f;
        MoneyChange();
    }

    public void GoodGuy()
    {
        money -= 50f;
        MoneyChange();
    }

    public void Sheriff()
    {
        money -= 100f;
        MoneyChange();
    }
    public void Lady()
    {
        money -= 80f;
        MoneyChange();
    }
    public void MoneyChange()
    {
        moneyText.text = money.ToString() + " S";
    }
}
