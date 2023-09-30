using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<AudioSource> ass;

    public void OpenDoor()
    {
        if((GameObject.Find("MainCharacter").transform.position.x - 0.841f) / (1.004f - GameObject.Find("MainCharacter").transform.position.x) > 0 || (GameObject.Find("MainCharacter").transform.position.y - 3.359f) / (3.472f - GameObject.Find("MainCharacter").transform.position.y) > 0)
        {
            Debug.Log("jdis");
            ass[0].Play();
            GameObject.Find("Block").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Block2").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("RoomObj").GetComponent<ShoeRoom>().room.SetActive(true);
            GameObject.Find("RoomObj").GetComponent<ShoeRoom>().wall.SetActive(false);
        }
    }
}