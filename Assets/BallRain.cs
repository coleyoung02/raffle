using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallRain : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float deltaX;
    [SerializeField] private float deltaY;
    [SerializeField] private float deltaZ;
    [SerializeField] private Spin s;
    [SerializeField] private ParseCSV csvParse;
    private List<Ball> ballList;
    private List<Tuple<float, string, string>> odds;
    private float sum;
    private Ball lastBall;

    // Start is called before the first frame update
    void Start()
    {
        ballList = new List<Ball>();
        sum = 0;
        odds = csvParse.GetOdds();
        sum = 0;
        for (int i = 0; i < odds.Count; i++)
        {
            sum += odds[i].Item1;
        }
    }

    public void Pour(int balls)
    {
        StartCoroutine(Balls(balls));

    }

    private IEnumerator Balls(int n)
    {
        for (int i = 0 ; i < n / 20; i++)
        {
            for (int j = 0 ; j < 20; j++)
            {
                float x = UnityEngine.Random.Range(-deltaX, deltaX);
                float y = UnityEngine.Random.Range(-deltaY, deltaY);
                float z = UnityEngine.Random.Range(-deltaZ, deltaZ);
                Ball b = Instantiate(ball, transform.position + new Vector3(x, y, z), Quaternion.identity);
                Tuple<string, string> t = GetNextName();
                b.SetName(t.Item1 + "\n" + t.Item2);
                ballList.Add(b);
            }
            yield return new WaitForSeconds(.025f);
        }
        yield return new WaitForSeconds(2f);
        s.StartSpin();
    }

    private Tuple<string, string> GetNextName()
    {
        int index = 0;
        float r = UnityEngine.Random.Range(0f, sum);
        Debug.Log("generated r = " + r);
        while (r >= 0 && index < odds.Count)
        {
            r -= odds[index].Item1;
            index++;
        }
        index--;
        if (index < 0)
        {
            index = 0;
        }
        if (index >= odds.Count)
        {
            index = odds.Count - 1;
        }
        return new Tuple<string, string>(odds[index].Item2, odds[index].Item3);
    }

    public void Draw()
    {
        if (lastBall != null)
        {
            lastBall.EndIt();
        }
        int index = UnityEngine.Random.Range(0, ballList.Count - 1);
        Ball b = ballList[index];
        ballList.RemoveAt(index);
        b.BringToCam();
        lastBall = b;
    }
}
