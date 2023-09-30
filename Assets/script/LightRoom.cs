using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoom : MonoBehaviour
{
    public List<GameObject> lights;
    private void Update() 
    {
        ChangeLight();    
    }
    void ChangeLight()
    {
        if((GameObject.Find("MainCharacter").transform.position.x - 1.193f) / (2.163f - GameObject.Find("MainCharacter").transform.position.x) > 0 && (GameObject.Find("MainCharacter").transform.position.y - 3.032f) / (3.970f - GameObject.Find("MainCharacter").transform.position.y) > 0)
        {
            Debug.Log("P");
            lights[0].SetActive(false);
            lights[1].SetActive(true);
        }
        else
        {
            lights[0].SetActive(true);
            lights[1].SetActive(false);
        }
    }
}
