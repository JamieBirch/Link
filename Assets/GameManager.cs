using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    public GameObject cutouts;
    public GameObject[] tasks;
    public int currentTaskIndex = 0;
    public GameObject currentTask;
    public Answer currentAnswer;

    public Link homePage;
    private Link currentLink;

    private bool _gameOver = false;

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

    void Update()
    {
        if (!_gameOver)
        {
            if (currentAnswer.allCorrect)
            {
                Debug.Log("All correct");
                if (currentTaskIndex < tasks.Length - 1)
                {
                    Debug.Log("Giving next");
                    giveNextTask();
                }
                else
                {
                    _gameOver = true;
                    Debug.Log("You won");
                }  
            } 
        }
    }

    private void giveNextTask()
    {
        currentTaskIndex++;
        currentTask.SetActive(false);
        currentTask = tasks[currentTaskIndex];
        currentTask.SetActive(true);
        currentAnswer = currentTask.GetComponent<Task>().GetAnswer();
    }

    public void OpenPage(Link link)
    {
        Debug.Log("Open page");
        currentLink.page.SetActive(false);
        link.page.SetActive(true);
        link.parent = currentLink;
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
