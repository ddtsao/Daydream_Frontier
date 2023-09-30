using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureBox : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public Sprite BoxSprite;
    public GameObject Go;
    public GameObject Go_2;
    public GameObject Go_3;
    public GameObject Go_4;
    public List<Animator> anim;
    private bool AudioPlayed = false;
    private bool isOpened = false;
    private bool isOpened_wolf = false;
    public int InArea = 0;
    public int button_pos;

    private void Update() 
    {
        if(GetComponent<Dialogue>() != null)
        {
            if(SceneManager.GetActiveScene().name == "SampleScene")
            {
                if(GetComponent<Dialogue>().Page.activeSelf)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }            
    }
    void checkVoidPosition()
    {
        for (int n = 0; n < GameObject.Find("Menu").GetComponent<CharacterMenu>().itemSprite.Count; n++)
        {
            if(GameObject.Find("Menu").GetComponent<CharacterMenu>().itemSprite[n].GetComponent<Image>().sprite == null)
            {
                button_pos = n;
            }
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == ("MainCharacter"))
        {
            if(this.gameObject.name == "TreasureBox")
            {
                if(!isOpened)
                {
                    GetComponent<SpriteRenderer>().sprite = BoxSprite;
                    GameManager.instance.updateMenuSp(2, 1);
                    GameManager.instance.updateMenuSkill(0,2);
                    GameManager.instance.updateMenuSkill(1,6);
                    Go.SetActive(false);
                    anim[1].SetTrigger("play_light");
                    isOpened = true;
                    if(!AudioPlayed)
                    {
                        audioSource.Play();
                        AudioPlayed = true;
                    }
                    else
                    {
                        audioSource.enabled = false;
                    }
                }
            }
            if(this.gameObject.name == "TreasureBox_Wolf")
            {
                if(!isOpened_wolf)
                {
                    GetComponent<SpriteRenderer>().sprite = BoxSprite;
                    GameManager.instance.updateMenu(15, 0);
                    GameManager.instance.updateMenuItem(2, 3);
                    GameManager.instance.updateMenuSp(15, 1);
                    GameManager.instance.updateMenuSkill(2,7);
                    isOpened_wolf = true;
                    if(!AudioPlayed)
                    {
                        audioSource.Play();
                        AudioPlayed = true;
                    }
                    else
                    {
                        audioSource.enabled = false;
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.name == "LadderTrigger")
        {
            InArea += 1;
            Go_3.SetActive(false);
            if(GameObject.Find("StoneTrigger").GetComponent<Dialogue>().enabled == false && GameObject.Find("Billboard_Go (1)").GetComponent<Dialogue>().enabled == false && GameObject.Find("Billboard_Go (2)").GetComponent<Dialogue>().enabled == false)
            {
                Debug.Log("n");
                this.GetComponent<Dialogue>().enabled = true;
                Go_4.SetActive(true);
                this.gameObject.GetComponent<Dialogue>().StartDialogue();
                if(GetComponent<Dialogue>().c >= 1)
                {
                    Debug.Log("P");
                    Go_4.SetActive(false);
                    this.GetComponent<Dialogue>().enabled = false;
                }
            }
        }
        else if(this.gameObject.name == "StoneTrigger")
        {
            this.GetComponent<Dialogue>().enabled = true;
            Go.SetActive(true);
            this.gameObject.GetComponent<Dialogue>().StartDialogue();
            GameManager.instance.updateMenuItem(3, 4);
            Go_2.SetActive(false);
            Go_3.SetActive(true);
            Go_4.SetActive(false);
            anim[1].SetTrigger("play_light");
        }
        else if(this.gameObject.name == "WindTrigger")
        {
            audioSource.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(this.gameObject.name == "TombTrigger")
        {
            audioSource.Play();
            audioSource2.mute = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void OnTriggerEnterExit2D(Collider2D col)
    {
        if(this.gameObject.name == "LadderTrigger")
        {
            InArea = 0;
        }
    }
    public void ChangeLadder()
    {
        float x = GameObject.Find("MainCharacter").transform.position.x;
        float y = GameObject.Find("MainCharacter").transform.position.y;
        if(-0.993f > x && x > -1.424f && -0.484f > y && y > -0.818)
        {
            Debug.Log("d");
            Go.SetActive(true);
            Go_2.SetActive(false);
        }
    }
}
