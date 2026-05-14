using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

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
        int targetValue = logicthing.GetComponent<cardspawner>().targetValue;
        Debug.Log("THIS IS THE VALUE OF target" + targetValue);
        string cardValueString = this.GetComponent<Image>().sprite.ToString();
        int newValue = int.Parse(System.Text.RegularExpressions.Regex.Match(cardValueString, @"\d+").Value);
        Debug.Log("I HAVE FOUND NEW CARD: " + newValue);
        Debug.Log("new original card string" + cardValueString);
        Dictionary<int,int[]> legalValues = new Dictionary<int, int[]>()
        {
            {1,  new int[] {13, 2 } },
            {2,  new int[] {1, 3} },
            {3,  new int[] {2, 4} },
            {4,  new int[] {3, 5} },
            {5,  new int[] {4, 6} },
            {6,  new int[] {5, 7} },
            {7,  new int[] {6, 8} },
            {8,  new int[] { 7, 9 } },
            {9,  new int[] {8, 10} },
            {10, new int[] {9, 11} },
            {11, new int[] {10, 12} },
            {12, new int[] {11, 13} },
            {13, new int[] {12, 1} },
        };
        
        if (cardNum == cardNumList[this.group].Count - 1 &&
            legalValues[targetValue].Contains(newValue))
        {
            moving = true;
            this.transform.SetAsLastSibling();
            cardNumList[this.group].RemoveAt(cardNum);
            logicthing.GetComponent<cardspawner>().targetValue = newValue;
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
