using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public List<Blank> blanks = new List<Blank>();
    public bool allCorrect = false;

    // Update is called once per frame
    void Update()
    {
        if (checkAllFilled())
        {
            allCorrect = checkAllCorrect();
        }
    }

    private bool checkAllFilled()
    {
        bool result = true;
        foreach (var blank in blanks)
        {
            if (!blank.IsSet())
            {
                result = false;
                break;
            }
        }
        return result;
    }
    
    private bool checkAllCorrect()
    {
        bool result = true;
        foreach (var blank in blanks)
        {
            if (!blank.SetRight())
            {
                result = false;
                break;
            }
        }
        return result;
    }
}
