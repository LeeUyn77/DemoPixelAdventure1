using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curWayPointIndex=0;

    [SerializeField] private float speed =2f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(waypoints[curWayPointIndex].transform.position,transform.position)<.1f){
            curWayPointIndex++;
            if(curWayPointIndex>=waypoints.Length)
                curWayPointIndex=0;
        }
        transform.position= Vector2.MoveTowards(transform.position,waypoints[curWayPointIndex].transform.position,Time.deltaTime* speed);
    }
}
