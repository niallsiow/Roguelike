using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorTriggerBehaviour : MonoBehaviour
{

    public Vector2 displacement;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // move the camera to the new room position
            Camera.main.transform.position += new Vector3(displacement.x, displacement.y, 0);
            

            GameObject parentRoom = transform.parent.gameObject;

            Vector3 newRoomPosition = parentRoom.transform.position + new Vector3(displacement.x, displacement.y, 0);
            
            // find new room from List of existing rooms by comparing new room position with position of all rooms
            for(int i = 0; i < References.rooms.Count; i++)
            {
                if(References.rooms[i].transform.position == newRoomPosition)
                {
                    parentRoom.GetComponent<RoomBehaviour>().DisableRoom();
                    References.rooms[i].GetComponent<RoomBehaviour>().EnableRoom();
                }
            }


        }
    }
}
