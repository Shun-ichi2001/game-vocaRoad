using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����������ɓ���܂���");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("����������ɓ��葱���Ă��܂�");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("������������ł܂���");
    }
}
