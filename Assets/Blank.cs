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
        if (eventData.pointerDrag != null)
        {
            if (word != null && word != eventData.pointerDrag.GetComponent<Word>().copy)
            {
                Destroy(word.gameObject);
            }
            word = eventData.pointerDrag.GetComponent<Word>().copy;
            word.transform.position = transform.position;
            word.inBlank = true;
        }
    }
}
