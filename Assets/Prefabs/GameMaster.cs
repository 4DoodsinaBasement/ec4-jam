using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OutletType { Male, Female }
public enum GameColor { Blue, Red }

public class GameMaster : MonoBehaviour
{
    public GameObject bluePlayer, redPlayer;
    public int orbAddAmount = 5;
    public List<GameObject> BlueFood = new List<GameObject>();
    public List<GameObject> RedFood = new List<GameObject>();
    public float playerPauseTime = 1.0f;

    PlayerInput blueInput, redInput;
    PlayerScript blueScript, redScript;
    public int blueOrbId = 0;
    public int redOrbId = 0;

    public bool gameRunning = true;

    void Start()
    {
        gameRunning = true;
        
        blueInput = bluePlayer.GetComponent<PlayerInput>();
        redInput = redPlayer.GetComponent<PlayerInput>();
        blueScript = bluePlayer.GetComponent<PlayerScript>();
        redScript = redPlayer.GetComponent<PlayerScript>();
        BlueFood[blueOrbId].GetComponent<OrbScript>().spawnFood();
        RedFood[redOrbId].GetComponent<OrbScript>().spawnFood();
    }

    void FixedUpdate()
    {
        blueScript.MovePlayer(blueInput.inputDirection);
        redScript.MovePlayer(redInput.inputDirection);
    }

    public void WinGame()
    {
        Debug.Log("Win game");
    }

    public void LoseGame()
    {
        gameRunning = false;
        Debug.Log("Lose game");
        blueScript.allowedToMove = false;
        redScript.allowedToMove = false;
    }

    public bool OrbsCollected()
    {
        foreach (GameObject food in BlueFood)
        {
            if(food.GetComponent<OrbScript>().status != OrbScript.FoodStatus.collected)
            {
                return false;
            }
        }   

         foreach (GameObject food in RedFood)
        {
            if(food.GetComponent<OrbScript>().status != OrbScript.FoodStatus.collected)
            {
                return false;
            }
        }  

        return true;
    }

    public void FoodCollected(GameColor color)
    {   
        if(color == GameColor.Blue)
        {   
            BlueFood[blueOrbId].GetComponent<OrbScript>().EatFood(); 
            blueOrbId++;
            if (blueOrbId < BlueFood.Count){
                BlueFood[blueOrbId].GetComponent<OrbScript>().spawnFood(); 
            }
           
        }

        
        if(color == GameColor.Red)
        {   
            
            RedFood[redOrbId].GetComponent<OrbScript>().EatFood(); 


            redOrbId++;
            
            if (redOrbId < RedFood.Count){
                RedFood[redOrbId].GetComponent<OrbScript>().spawnFood(); 
            }
        }
    }
}
