using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class cardspawner : MonoBehaviour
{
    [SerializeField] public Sprite[] cardsList;
    public Canvas canvas;
    public int cardsX;
    public int cardsY;
    public GameObject Card;
    public int rows = 4;
    public int cols = 4;
    public Vector2[,] cardGrid;
    public List<string> myList = new List<string>();
    public Sprite[] cardFaces;
    public List<int> cardNums = new List<int>();
    public int cardIndex = 0;
    public List<List<int>> cardNumList = new List<List<int>>();
    public int targetValue = 1;

    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            T temp = inputList[i];
            int randomIndex = UnityEngine.Random.Range(i, inputList.Count);
            inputList[i] = inputList[randomIndex];
            inputList[randomIndex] = temp;
        }
    }
    void createCard(int x,int y, int cardNum, int group)  
    {
        GameObject cardInstance = Instantiate(Card, new Vector2(x, y), transform.rotation);
        cardInstance.transform.SetParent(canvas.transform);
        Image guiImage = cardInstance.GetComponent<Image>();
        //Debug.Log(cardIndex);
        Debug.Log(cardIndex);
        Sprite epicSprite = cardFaces[cardNums[cardIndex]];

        guiImage.sprite = epicSprite;
        cardIndex++;
        cardboy cardStuff = cardInstance.GetComponent<cardboy>();
        cardStuff.cardNum = cardNum;
        cardStuff.group = group;
        Debug.Log($"cardNum: {cardNum}, group: {group}");
        List<int> currentList = cardNumList[group];
        //currentList.Add(cardNum);

        //cardStuff.cardNumList = cardNumList[group];
        //cardStuff.cardNumList = 0;

        //int cardNum = 0;
        //if (i == 0)
        //{
        //    cardNum = 1;
        //}
        //else if (i == 1)
        //{
        //    cardNum = 2;
        //}
        //else if (i == 2)
        //{
        //    cardNum = 0;
        //}
        //Debug.Log("WE DID IT");

    }
    // Start is called sbefore the first frame update
    void Start()
    {
        int height = 720;
        int width = 1280;
        int startX = 210;
        int startY = 150;
        int threegap = 25;
        int horizontalGap = 200;
        int verticalGap = 150;
        for (int i = 0; i < 51; i++)
        {
            cardNums.Add(i);
        }
        Shuffle(cardNums);

        for (int i = 0; i < 17; i++)
        {
            cardNumList.Add(new List<int>());
            List<int> current = cardNumList[i];
            for (int j = 0; j < 3; j++)
            {
                current.Add(i*j + i);
            }
        }

        int skips = 0;
        for (int vertical = 0; vertical < 4; vertical++)
        {
            for (int horizontal = 0; horizontal < 5; horizontal++)
            {
                for (int i = 0; i < 3; i++)
                {
                    
                    if (!(((vertical == 1 && horizontal == 2)) || (((vertical == 2 && horizontal == 2))) || (((vertical == 3 && horizontal == 4)))))
                    {

                        int group = vertical * 5 + horizontal - skips/3;
                        //Debug.Log("GROUP: " + group);

                        createCard(startX + i * threegap + horizontal * horizontalGap,
                            height - startY - vertical * verticalGap,
                            i,
                            group);

                    } else
                    {
                        skips++;

                        //Debug.Log("SKIP: " + skips);
                    }
                }
            }
        }


        //cardGrid = new Vector2[rows, cols];
        //reset();
        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {

        //        GameObject cardInstance = Instantiate(Card, cardGrid[i, j], transform.rotation);
        //        cardInstance.transform.SetParent(canvas.transform);

        //        // Image guiImage = cardInstance.AddComponent<Image>();

        //        // 3. Assign the Sprite asset
        //        //guiImage.sprite = Resources.Load<Sprite>("Assets/Memory Game Cards/Memory_Game_Circle.png");
        //    }
        //}
        //Debug.Log(cardsList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //reset();
    }

    public void reset()
    {
        int originalX = 100;
        int originalY = 30;

        int width = 150;
        int height = 200;
        int gap = 20;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int x = originalX + width * i + gap;
                int y = originalY + height * j + gap;
                //Debug.Log("---\n");
                //Debug.Log(x.ToString() + ", " + y.ToString());
                cardGrid[i, j] = new Vector2(x, y);
            }
        }
    }
}
