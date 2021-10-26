using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{
    menu,
    inTheGame,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameStatus currentGameStatus = GameStatus.menu;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Awake(){
        startPosition = this.transform.position;
        sharedInstance = this;
        
    }
    void Start()
    {
        currentGameStatus = GameStatus.menu;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("s"))
        {
             if(currentGameStatus != GameStatus.inTheGame){
            StartGame();
            //currentGameStatus = GameStatus.inTheGame;
        }
        }
    }
    public void StartGame (){
        ScriptConejo.shareInstance.StartGame();
        ChangeGameState(GameStatus.inTheGame);
    }
    public void GameOver(){
        ChangeGameState(GameStatus.GameOver);
        this.transform.position = startPosition;
    }
    public void BackToMainMenu(){
        ChangeGameState(GameStatus.menu);
    }
    void ChangeGameState(GameStatus newGameState){
        if (newGameState == GameStatus.menu)
        {
            
        }
        else if(newGameState==GameStatus.inTheGame)
        {
            
        }else if (newGameState==GameStatus.GameOver){

        }
        currentGameStatus = newGameState;
    }
}
