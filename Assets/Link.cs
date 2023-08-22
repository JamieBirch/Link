using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Link : MonoBehaviour, IPointerClickHandler
{
    private GameManager _gameManager;
    
    public Link parent;
    
    public TextMeshProUGUI text;
    private Color clickedLinkColor = Color.magenta;
    private List<Link> children;
    private int level;
    private TextType type;
    private bool clicked = false;
    public GameObject page;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    
    private void ClickLink()
    {
        clicked = true;
        text.color = clickedLinkColor;
        _gameManager.OpenPage(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickLink();
    }
}
