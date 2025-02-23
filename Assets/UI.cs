using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private BallRain br;
    [SerializeField] private Slider s;
    [SerializeField] private TextMeshProUGUI tm;


    public void Rain()
    {
        br.Pour((int)s.value);
    }


    public void SetText()
    {
        tm.text = ((int)s.value).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
