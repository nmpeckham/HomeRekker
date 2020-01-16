using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozerHazard : Hazard
{
    public Rigidbody2D self;
    public float delayTime = 0f;
    public float velocity = 5.0f;
    public float runTime = 5.0f;

    private bool running = false;
    private bool onGround = false;

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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    void Update()
    {
        if (running && onGround)
        {
            self.velocity = new Vector3(velocity, 0, 0);
        }
    }

    void Awake()
    {
        self = GetComponent<Rigidbody2D>();
        if (velocity > 0)
            self.GetComponentInChildren<SpriteRenderer>().flipX = true;

    }
}
