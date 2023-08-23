using UnityEngine;

public class Blank : MonoBehaviour
{
    public Word word;
    public string targetText;

    public bool setRight()
    {
        if (word != null)
        {
            return word.text.text == targetText;
        }
        else
        {
            return false;
        }
    }

}
