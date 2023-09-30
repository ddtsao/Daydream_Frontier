using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    public List<GameObject> Maintain;
    public bool isLight = false;
    public void SwapToGarden()
    {
        DontDestroyOnLoad(Maintain[0]);
        SceneManager.LoadScene("Win");
    }
    public void SwapToCorridor()
    {
        isLight = true;
        DontDestroyOnLoad(Maintain[0]);
        SceneManager.LoadScene("Corridor");
    }
    public void SwapToSchool()
    {
        DontDestroyOnLoad(Maintain[0]);
        SceneManager.LoadScene("School");
    }
}
