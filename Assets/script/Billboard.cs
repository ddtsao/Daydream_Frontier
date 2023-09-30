using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Billboard : MonoBehaviour
{
    public GameObject Blocking;
    public Animator anim1;
    public List<GameObject> dialogues;

    private void Update()
    {
        if(GetComponent<Dialogue>() != null)
        {
            if(SceneManager.GetActiveScene().name == "SampleScene")
            {
               if(GetComponent<Dialogue>().Page.activeSelf)
                {
                    GameObject.Find("Billboard_Go (1)").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("StoneTrigger").GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    GameObject.Find("Billboard_Go (1)").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("StoneTrigger").GetComponent<BoxCollider2D>().enabled = true;
                } 
            }
            else if(SceneManager.GetActiveScene().name == "Corridor")
            {
                if(GetComponent<Dialogue>().Page.activeSelf)
                {
                    GameObject.Find("Block").GetComponent<BoxCollider2D>().enabled = false;
                }
                else if(GameObject.Find("RoomObj").GetComponent<ShoeRoom>().room.activeSelf)
                {
                    Debug.Log("S");
                    GameObject.Find("Block").GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    GameObject.Find("Block").GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.name == "Billboard_Go")
        {
            if(Blocking != null)
            {
                Blocking.SetActive(false);
            }
            anim1.SetTrigger("play_billboard");
        }
        else if(this.gameObject.name == "Billboard_Go (1)")
        {
            dialogues[1].GetComponent<Dialogue>().enabled = false;
            GetComponent<Dialogue>().enabled = true;
            GetComponent<Dialogue>().Page.SetActive(true);
            GetComponent<Dialogue>().StartDialogue();
        }
        else if(this.gameObject.name == "Billboard_Go (2)")
        {
            dialogues[0].GetComponent<Dialogue>().enabled = false;
            GetComponent<Dialogue>().enabled = true;
            GetComponent<Dialogue>().Page.SetActive(true);
            GetComponent<Dialogue>().StartDialogue();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(this.gameObject.name == "Block")
        {
            GetComponent<Dialogue>().enabled = true;
            GetComponent<Dialogue>().Page.SetActive(true);
            GetComponent<Dialogue>().StartDialogue();
        }
        else if(this.gameObject.name == "Oil (1)")
        {
            GetComponent<Dialogue>().enabled = true;
            GetComponent<Dialogue>().Page.SetActive(true);
            GetComponent<Dialogue>().StartDialogue();
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.instance.updateMenuItem(4, 5);
            GameObject.Find("Backpack").GetComponent<Animator>().SetTrigger("play_light");
        }
    }
    public void StopMoving()
    {
        GameObject.Find("MainCharacter").GetComponent<Movement>().InPortal = true;
    }
    public void StartMoving()
    {
        GameObject.Find("MainCharacter").GetComponent<Movement>().InPortal = false;
    }
}
