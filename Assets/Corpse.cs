using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour

{
public GameObject PlayerCharacter;
public GameObject CorpseArm;
public ParticleSystem Explosion;
public float Speed = 1.5f;
Vector3 StartPosition;
Vector3 Target = new Vector3(0, 0, 0);
bool Crawling = false;
Player PlayerController;

public AudioSource Burst;

    void Start()
    {
        StartPosition = transform.position;
        PlayerController = PlayerCharacter.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Crawling == true)
        {
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
        }
    }

    public void Crawl()
    {
        Crawling = true;
    }

    public void Retreat()
    {
        Crawling = false;
        Instantiate(Explosion, transform.position, transform.rotation).Play();
        Burst.Play();
        transform.position = StartPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Trigger") 
        {
            Retreat();              
        }

        if (other.tag == "Player Character") 
        {
            PlayerController.Lose();       
        }
        
    }
}
