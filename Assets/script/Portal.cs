using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class Portal : MonoBehaviour
{
    public List<string> SceneName;
    public List<GameObject> DontDestroys;
    public List<AudioSource> audioSources;
    public Tilemap tilemap;
    private bool AudioPlayed = false;
    private void Update() 
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "MainCharacter")
        {
            if(this.gameObject.name == "Portal")
            {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
                GameObject.Find("Portal").GetComponent<AudioSource>().Play();
                GameObject.Find("MainCharacter").GetComponent<Movement>().InPortal = true;
                GameManager.instance.showTxt("!",45,Color.red,(FontStyles)FontStyle.Bold,transform.position,Vector3.zero,1.5f);
                Invoke("loadScene", 2.5f);
            }
            else if(this.gameObject.name == "TestPortal")
            {
                SceneManager.LoadScene("Win");
                DontDestroyOnLoad(DontDestroys[0]);
                DontDestroyOnLoad(DontDestroys[1]);
                DontDestroyOnLoad(DontDestroys[2]);
                DontDestroyOnLoad(DontDestroys[3]);
                DontDestroyOnLoad(DontDestroys[4]);
                DontDestroyOnLoad(DontDestroys[5]);
                DontDestroyOnLoad(DontDestroys[6]);
                int player_hp = GameManager.instance.Hp_Player;
                PlayerPrefs.SetInt("Hp_Player", player_hp);
                int player_sp = GameManager.instance.Sp_Player;
                PlayerPrefs.SetInt("Sp_Player", player_sp);//這些是要刪掉的
            }
            else if(this.gameObject.name == "SchoolPortal")
            {
                StartCoroutine(LoadSceneSchool());
            }
            else if(this.gameObject.name == "BossPortal")
            {
                DontDestroys[0].SetActive(true);
                GameObject.Find("Boss").GetComponent<Animator>().SetTrigger("play");
                StartCoroutine(LoadSceneBoss());
            }
        }
    }
    IEnumerator LoadSceneBoss()
    {
        yield return new WaitForSeconds(1.45f);
        audioSources[0].Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Boss");
        yield return null;
    }
    IEnumerator LoadSceneSchool()
    {
        audioSources[0].Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("School");
        yield return null;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "MainCharacter")
        {
            if(this.gameObject.name == "Teleport")
            {
                StartCoroutine(DoorAudio());
            }
        }
    }
    IEnumerator DoorAudio()
    {
        audioSources[1].GetComponent<AudioSource>().volume = 0.2f;
        if(!AudioPlayed)
        {
            audioSources[0].Play();
            AudioPlayed = true;
        }
        else
        {
            audioSources[0].enabled = false;
        } 
        yield return new WaitForSeconds(2f);
        Debug.Log("dh");
        tilemap.GetComponent<TilemapRenderer>().enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Corridor");
        yield return null;
    }
    public void loadScene()
    {
        SceneManager.LoadScene(SceneName[0]);
        DontDestroyOnLoad(DontDestroys[0]);
        DontDestroyOnLoad(DontDestroys[1]);
        DontDestroyOnLoad(DontDestroys[2]);
        DontDestroyOnLoad(DontDestroys[3]);
        DontDestroyOnLoad(DontDestroys[4]);
        DontDestroyOnLoad(DontDestroys[5]);
        int player_hp = GameManager.instance.Hp_Player;
        PlayerPrefs.SetInt("Hp_Player", player_hp);
        int player_sp = GameManager.instance.Sp_Player;
        PlayerPrefs.SetInt("Sp_Player", player_sp);
    }
}
