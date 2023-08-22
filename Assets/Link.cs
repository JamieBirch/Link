using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public TextNode parent;
    private List<Link> children;
    private int level;
    private TextType type;
    private bool clicked = false;
    public GameObject page;

    public void ClickLink()
    {
        clicked = true;
        OpenPage();
    }

    private void OpenPage()
    {
        //TODO implement
        Debug.Log("Open page");
    }
}
