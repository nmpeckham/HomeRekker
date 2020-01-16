using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedMenu : MonoBehaviour
{

    public GameObject tumbleweed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.autoSimulation = true;
        timer = Random.Range(3f, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % timer < .01)
        {
            GameObject weed = Instantiate(tumbleweed, new Vector3(Random.Range(-1f, 1) + 10, Random.Range(-1f, 1) + 6, -1), Quaternion.identity);
            weed.GetComponent<Rigidbody2D>().velocity = new Vector3(-4f, 0, 0);
            timer = Random.Range(3f, 5);
        }
    }
}
