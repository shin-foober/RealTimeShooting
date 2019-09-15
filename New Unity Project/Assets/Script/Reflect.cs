using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            //coll.gameObject.ndirectionLR = 0;
            //coll.gameObject.ndirectionUD = 1;
        }
    }
}
