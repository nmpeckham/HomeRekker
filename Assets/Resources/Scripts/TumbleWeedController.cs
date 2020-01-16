using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeedController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity -= new Vector2(.01f, 0);
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
