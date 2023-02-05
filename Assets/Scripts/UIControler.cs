using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIControler : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _pointText;
    [SerializeField] private TextMeshProUGUI _pedometerText;
    private float _point;
    private float _distanse;
    

    private void Start()
    {
        _point = PlayerPrefs.GetFloat("Point");
        _distanse = PlayerPrefs.GetFloat("Pedometer");
        RecordText(_pointText,_point);
        RecordText(_pedometerText,_distanse);
        EventSistem.OnKillBot += AddPoint;
        EventSistem.OnMovePlayer += AddDistanse;
    }

    void AddPoint()
    {
        _point++;
        RecordText(_pointText,_point);
        
    }

    void AddDistanse(float newDistanse)
    {
        _distanse += newDistanse;
        
        RecordText(_pedometerText,_distanse);
    }
    

    void RecordText(TextMeshProUGUI text, float number)
    {
        text.text = Math.Round(number,0).ToString();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Point",_point);
        PlayerPrefs.SetFloat("Pedometer",_distanse);
    }
}
