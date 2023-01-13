using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public GameObject[] CorpseArms;
    public GameObject Chosen;
    Corpse CorpseController;

    int Selection = 0;
    float WaitTime = .5f;
    float TimeLeft = 10;

    bool Finished = false;

    public GameObject LoseScreen;
    public GameObject WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Choose());
    }

    // Update is called once per frame
    void Update()
    {
        if (Finished == false)
        {
            if (TimeLeft >= 0)
            {
                TimeLeft = TimeLeft - Time.deltaTime;
                print(TimeLeft);
            } else {
                Win();
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,225));
                print("Top Left");
            }

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
                print("Top");
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,135));
                print("Top Right");
            }

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                print("Right");
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,45));
                print("Bottom Right");
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                print("Bottom");
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,315));
                print("Bottom Left");
            }

            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
                print("Left");
            }
        }
    }

    IEnumerator Choose()
    {
        AdjustTime();
        yield return new WaitForSeconds(WaitTime);
        Selection = Random.Range(0,8);
        print(Selection);
        CorpseController = CorpseArms[Selection].GetComponent<Corpse>();
        //CorpseArms[Selection] = Chosen;
        AdjustSpeed();
        CorpseController.Crawl();
        StartCoroutine(Choose());
    }

    void AdjustTime()
    {
        if (TimeLeft <= 8 && TimeLeft > 5)
        {
            WaitTime = .35f;
            print("WaitTime .35");
        }

        if (TimeLeft <= 5 && TimeLeft > 3)
        {
            WaitTime = .25f;
            print("WaitTime .25");
        }

        if (TimeLeft < 3)
        {
            WaitTime = .15f;
            print("WaitTime .15");
        }
    }

    void AdjustSpeed()
    {
        if (TimeLeft <= 8 && TimeLeft > 5)
        {
            CorpseController.Speed = Random.Range(2f,3f);
        }

        if (TimeLeft <= 5 && TimeLeft > 3)
        {
            CorpseController.Speed = Random.Range(4f,5f);
        }

        if (TimeLeft < 3)
        {
            CorpseController.Speed = Random.Range(6f,7f);
        }
    }

    public void Lose()
    {
        Finished = true;
        LoseScreen.SetActive(true);
    }

    void Win()
    {
        Finished = true;
        WinScreen.SetActive(true);
    }
}
