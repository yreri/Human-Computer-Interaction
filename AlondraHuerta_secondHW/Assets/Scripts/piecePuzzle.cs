using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class piecePuzzle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    //The pivot class will help to create the list of prefabs
    public grid_01 Puzzle;
    public pivotPuzzle Pivot;
    public string ID;
    private Vector2 _Offset;
    public bool move;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(move == true)
        {
            _Offset = new Vector2(transform.position.x, transform.position.y) - eventData.pressPosition;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (move == true) { 
            transform.position = eventData.position + _Offset;
        }
        //Debug.Log(eventData.position + " , " + eventData.pressPosition);
    }

    //This function helps to get the pivot that is nearest to the piece while is drag
    public void OnEndDrag(PointerEventData eventData)
    {
        if (move == true)
        {
            if (Puzzle != null)
            {
                pivotPuzzle nearestPivot = Puzzle.nearPivot(this);
                if (nearestPivot != null)
                {
                    if (Pivot != null)
                    {
                        Pivot.Slot = null;
                    }
                    Pivot = nearestPivot;
                    Pivot.Slot = this;
                    transform.position = Pivot.transform.position;
                }
                else if (Pivot != null)
                {
                    Pivot.Slot = null;
                    Pivot = null;
                }
            }

        }
        

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
