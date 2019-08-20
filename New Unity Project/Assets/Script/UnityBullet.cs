using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBullet : MonoBehaviour
{
    private bool bdirectionflag;
    private int ndirection;

    GameObject directionObj;

    // Start is called before the first frame update
    void Start()
    {
        directionObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = directionObj.GetComponent<UnityChan2DController>();

        if (1 == unityChan2DController.fdflag)
        {
            ndirection = 1;
        }
        else
        {
            ndirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ndirection * 0.05f, 0, 0);
    }
}
