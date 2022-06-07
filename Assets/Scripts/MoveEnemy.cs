using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public int targetWaypoint;
    public List <GameObject> wayPoints = new List<GameObject> ();
    // Start is called before the first frame update
    void Start()
    {

        targetWaypoint = 1;
        transform.position = wayPoints[0].transform.position;
        



    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
