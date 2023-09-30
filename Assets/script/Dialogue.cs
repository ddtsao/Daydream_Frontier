using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI texts;
    public TextMeshProUGUI name;
    public List<string> LinesPartOne;
    public List<string> LinesPartTwo;
    public List<string> LinesPartThree;
    public List<string> LinesPartFour;
    public List<string> LinesPartFive;
    public List<string> LinesPartSix;
    public GameObject Page;
    public GameObject Block;
    public GameObject Go;
    public GameObject isLines;
    public AudioSource AS;
    public float speed;
    public int index = 0;
    public int c = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLines();
    }
    public void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }
    public void CheckLines()
    {
        if(isLines.activeSelf)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(c == 0)
                {
                    if(texts.text == LinesPartOne[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartOne[index];
                    }

                    if(texts.text == "告示牌上面寫著「市民花園」…" || texts.text == "整修日期…我看看…這不是快十年前了嗎?" || texts.text == "我還納悶為何這裡那麼破舊，用「年久失修」來形容也不為過吧")
                    {
                        name.text = "我";
                    }
                }
                else if(c == 1)
                {
                    if(texts.text == LinesPartTwo[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartTwo[index];
                    }
                }
                else if(c == 2)
                {
                    if(texts.text == LinesPartThree[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartThree[index];
                    }
                }
                else if(c == 3)
                {
                    if(texts.text == LinesPartFour[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartFour[index];
                    }
                }
                else if(c == 4)
                {
                    if(texts.text == LinesPartFive[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartFive[index];
                    }
                }
                else if(c >= 5)
                {
                    if(texts.text == LinesPartSix[index])
                    {
                        AS.Play();
                        StartCoroutine(NextLine());
                    }
                    else
                    {
                        AS.Play();
                        StopAllCoroutines();
                        texts.text = LinesPartSix[index];
                    }
                }
            }
        }
        
    }
    IEnumerator TypeLine()
    {
        if(c == 0)
        {
            foreach (char c in LinesPartOne[index].ToCharArray())
            {
                if(this.gameObject.name == "Billboard_Go (2)")
                {
                    if(index == 2 || index == 4 || index == 5)
                    {
                        name.text = "皢銘";
                    }
                    else
                    {
                        name.text = "我";
                    }
                }
                else if(this.gameObject.name == "StoneTrigger")
                {
                    if(index == 0)
                    {
                        name.text = "皢銘";
                    }
                    else
                    {
                        name.text = "我";
                    }
                }
                else if(this.gameObject.name == "LadderTrigger")
                {
                    if(index == 3 || index == 4)
                    {
                        name.text = "皢銘";
                    }
                    else
                    {
                        name.text = "我";
                    }
                }
                else if(this.gameObject.name == "Block")
                {
                    if(index == 1 || index == 2)
                    {
                        name.text = "皢銘";
                    }
                    else
                    {
                        name.text = "我";
                    }
                }
                else if(this.gameObject.name == "Oil (1)")
                {
                    if(index == 0 || index == 2)
                    {
                        name.text = "皢銘";
                    }
                    else
                    {
                        name.text = "我";
                    }
                }
                texts.text += c;
                yield return new WaitForSeconds(speed);
            }
        }
        else if(c == 1)
        {
            if(LinesPartTwo.Count == 0)
            {
                yield return null;
            }
            else
            {
                foreach (char c in LinesPartTwo[index].ToCharArray())
                {
                    texts.text += c;
                    yield return new WaitForSeconds(speed);
                }
            }
        }
        else if(c == 2)
        {
            foreach (char c in LinesPartThree[index].ToCharArray())
            {
                texts.text += c;
                yield return new WaitForSeconds(speed);
            }
        }
        else if(c == 3)
        {
            foreach (char c in LinesPartFour[index].ToCharArray())
            {
                texts.text += c;
                yield return new WaitForSeconds(speed);
            }
        }
        else if(c == 4)
        {
            foreach (char c in LinesPartFive[index].ToCharArray())
            {
                texts.text += c;
                yield return new WaitForSeconds(speed);
            }
        }
        else if(c >= 5)
        {
            foreach (char c in LinesPartSix[index].ToCharArray())
            {
                texts.text += c;
                yield return new WaitForSeconds(speed);
            }
        }
        else
        {
            yield return null;
        }
    }
    IEnumerator NextLine()
    {   
        if(c == 0)
        {
            if(index < LinesPartOne.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        else if(c == 1)
        {
            if(index < LinesPartTwo.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        else if(c == 2)
        {
            if(index < LinesPartThree.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        else if(c == 3)
        {
            if(index < LinesPartFour.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        else if(c == 4)
        {
            if(index < LinesPartFive.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        else if(c >= 5)
        {
            if(index < LinesPartSix.Count - 1)
            {
                index += 1;
                texts.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                Page.SetActive(false);
                Block.SetActive(false);
                Go.SetActive(false);
                texts.text = string.Empty;
                index = 0;
                c++;
                GetComponent<Dialogue>().enabled = false;
            }
        }
        yield return null;
    }
}
