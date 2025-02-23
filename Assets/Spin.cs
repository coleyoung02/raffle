using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private GameObject lid;
    private bool spinning = false;
    private float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartSpin()
    {
        lid.SetActive(true);
        spinning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning && angle < 90f)
        {
            angle += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(angle * 2f, angle * 3f, angle * 2f);
        }
        else if (spinning)
        {
            spinning = false;
        } 
    }
}
