using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class HpRune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler
{
    public float MouseOutOfButton = 0; //離開按鈕記數
    public float onLongClickCount = 0;//只能使用一次
    public float[] PressDownPos;
    private bool PressDown; //按下
    public bool isFailed;
    public List<RectTransform> button;
    public UnityEvent onLongClick; //開啟Inspector觸發事件
    public UnityEvent FailToHeal;
  public float HoldTime;
  //按下按鈕
  public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            return;
        }
        if(PressDownPos.Length == 0)
        {
            return;
        }
        else if((eventData.position.x - PressDownPos[1]) / ( PressDownPos[0] - eventData.position.x) < 0 || (eventData.position.y - PressDownPos[3]) / (PressDownPos[2] - eventData.position.y) < 0)
        {
            Debug.Log("8");
            FailToHeal.Invoke();
            isFailed = true;
        }
        Debug.Log(eventData.position);
    }
  //按鈕彈起
  public void OnPointerUp(PointerEventData eventData){
    if(button[0].position != button[1].position)
    {
      Debug.Log("fail");
        FailToHeal.Invoke();
        MouseOutOfButton = 0;
    }
    else if(button[0].position == button[1].position && !isFailed)
    {
        if(onLongClickCount >= 1)
        {
            return;
        }
        onLongClick.Invoke();
        onLongClickCount += 1;
    }
  }
  public void OnPointerExit(PointerEventData eventData){
    MouseOutOfButton += 1;
    if(MouseOutOfButton >= 100000)
    {
        FailToHeal.Invoke();
        MouseOutOfButton = 0;
    }
  }
  //當按下按鈕 PressDown = true 時計時
  void Update(){
  }
}