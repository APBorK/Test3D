using UnityEngine;

public class FalseActive : MonoBehaviour
{
    private const int _point = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int point = PlayerPrefs.GetInt("Point");
            PlayerPrefs.SetInt("Point", point + _point);
            gameObject.SetActive(false);
        }
    }
}
