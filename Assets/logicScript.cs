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

    void createCard(int x,int y)  
    {
        GameObject cardInstance = Instantiate(Card, new Vector2(x, y), transform.rotation);
        cardInstance.transform.SetParent(canvas.transform);
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
        for (int vertical = 0; vertical < 4; vertical++)
        {
            for (int horizontal = 0; horizontal < 5; horizontal++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!(((vertical == 1 && horizontal==2)) || (((vertical == 2 && horizontal == 2))) || (((vertical == 3 && horizontal == 4) ))))
                    {
                        createCard(startX + i * threegap + horizontal * horizontalGap, height - startY - vertical * verticalGap);

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
