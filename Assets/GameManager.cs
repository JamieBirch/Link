using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;

    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
