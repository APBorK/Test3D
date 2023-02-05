using UnityEngine;

public class FalseActive : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventSistem.SendKillBot();
            gameObject.SetActive(false);
        }
    }
}
