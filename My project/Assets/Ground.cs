using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("‰½‚©‚ª”»’è‚É“ü‚è‚Ü‚µ‚½");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("‰½‚©‚ª”»’è‚É“ü‚è‘±‚¯‚Ä‚¢‚Ü‚·");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("‰½‚©‚ª”»’è‚ð‚Å‚Ü‚µ‚½");
    }
}
