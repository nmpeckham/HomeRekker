using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloudsMenu : MonoBehaviour
{

    public GameObject cloud1;
    public GameObject cloud2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cloud1.transform.SetPositionAndRotation(new Vector3(cloud1.transform.position.x - 0.003f, cloud1.transform.position.y, -1), Quaternion.identity);
        cloud2.transform.SetPositionAndRotation(new Vector3(cloud2.transform.position.x - 0.005f, cloud2.transform.position.y, -1), Quaternion.identity);

        if(cloud1.transform.position.x < -9) cloud1.transform.SetPositionAndRotation(new Vector3(9, cloud1.transform.position.y, -1), Quaternion.identity);
        if(cloud2.transform.position.x < -9) cloud2.transform.SetPositionAndRotation(new Vector3(9, cloud2.transform.position.y, -1), Quaternion.identity);


    }
}
