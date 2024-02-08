using UnityEngine;

public class Bot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
//123123
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            EventSistem.SendKillBot();
            gameObject.SetActive(false);
        }
    }
}
