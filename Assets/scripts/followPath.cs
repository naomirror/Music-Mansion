using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{
    float walkspeed = 1f;
    public Transform[] waypoints;
    int currentWaypoint = 0;
    int targetWaypoint;
    int nextWaypoint;
    // Use this for initialization
    void Start()
    {
        transform.position = waypoints[currentWaypoint].position;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (currentWaypoint != targetWaypoint)
        //{
            move();
       // }
    }

    void move()
    {
        print("cur" + currentWaypoint);
        print("tar" + targetWaypoint);
        print("nex" + nextWaypoint);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit)
            {
                print(hit.collider.gameObject.name);
                for (int i = 0; i < waypoints.Length; i++)
                {
                    if (waypoints[i].position == hit.collider.gameObject.transform.position)
                    {
                        targetWaypoint = i;
                        break;
                    }
                }
            }
        }
        if (targetWaypoint > currentWaypoint)
        {
            if (currentWaypoint == nextWaypoint && currentWaypoint != targetWaypoint)
            {
                nextWaypoint = currentWaypoint + 1;
            }
            if (this.transform.position == waypoints[nextWaypoint].position)
            {
                print("node");
                currentWaypoint = nextWaypoint;
                nextWaypoint = nextWaypoint + 1;
            }
            if (currentWaypoint != targetWaypoint)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[nextWaypoint].transform.position,
                walkspeed * Time.deltaTime);
            }
            if (transform.position == waypoints[targetWaypoint].position)
            {
                currentWaypoint = targetWaypoint;
                
            }
        }

        else if (targetWaypoint < currentWaypoint)
        {
            if (currentWaypoint == nextWaypoint && currentWaypoint != targetWaypoint)
            {
                nextWaypoint = currentWaypoint - 1;
            }
            if (this.transform.position == waypoints[nextWaypoint].position)
            {
                print("node");
                currentWaypoint = nextWaypoint;
                nextWaypoint = nextWaypoint - 1;
            }
            if (currentWaypoint != targetWaypoint)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[nextWaypoint].transform.position,
                walkspeed * Time.deltaTime);
            }
            if (transform.position == waypoints[targetWaypoint].position)
            {
                currentWaypoint = targetWaypoint;

            }
        }
    }
}
