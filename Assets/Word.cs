using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private GameManager _gameManager;
    public TextMeshProUGUI text;
    public Image hoverBox;
    public CanvasGroup canvasGroup;
    private bool dragging = false;
    private Word copy;
    private Canvas canvas;
    private Color contrastTextColor = Color.white;
    private Color defaultTextColor;

    private Vector3 offset;
    public bool inCutouts;

    private void Start()
    {
        _gameManager = GameManager.instance;
        defaultTextColor = text.color;
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
        copy.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop Dragging");
        // dragging = false;
        // copy.GetComponent<Collider2D>().isTrigger = false;
        // if ()
        // hoverBox.enabled = true;

        if (inCutouts)
        {
            _gameManager.cuts.GetComponent<Cutouts>().addToCutoutWords(copy);
        }
        copy.canvasGroup.blocksRaycasts = true;
        copy = null;
    }

    public void Contrast()
    {
        text.color = contrastTextColor;
    }
    
    public void Default()
    {
        text.color = defaultTextColor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start Dragging");
        if (canvas == null)
        {
            // canvas = GameManager.instance.canvas;
            canvas = _gameManager.canvas;
        }

        // Debug.Log("Dragging");
        // if (dragging == false)
        // {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // dragging = true;
            copy = Instantiate(this, canvas.transform);
            // Physics2D.IgnoreCollision(copy.GetComponent<Collider2D>(), _gameManager.cuts.GetComponent<Collider2D>(), false);
            
            // copy.GetComponent<Collider2D>().isTrigger = true;
            // copy.text.color = contrastColor;
        // }
        
        copy.canvasGroup.blocksRaycasts = false;
        //TODO
    }
}
