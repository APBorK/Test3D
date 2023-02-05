using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] int _countBot;
    private float _range;
    private float _minTime = 1f;
    private float _maxTime = 3f;
    private Queue<GameObject> _bot = new Queue<GameObject>();


    void Start()
    {
        _range = transform.localScale.x;
        RecordListBot();
        StartCoroutine(TimerSpawn());
    }

    void RecordListBot()
    {
        for (int i = 0; i < _countBot; i++)
        {
            _bot.Enqueue(Instantiate(Resources.Load<GameObject>("Bot")));
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
            Vector3 position = new Vector3(Random.Range(_range,-_range),transform.position.y,
                Random.Range(_range,-_range));
            GameObject bot = _bot.Dequeue();
            if (bot.activeSelf == false)
            {
                bot.SetActive(true);
                bot.transform.position = position;
                
            }
            else if (count < _countBot)
            {
                count++;
            }
            _bot.Enqueue(bot);
        }
    }
}
