using UnityEngine;

public class Cutouts : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("has collided");
    }
}
