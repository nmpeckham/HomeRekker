using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallHazard : Hazard
{
    public Rigidbody2D self;
    public float delayTime = 0f;
    public float velocityX = 5.0f;
    public float velocityY = 5.0f;
    public float runTime = 5.0f;

    private bool running = false;

    public override void StartHazard()
    {
        //Debug.Log("Started");
        StartCoroutine("StartBulldozer");
    }

    IEnumerator StartBulldozer()
    {
        yield return new WaitForSeconds(delayTime);
        running = true;
        yield return new WaitForSeconds(runTime);
        running = false;
        self.velocity = new Vector3(0, 0, 0);
        finished = true;
    }

    void Update()
    {
        if (running)
        {
            self.velocity = new Vector3(velocityX, velocityY, 0);
        }
    }

    void Awake()
    {
        self = GetComponent<Rigidbody2D>();
        if (velocityX > 0)
            self.GetComponentInChildren<SpriteRenderer>().flipX = true;

    }
}
