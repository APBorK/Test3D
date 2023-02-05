using UnityEngine;

public class Save : MonoBehaviour
{
    private float _point;
    private float _distanse;
    void Start()
    {
        _point = PlayerPrefs.GetFloat(Key.Point);
        _distanse = PlayerPrefs.GetFloat(Key.Pedometer);
        EventSistem.OnKillBot += AddPoint;
        EventSistem.OnMovePlayer += AddDistanse;
    }
    void AddPoint()
    {
        _point++;
        EventSistem.SendKillBotPoint(_point);
    }
    void AddDistanse(float newDistanse)
    {
        _distanse += newDistanse;
        EventSistem.SendMovePlayerDistanse(_distanse);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Point",_point);
        PlayerPrefs.SetFloat("Pedometer",_distanse);
    }
}
