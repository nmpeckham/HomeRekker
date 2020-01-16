using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHazard : Hazard
{
    public Transform self;
    public Transform raindrop;

    public float delayTime = 0f;
    public float frequency = 0.1f;
    public float time = 5.0f;

    private bool raining = false;
    private float nextRain = 0.0f;

    public override void StartHazard()
    {
        StartCoroutine("StartRain");
    }

    IEnumerator StartRain()
    {
        yield return new WaitForSeconds(delayTime);
        raining = true;
        yield return new WaitForSeconds(time);
        raining = false;
        finished = true;
    }

    void Update()
    {
        if (raining && Time.time > nextRain)
        {
            float xSpawn = Random.Range(self.position.x - 1, self.position.x + 1);
            Vector3 spawnPoint = new Vector3(xSpawn, self.position.y, self.position.z);
            Instantiate(raindrop, spawnPoint, Quaternion.identity);
            nextRain = Time.time + frequency;
        }
    }
}