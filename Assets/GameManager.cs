using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    public GameObject cuts;
    public GameObject answer;
    
    public Link homePage;
    private Link currentLink;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentLink = homePage;
    }

    public void OpenPage(Link link)
    {
        Debug.Log("Open page");
        currentLink.page.SetActive(false);
        link.page.SetActive(true);
        SetCurrentLink(link);
    }
    
    public void GoBack()
    {
        OpenPage(currentLink.parent);
    }
    
    public void OpenHomePage()
    {
        OpenPage(homePage);
    }

    public void SetCurrentLink(Link link)
    {
        currentLink = link;
    }
}
