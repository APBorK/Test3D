using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] int _countBot;
    private float _minX; 
    private float _minZ;
    private float _maxX;
    private float _maxZ;
    private float _minTime = 1f;
    private float _maxTime = 3f;
    private List<GameObject> _bot = new List<GameObject>();


    void Start()
    {
        _maxX = transform.localScale.x;
        _minX = -_maxX;
        _maxZ = transform.localScale.z;
        _minZ = -_maxZ;
        RecordListBot();
        StartCoroutine(TimerSpawn());
    }

    void RecordListBot()
    {
        for (int i = 0; i < _countBot; i++)
        {
            _bot.Add(Instantiate(Resources.Load<GameObject>("Bot")));
            _bot[i].SetActive(false);
        }
    }

    IEnumerator TimerSpawn()
    {
        while (true)
        {
            float randomTime = Random.Range(_minTime,_maxTime);
            yield return new WaitForSeconds(randomTime);
            SpawnActivityBot(Random.Range(1,_countBot));
        }
    }

    void SpawnActivityBot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (_bot[i].activeSelf == false)
            {
                Vector3 position = new Vector3(Random.Range(_minX,_maxX),transform.position.y,
                    Random.Range(_minZ,_maxZ));
                _bot[i].SetActive(true);
                _bot[i].transform.position = position;
            }
            else if (count < _countBot)
            {
                count++;
            }
        }
    }
}
