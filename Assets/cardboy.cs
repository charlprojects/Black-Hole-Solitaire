using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class cardboy : MonoBehaviour
{
    private bool moving = false;
    public GameObject targetCard;
    public void mouseclicker()
    {
        Debug.Log("We got em'");
        moving = true; 
    }
    // Start is called before the first frame update
    void Update()
    {
        if (moving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetCard.transform.position, 850f * Time.deltaTime);
            if (transform.position == targetCard.transform.position)
            {
                moving = false;
            }
        }
    }
    void Start()
    {
        
    }
}
