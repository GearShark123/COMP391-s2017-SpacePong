using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startBall;
    public TextMesh player1Wins;
    public TextMesh player2Wins;
    public TextMesh playerOne;
    public TextMesh playerTwo;

    public GameObject player1;
    public GameObject player2;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    
    public static int p1Score = 0;
    public static int p2Score = 0;

    public GUISkin layout;

    void Start()
    {
        player1Wins.text = "";
        player2Wins.text = "";     
    }

    // Point depending on wall hit
    public static void Score(string wallID)
    {
        if (wallID == "RightWall" && (p1Score < 10 && p2Score < 10) )
        {
            p1Score++;
        }
        else if (wallID == "LeftWall" && (p2Score < 10 && p1Score < 10))
        {
            p2Score++;
        }        
    }



    void OnGUI()
    {        
        playerOne.text = p1Score + "";
        playerTwo.text = p2Score + "";        

        if (p1Score >= 10)
        {
            Destroy(GameObject.Find("NextBall(Clone)"));
            player1Wins.text = "PLAYER 1 WINS!";            
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 75, 120, 53), "RESTART"))
            {
                p1Score = 0;
                p2Score = 0;
                player1Wins.text = "";                                 
                Instantiate(startBall);
            }
        }
        else if (p2Score >= 10)
        {
            Destroy(GameObject.Find("NextBall(Clone)"));
            player2Wins.text = "PLAYER 2 WINS!";           
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 75, 120, 53), "RESTART"))
            {
                p1Score = 0;
                p2Score = 0;
                player2Wins.text = "";                                
                Instantiate(startBall);
            }
        }
    }
}
