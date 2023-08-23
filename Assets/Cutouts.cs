using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cutouts : MonoBehaviour, IDropHandler
{
    public List<Word> cutoutWords = new List<Word>();
    
    // public Vector2 top_left_corner;
    // public Vector2 bottom_right_corner;
    
    private void Update()
    {
        /*Collider2D collider = Physics2D.OverlapArea(top_left_corner, bottom_right_corner);
        if (collider != null)
        {
            Debug.Log("has overlapped");
        }*/
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("has collided");

        if (collision.collider.gameObject.TryGetComponent(out Word word))
        {
            word.inCutouts = true;
            word.Contrast();
        }
        
        // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("has stopped colliding");
        // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);

        if (collision.collider.gameObject.TryGetComponent(out Word word))
        {
            word.inCutouts = false;
            word.Default();
        }
    }*/
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in blank");
        if (eventData.pointerDrag != null)
        { 
            
            Word word = eventData.pointerDrag.GetComponent<Word>().copy;
            word.Contrast();
            addToCutoutWords(word);
            word.GetComponent<Word>().inCutouts = true;
            // word.transform.position = transform.position;
        }
    }

    public void addToCutoutWords(Word word)
    {
        cutoutWords.Add(word);
    }
    
    public void removeFromCutoutWords(Word word)
    {
        cutoutWords.Remove(word);
    }
}
