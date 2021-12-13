using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myenemypatrolScript : MonoBehaviour
{
    public float Speed;
    public GameObject StartWayP;
    public GameObject EndWayP;
    public int Direction; // 0 = Moving towards the ending waypoint, 1 = moving towards the start waypoint.
    public float Proximity;

    // Start is called before the first frame update
    void Start()
    {
        Direction = 0;
        transform.position = StartWayP.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToTargetWayP = 0.0f;
        GameObject target = null;
        if (Direction == 0)
            
        {
            target = EndWayP;
        } else
        {
            target = StartWayP;
        }
        DistanceToTargetWayP = (target.transform.position - transform.position).magnitude;
        if (DistanceToTargetWayP <= Proximity)
        {
            if (Direction == 0)
            {
                Direction = 1;
            } else
            {
                Direction = 0;
            }
        }

        // get the direction towards the target waypoint
        Vector3 directionToTarget = Vector3.zero;
        if (Direction == 0)
        {
            directionToTarget = EndWayP.transform.position - transform.position;
        } else
        {
            directionToTarget = StartWayP.transform.position - transform.position;
        }
        //normalize the vector to control the speed
        directionToTarget = directionToTarget.normalized;

        //multiply by speed
        directionToTarget *= Speed * Time.deltaTime;

        GetComponent<Rigidbody2D>().AddForce(directionToTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BatAttack")
        {
            Destroy(gameObject);
        }
    }


}
