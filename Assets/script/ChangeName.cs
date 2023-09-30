using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeName : MonoBehaviour
{
    public TextMeshProUGUI name; 
    void Update()
    {
        GetIndex();
    }
    void GetIndex()
    {
        switch(GetComponent<Dialogue>().c)
        {
            case 0:
                switch(GetComponent<Dialogue>().index)
                {
                    case 15:
                        name.text = "皢銘";
                        break;
                    case 18:
                        name.text = "皢銘";
                        break;
                    case 14:
                        name.text = "我";
                        break;
                    case 16:
                        name.text = "我";
                        break;
                    case 17:
                        name.text = "我";
                        break;
                    case 19:
                        name.text = "我";
                        break;
                    default:
                        break;    
                }
                break;
            case 1:
                switch(GetComponent<Dialogue>().index)
                {
                    case 14:
                        name.text = "皢銘";
                        break;
                    case 15:
                        name.text = "皢銘";
                        break;
                    case 18:
                        name.text = "皢銘";
                        break;
                    case 13:
                        name.text = "我";
                        break;
                    case 16:
                        name.text = "我";
                        break;
                    case 17:
                        name.text = "我";
                        break;
                    case 19:
                        name.text = "我";
                        break;    
                    default:
                        break;    
                }
                break;
            case 2:
                switch(GetComponent<Dialogue>().index)
                {
                    case 18:
                        name.text = "皢銘";
                        break;
                    case 19:
                        name.text = "皢銘";
                        break;
                    case 20:
                        name.text = "皢銘";
                        break;
                    case 16:
                        name.text = "我";
                        break;
                    case 17:
                        name.text = "我";
                        break;
                    case 22:
                        name.text = "我";
                        break;
                    case 21:
                        name.text = "我";
                        break;    
                    default:
                        break;    
                }
                break;
            case 3:
                switch(GetComponent<Dialogue>().index)
                {
                    case 7:
                        name.text = "皢銘";
                        break;
                    case 5:
                        name.text = "我";
                        break;
                    case 6:
                        name.text = "我";
                        break;   
                    default:
                        break;    
                }
                break;
            case 4:
                switch(GetComponent<Dialogue>().index)
                {
                    case 13:
                        name.text = "皢銘";
                        break;
                    case 14:
                        name.text = "我";
                        break;    
                    default:
                        break;    
                }
                break;
            case 5:
                switch(GetComponent<Dialogue>().index)
                {
                    case 19:
                        name.text = "皢銘";
                        break;
                    case 20:
                        name.text = "皢銘";
                        break;
                    case 23:
                        name.text = "皢銘";
                        break;
                    case 25:
                        name.text = "皢銘";
                        break;
                    case 26:
                        name.text = "皢銘";
                        break;
                    case 18:
                        name.text = "我";
                        break;
                    case 21:
                        name.text = "我";
                        break;
                    case 22:
                        name.text = "我";
                        break;
                    case 24:
                        name.text = "我";
                        break;    
                    default:
                        break;    
                }
                break;
            default:
                break;
        }
    }
}
