using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyConstraintController : MonoBehaviour
{
    Vector3 setPosition;
    // Start is called before the first frame update
    void Start()
    {
        setPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z != setPosition.z)
        {
            gameObject.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, setPosition.z), gameObject.transform.rotation);
        }
        if(gameObject.transform.rotation.eulerAngles.x != 0 || gameObject.transform.rotation.eulerAngles.y != 0)
        {
            gameObject.transform.SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z));
        }
    }
}
