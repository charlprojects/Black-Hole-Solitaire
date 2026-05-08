using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class cardboy : MonoBehaviour
{
    private bool moving = false;
    public GameObject targetCard;
    public int cardNum = 0;
    public int group = 0;
    public GameObject logicthing;
    public void mouseclicker()
    {
        int count = 0;
        List<List<int>> cardNumList = logicthing.GetComponent<cardspawner>().cardNumList;
        Debug.Log(cardNum);
        Debug.Log(cardNumList[this.group].Count);
        if (cardNum == cardNumList[this.group].Count)
        {
            logicthing.GetComponent<cardspawner>().cardNumList.RemoveAt(cardNum);
            moving = true;
            this.transform.SetAsLastSibling();

        }



    }
    // Start is called before the first frame update
    void Update()
    {
        if (moving == true)
        {
            //Debug.Log("hello");
            transform.position = Vector2.MoveTowards(transform.position, targetCard.transform.position, 850f * Time.deltaTime);
            //Debug.Log("CURRENT: " + transform.position);
            //Debug.Log("TARGET: " + targetCard.transform.position);
            if (transform.position == targetCard.transform.position)
            {
                moving = false;
                //Debug.Log("We made it false uh oh");
            }
        }
    }
    void Start()
    {
        
    }
}
