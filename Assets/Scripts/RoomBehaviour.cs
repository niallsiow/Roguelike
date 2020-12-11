using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{

    // bool isActiveRoom;

    public bool startRoom;

    // Start is called before the first frame update
    void Start()
    {
        DisableRoom();
        if(startRoom == true)
        {
            EnableRoom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // open doors when all enemies dead
        if(References.enemies.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject door = transform.GetChild(i).gameObject;

                if (door.tag == "Door")
                {
                    door.SetActive(false);
                }
            }
        }
    }


    public void EnableRoom()
    {
        // enable enemy spawners
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject enemySpawner = transform.GetChild(i).gameObject;

            if (enemySpawner.tag == "EnemySpawner")
            {
                enemySpawner.SetActive(true);
            }
        }

        // enable door triggers for this room
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject doorTrigger = transform.GetChild(i).gameObject;

            if (doorTrigger.tag == "DoorTrigger")
            {
                doorTrigger.SetActive(true);
            }
        }

        // enable doors
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject door = transform.GetChild(i).gameObject;

            if (door.tag == "Door")
            {
                door.SetActive(true);
            }
        }
    }


    public void DisableRoom()
    {
        // disable door triggers
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject doorTrigger = transform.GetChild(i).gameObject;

            if (doorTrigger.tag == "DoorTrigger")
            {
                doorTrigger.SetActive(false);
            }
        }

        // disable enemy spawners
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject enemySpawner = transform.GetChild(i).gameObject;

            if (enemySpawner.tag == "EnemySpawner")
            {
                enemySpawner.SetActive(false);
            }
        }

        // disable doors
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject door = transform.GetChild(i).gameObject;

            if (door.tag == "Door")
            {
                door.SetActive(false);
            }
        }
    }


    public void DestroyDoor(string alignment)
    {

        Vector3 doorPosition = new Vector3(0, 0, 0);

        if(alignment == "Left")
        {
            doorPosition = new Vector3(-8.5f, 0, 0);
        }
        if(alignment == "Right")
        {
            doorPosition = new Vector3(8.5f, 0, 0);
        }
        if(alignment == "Top")
        {
            doorPosition = new Vector3(0, 5.5f, 0);
        }
        if(alignment == "Bottom")
        {
            doorPosition = new Vector3(0, -5.5f, 0);
        }

        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject door = transform.GetChild(i).gameObject;

            if(door.tag == "Door" && door.transform.localPosition == doorPosition)
            {
                Destroy(door);
            }
        }
    }
    /*
    // draw green gizmo if room is active, red gizmo if inactive
    private void OnDrawGizmos()
    {
        if(isActiveRoom == false)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 2f);
        }

        if(isActiveRoom == true)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 2f);
        }
    }
    */
}
