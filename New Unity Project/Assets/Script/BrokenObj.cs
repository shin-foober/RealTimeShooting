/* using System.Collections.Generic;
using System.Linq;
public class BrokenObj : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        playerObj = GameObject.FindWithTag("Player");
        UnityChan2DController unityChan2DController = playerObj.GetComponent<UnityChan2DController>();

        if (playerObj != coll.gameObject)
            Destroy(gameObject);
    }
}
*/