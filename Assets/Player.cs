using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    public GameObject[] CorpseArms;
    public GameObject Chosen;
    Corpse CorpseController;

    public AudioSource LoseSFX;
    public AudioSource WinSFX;
    public AudioSource BGSFX;
    public AudioSource MainMenuSFX;

    int Selection = 0;
    float WaitTime = .5f;
    float TimeLeft = 10;

    bool Finished = false;
    public bool Playing = false;
    bool Grabbed = false;

    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject TimerMesh;

    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(Choose());
        BGSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("VoidofLight");
        }

        if (Finished == true)
        {
            for(int i = 0; i < CorpseArms.Length; i++)
            {
            Destroy(CorpseArms[i].gameObject);
            }
        }

        if (Finished == false)
        {
            if (TimeLeft >= 0 && Playing == true)
            {
                TimeLeft = TimeLeft - Time.deltaTime;
                print(TimeLeft);
            }

            if (TimeLeft <= 0 && Playing == true)
            {
                Win();
            }

            if (Playing == true)
            {
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
            CorpseController.Speed = Random.Range(3.5f,4.25f);
        }

        if (TimeLeft < 3)
        {
            CorpseController.Speed = Random.Range(5f,6f);
        }
    }

    public void Lose()
    {
        if (Grabbed == false)
        {
        TimerMesh.SetActive(false);
        Finished = true;
        LoseScreen.SetActive(true);
        BGSFX.Stop();
        LoseSFX.Play();
        Grabbed = true;
        }
    }

    void Win()
    {
        TimerMesh.SetActive(false);
        Finished = true;
        WinScreen.SetActive(true);
        BGSFX.Stop();
        WinSFX.Play();
    }
}
