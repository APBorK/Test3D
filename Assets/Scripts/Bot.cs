using UnityEngine;

public class Bot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player))
        {
            EventSistem.SendKillBot();
            gameObject.SetActive(false);
        }
    }
}
