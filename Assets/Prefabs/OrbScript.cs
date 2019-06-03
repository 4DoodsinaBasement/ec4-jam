using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrbScript : MonoBehaviour
{
    public GameColor orbColor;
    public enum FoodStatus { hidden, visable, collected}
    public FoodStatus status; 
    
    // Start is called before the first frame update
    void Start()
    {
        status = FoodStatus.hidden;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnFood()
    {
        status = FoodStatus.visable;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Animator>().enabled = true;
    }

    public void EatFood()
    {
        Debug.Log("5 eat food on orb");
        status = FoodStatus.collected;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().enabled = false;
    }
}
