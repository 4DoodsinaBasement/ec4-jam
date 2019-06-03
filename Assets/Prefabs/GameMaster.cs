using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OutletType { Male, Female }
public enum GameColor { Blue, Red }

public class GameMaster : MonoBehaviour
{
    #region Singleton
    private static GameMaster _instance;

    public static GameMaster Instance
    {
        get
        {
            if (_instance == null) { _instance = new GameMaster(); }
            return _instance;
        }
    }
    #endregion

    public GameObject bluePlayer, redPlayer;
    public int orbAddAmount = 5;
    public List<GameObject> BlueFood = new List<GameObject>();
    public List<GameObject> RedFood = new List<GameObject>();

    PlayerInput blueInput, redInput;
    PlayerScript blueScript, redScript;
    public int blueOrbId = 0;
    public int redOrbId = 0;

    void Start()
    {
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
        Debug.Log( "1");
        if(color == GameColor.Blue)
        {   
            Debug.Log( "2");
            BlueFood[blueOrbId].GetComponent<OrbScript>().EatFood(); 
            blueOrbId++;
            if (blueOrbId < BlueFood.Count){
                Debug.Log( "3");
                BlueFood[blueOrbId].GetComponent<OrbScript>().spawnFood(); 
            }
           
        }
        Debug.Log( "4");
        if(color == GameColor.Red)
        {   
            Debug.Log( "5");
            
            Debug.Log( "6");
            RedFood[redOrbId].GetComponent<OrbScript>().EatFood(); 


            redOrbId++;
            
            if (redOrbId < RedFood.Count){
                RedFood[redOrbId].GetComponent<OrbScript>().spawnFood(); 
            }
        }
    }
}
