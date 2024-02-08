using UnityEngine;

public class Bot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
//123
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            EventSistem.SendKillBot();
            gameObject.SetActive(false);
        }
    }
}
