using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    private GameManager _gameManager;
    public TextMeshProUGUI text;
    public Image hoverBox;
    private bool dragging = false;
    private Word copy;
    private Canvas canvas;
    // private Color contrastColor = Color.white;

    private Vector3 offset;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log( "hit smth");
        if (collision.gameObject == _gameManager.cuts)
        {
            Debug.Log( "put in cuts?");
        }
    }*/
    
    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log( "hit smth");
        if (hit.gameObject == _gameManager.cuts)
        {
            Debug.Log( "put in cuts?");
            // Debug.Log(item);
            // GetComponent<FirstPersonController>().nearbyItem = hit.gameObject;
        } 
    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("OnMouseEnter");
        hoverBox.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("OnMouseExit");
        hoverBox.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //TODO drop word to cuts/answer place
        if (canvas == null)
        {
            // canvas = GameManager.instance.canvas;
            canvas = _gameManager.canvas;
        }

        // Debug.Log("Dragging");
        if (dragging == false)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
            copy = Instantiate(this, canvas.transform);
            // copy.text.color = contrastColor;
        }
        copy.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop Dragging");
        dragging = false;
        // if ()
        // hoverBox.enabled = true;
        copy = null;
    }
}
