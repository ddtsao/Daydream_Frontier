using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
public class positionTest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler
{
    public TextMeshProUGUI Test_texts;
    public TextMeshProUGUI Test_texts2;
    public void OnPointerDown(PointerEventData eventData)
    {
        string s = eventData.position.x.ToString();
        Test_texts.text = s;
        string s2 = eventData.position.y.ToString();
        Test_texts2.text = s2;
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
