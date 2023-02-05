using System;
using TMPro;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _pointText;
    [SerializeField] private TextMeshProUGUI _pedometerText;


    private void Start()
    {
        float point = PlayerPrefs.GetFloat(Key.Point);
        float distanse = PlayerPrefs.GetFloat(Key.Pedometer);
        RecordText(_pointText,point);
        RecordText(_pedometerText,distanse);
        EventSistem.OnKillBotPoint += AddPoint;
        EventSistem.OnMovePlayerDistanse += AddDistanse;
    }

    void AddPoint(float point)
    {
        RecordText(_pointText,point);
    }

    void AddDistanse(float newDistanse)
    {
        RecordText(_pedometerText,newDistanse);
    }
    

    void RecordText(TextMeshProUGUI text, float number)
    {
        text.text = Math.Round(number,0).ToString();
    }
}
