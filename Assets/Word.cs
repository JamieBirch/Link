using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, /*IPointerEnterHandler, IPointerExitHandler,*/ IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private GameManager _gameManager;
    public TextMeshProUGUI text;
    // public Image hoverBox;
    public CanvasGroup canvasGroup;
    private bool dragging = false;
    public Word copy;
    private Canvas canvas;
    private Color contrastTextColor = Color.white;
    private Color defaultTextColor;
    // public SoundEffectsPlayer soundPlayer;

    // private Vector3 offset;
    public bool inCutouts;
    public bool inBlank;

    private void Start()
    {
        _gameManager = GameManager.instance;
        // soundPlayer = _gameManager.soundPlayer;
        defaultTextColor = text.color;
        canvas = _gameManager.canvas;
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        hoverBox.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverBox.enabled = false;
    }*/

    public void OnDrag(PointerEventData eventData)
    {
        copy.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop Dragging");

        /*if (inCutouts)
        {
            _gameManager.cuts.GetComponent<Cutouts>().addToCutoutWords(copy);
        }*/
        if (!copy.inBlank)
        {
            copy.canvasGroup.blocksRaycasts = true;
        }

        if (!copy.inBlank && !copy.inCutouts)
        {
            //TODO fix
            copy.enabled = false;
            // Destroy(copy);
        }
        // copy.hoverBox.enabled = false;
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
        // Debug.Log("Start Dragging");
        /*if (canvas == null)
        {
            canvas = _gameManager.canvas;
        }*/

        // offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (inCutouts || inBlank)
        {
            Default();
            inCutouts = false;
            inBlank = false;
            copy = this;
            // copy.hoverBox.enabled = true;
        }
        else
        {
            copy = Instantiate(this, transform.position, Quaternion.identity, canvas.transform);
        }
        
        copy.canvasGroup.blocksRaycasts = false;
    }
}
