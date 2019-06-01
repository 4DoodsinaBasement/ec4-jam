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

    PlayerInput blueInput, redInput;
    PlayerScript blueScript, redScript;

    void Start()
    {
        blueInput = bluePlayer.GetComponent<PlayerInput>();
        redInput = redPlayer.GetComponent<PlayerInput>();
        blueScript = bluePlayer.GetComponent<PlayerScript>();
        redScript = redPlayer.GetComponent<PlayerScript>();
    }

    void FixedUpdate()
    {
        blueScript.MovePlayer(blueInput.inputDirection);
        redScript.MovePlayer(redInput.inputDirection);
    }
}
