using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshPro TimerMesh;
    float TimeLeft = 12;

    public GameObject MainMenu;
    public MeshRenderer TimerMeshRenderer;

    bool DoOnce = false;

    public GameObject PlayerCharacter;
    Player PlayerController;

    void Start()
    {
        PlayerController = PlayerCharacter.GetComponent<Player>();
    }

    void Update()
    {
        if(TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            UpdateTimer(TimeLeft);
        }

        if(TimeLeft <= 10 && DoOnce == false)
        {
            PlayerController.Playing = true;
            MainMenu.SetActive(false);
            TimerMeshRenderer.enabled = true;
            PlayerController.StartGame();
            DoOnce = true;
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
        float milliseconds = Mathf.FloorToInt(currentTime * 1000 % 1000);

        TimerMesh.text = string.Format("{00:00}", seconds);
    }
}
