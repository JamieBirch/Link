using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cutouts : MonoBehaviour, IDropHandler
{
    // public List<Word> cutoutWords = new List<Word>();
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in cutouts");
        if (eventData.pointerDrag != null)
        { 
            
            Word word = eventData.pointerDrag.GetComponent<Word>().copy;
            word.Contrast();
            // addToCutoutWords(word);
            word.GetComponent<Word>().inCutouts = true;
        }
    }

    /*public void addToCutoutWords(Word word)
    {
        cutoutWords.Add(word);
    }
    
    public void removeFromCutoutWords(Word word)
    {
        cutoutWords.Remove(word);
    }*/
}
