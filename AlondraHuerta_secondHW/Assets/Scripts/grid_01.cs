using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class grid_01 : MonoBehaviour
{
    public int AmountPiecesX;
    public int AmountPiecesY;
    public int count;

    public GameObject PivotPrefab;
    public GameObject PiecePrefab;

    public Transform Canvas, panel_Grid;
    public Button Restart;
    public Button nextLevel;

    public Text winText, clueText, goText;

    public Image winLevel, btn_Win, btn_restart, clue;

    public Sprite[] Pieces;

    public AudioSource correct;

    private List<pivotPuzzle> _Pivots;

    private void Awake()
    {
        //The scene is set
        clueText.gameObject.SetActive(true);
        winText.gameObject.SetActive(false);
        goText.gameObject.SetActive(false);
        winLevel.enabled = false;
        btn_Win.enabled = false;
        btn_restart.enabled = true;
        clue.enabled = true;
    }

    void Start()
    {
        //The list of pivots is created from the pre exitence prefabs
        //The list of pieces will be create from the prefab too
        _Pivots = new List<pivotPuzzle>();
        CreateSet(PivotPrefab, true);
        CreateSet(PiecePrefab, false);
    }

    private void CreateSet(GameObject prefab, bool isPivot)
    {
        //We get all the propierties of the prefab
        RectTransform puzzleTrans = prefab.GetComponent<RectTransform>();
        Vector2 initialSize = puzzleTrans.rect.size;
        for (int x = 0; x < AmountPiecesX; x++)
        {
            for (int y = 0; y < AmountPiecesY; y++)
            {
                GameObject temp = Instantiate(prefab);
                //if the game obejct is pivot, it created an ID and it adds the pivot to the list
                if (isPivot)
                {
                    pivotPuzzle tempPuzzle = temp.GetComponent<pivotPuzzle>();
                    tempPuzzle.ID = x + ":" + y;
                    _Pivots.Add(tempPuzzle);
                }
                //If it is not puzzle is a pice and it created an ID too, and give it the position where will be display
                else
                {
                    piecePuzzle tmpSetPuzzle = temp.GetComponent<piecePuzzle>();
                    tmpSetPuzzle.ID = x + ":" + y;
                    tmpSetPuzzle.Puzzle = this;
                    Image tempImage = temp.GetComponent<Image>();
                    tempImage.sprite = Pieces[(x * AmountPiecesY) + y];
                }
                //It gets the canva and the panel so every piece can fit in the space
                temp.transform.SetParent(Canvas);
                temp.transform.SetParent(panel_Grid);
                temp.transform.localPosition = prefab.transform.position + new Vector3(x * initialSize.x, y * initialSize.y * -1f, 0);
            }
        }
    }

    public pivotPuzzle nearPivot(piecePuzzle piece)
    {
        //It looks for the nearest pivot to the piece
        float minDistance = float.MaxValue;
        pivotPuzzle tempPivot = null;

        //It checks every pivot in the list 
        foreach (pivotPuzzle temp in _Pivots)
        {
            float distance = Vector3.Distance(piece.gameObject.transform.position, temp.gameObject.transform.position);
            //checks if that pivot is the min distance and the pivot is empty
            if (distance < minDistance && temp.Slot == null)
            {
                minDistance = distance;
                tempPivot = temp;
            }
        }

        //":" is take out so it can check if its the correct place where the piece is on
        string[] tPivot = tempPivot.ID.Split(char.Parse(":"));
        string[] tPiece = piece.ID.Split(char.Parse(":"));


        if ((tPivot[0] == tPiece[0]) && (tPivot[1] == tPiece[1]))
        {
            if(tPivot[0] == tPivot[1])
            {
                //The sound that indicates that the piece is in the correct place is play
                correct.Play();

                //It counts how many pieces have been placed in the correct place
                count++;

                //The piece is unable to move again
                piece.move = false;

                //If the count is equals to the total amount of pieces the puzzle is completed
                if (count == (AmountPiecesX * AmountPiecesY))
                {
                    win();
                }
                //print(tempPivot.ID + "," + piece.ID);
            }
        }

        //The same as the previous pivot but with the second case that indicates the piece is in the correct place
        else if (tPivot[1] == tPiece[0] && tPivot[0] == tPiece[1])
        {
            correct.Play();
            piece.move = false;
            count++;
            if (count == (AmountPiecesX * AmountPiecesY))
            {
                win();
            }
        }
        return tempPivot;
    }

    //The image that indicates the player won is display
    void win()
    {
        btn_restart.enabled = false;
        clue.enabled = false;
        clueText.gameObject.SetActive(false);

        goText.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        winLevel.enabled = true;
        btn_Win.enabled = true;
    }

    //Change the scene depending of the level where the player is
    public void nextScene()
    {
        string activeScn = SceneManager.GetActiveScene().name;
        if(activeScn == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }

        if (activeScn == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (activeScn == "Level 3")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    //The pieces go to their originally place
    public void reStart()
    {
        string activeScn = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeScn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
