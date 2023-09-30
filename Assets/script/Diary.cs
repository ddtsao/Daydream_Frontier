using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diary : MonoBehaviour
{
    public TextMeshProUGUI name;
    public List<GameObject> dialogBox;
    public GameObject DB;
    public GameObject Light;
    public AudioSource As;
    void Update() 
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        name.text = "日記";
        As.Play();
        GameObject.Find("DialogBox").GetComponent<Dialogue>().enabled = true;
        dialogBox[0].SetActive(true);
        Light.SetActive(false);
        StartCoroutine(StartDialogue());
        GameObject.Find("DialogBox").GetComponent<Dialogue>().enabled = true;
    }
    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(3f);
        dialogBox[1].SetActive(true);
        GameObject.Find("DialogBox").GetComponent<Dialogue>().StartDialogue();
        dialogBox[2].SetActive(true);
        this.gameObject.SetActive(false);
    }
}
