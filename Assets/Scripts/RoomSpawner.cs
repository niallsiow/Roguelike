using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public GameObject startRoomPrefab;
    public GameObject[] normalRoomPrefabs;

    public GameObject verticalWallFillPrefab;
    public GameObject horizontalWallFillPrefab;

    float blockSize = 1f;

    List<Vector2> rooms = new List<Vector2>();

    int xDisplacement = 16;
    int yDisplacement = 10;

    Vector2 currentRoom;

    Vector2 startRoom = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {

        currentRoom = startRoom;
        rooms.Add(currentRoom);
        GameObject room = (GameObject)Instantiate(startRoomPrefab, currentRoom, transform.rotation);

        References.activeRoom = room;
        References.rooms.Add(room);

        DrawRooms();

        FillRooms(xDisplacement, 0);
        FillRooms(-xDisplacement, 0);
        FillRooms(0, yDisplacement);
        FillRooms(0, -yDisplacement);

        

    }

    void DrawRooms()
    {
        int numberOfRooms = Random.Range(4, 20);
        int roomIndex;
        for (int i = 0; i < numberOfRooms; i++)
        {
            while (rooms.Contains(currentRoom) == true)
            {
                int rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    currentRoom = currentRoom + new Vector2(xDisplacement, 0);
                }
                else if (rand == 1)
                {
                    currentRoom = currentRoom + new Vector2(0, yDisplacement);
                }
                else if (rand == 2)
                {
                    currentRoom = currentRoom + new Vector2(-xDisplacement, 0);
                }
                else if (rand == 3)
                {
                    currentRoom = currentRoom + new Vector2(0, -yDisplacement);
                }
            }

            rooms.Add(currentRoom);

            roomIndex = Random.Range(0, normalRoomPrefabs.Length);
            GameObject room = (GameObject)Instantiate(normalRoomPrefabs[roomIndex], currentRoom, transform.rotation);
            References.rooms.Add(room);
        }

     }


    void FillRooms(float x, float y)
    {
        GameObject wallFillPrefab;
        float xBlockDisplacement = blockSize / 2;
        float yBlockDisplacement = blockSize / 2;

        bool leftCheck = false, rightCheck = false;
        bool topCheck = false, bottomCheck = false;

        if(x != 0)
        {
            wallFillPrefab = horizontalWallFillPrefab;
            yBlockDisplacement = 0;
        }
        else
        {
            wallFillPrefab = verticalWallFillPrefab;
            xBlockDisplacement = 0;
        }

        if(x < 0)
        {
            xBlockDisplacement = xBlockDisplacement * -1;
            leftCheck = true;
        }
        else if(x > 0)
        {
            rightCheck = true;
        }
        if (y < 0)
        {
            yBlockDisplacement = yBlockDisplacement * -1;
            bottomCheck = true;
        }
        else if(y > 0)
        {
            topCheck = true;
        }

        bool containsRoom;

        for (int i = 0; i < References.rooms.Count; i++)
        {
            containsRoom = false;
            Vector3 currentRoomPosition = References.rooms[i].transform.position;
            Vector3 nextRoomPosition = currentRoomPosition + new Vector3(x, y, 0);

            for(int j = 0; j < References.rooms.Count; j++)
            {
                if(References.rooms[j].transform.position == nextRoomPosition)
                {
                    containsRoom = true;
                }
            }
            if (containsRoom == false)
            {
                if(leftCheck == true)
                {
                    References.rooms[i].GetComponent<RoomBehaviour>().DestroyDoor("Left");
                }
                if(rightCheck == true)
                {
                    References.rooms[i].GetComponent<RoomBehaviour>().DestroyDoor("Right");
                }
                if(topCheck == true)
                {
                    References.rooms[i].GetComponent<RoomBehaviour>().DestroyDoor("Top");
                }
                if(bottomCheck == true)
                {
                    References.rooms[i].GetComponent<RoomBehaviour>().DestroyDoor("Bottom");
                }
                Instantiate(wallFillPrefab, currentRoomPosition + new Vector3(x / 2 - xBlockDisplacement, y / 2 - yBlockDisplacement, 0), transform.rotation);
            }
            
        }
    }


}
