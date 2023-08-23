using UnityEngine;
using UnityEngine.EventSystems;

public class Blank : MonoBehaviour, IDropHandler
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


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in blank");
        //TODO
    }
}
