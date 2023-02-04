using TMPro;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _point;
    [SerializeField] private TextMeshProUGUI _pedometer;

    private void FixedUpdate()
    {
        _point.text = PlayerPrefs.GetInt("Point").ToString();
        _pedometer.text = PlayerPrefs.GetFloat("Distance").ToString();
    }
}
