using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public bool _touched = false;
    public int heat = 0;

    private GameObject life;

    public void Start()
    {
        life = transform.Find("Life").gameObject;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.gameObject.CompareTag("Ground") && !other.collider.gameObject.CompareTag("Person"))
        {
            _touched = true;
            if(life.GetComponent<SpriteRenderer>().sprite.name != "skull")  life.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("skull");
        }
    }
}
