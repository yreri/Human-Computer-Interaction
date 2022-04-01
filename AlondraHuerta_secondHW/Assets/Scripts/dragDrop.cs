using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    private Vector2 _Offset;

    //The offset of where the piece was and where is was placed get calculated 
    public void OnBeginDrag(PointerEventData eventData)
    {
        _Offset = new Vector2(transform.position.x, transform.position.y) - eventData.pressPosition;
    }

    //The piece is placed
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + _Offset;
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
