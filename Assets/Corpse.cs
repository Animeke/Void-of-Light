using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour

{
public GameObject Player;
public GameObject CorpseArm;
public float Speed;
Vector3 StartPosition;
Vector3 Target = new Vector3(0, 0, 0);

    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
    }

    public void Start()
    {
        Speed = 1.5f;
    }

    public void Slow()
    {
        Speed = Speed/2;
    }

    public void Retreat()
    {
        Speed = -Speed;
    }
}
