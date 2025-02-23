using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMeshPro tm;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider sCollider;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 jumpPos;
    [SerializeField]
    private static float returnSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        float colorVal = UnityEngine.Random.Range(0f, 6f) % 6; //(Mathf.Sin(Time.time * Mathf.PI / colorPeriod) + 1) * 3;
        if (colorVal < 1)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(.75f, colorVal, 1f);
        }
        else if (colorVal < 2)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(.75f, 1f, 1 - colorVal % 1);
        }
        else if (colorVal < 3)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(colorVal % 1, 1f, .75f);
        }
        else if (colorVal < 4)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1 - colorVal % 1, .75f);
        }
        else if (colorVal < 5)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, .75f, colorVal % 1);
        }
        else if (colorVal < 6)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1 - colorVal % 1, .75f, 1f);
        }

    }

    // Update is called once per frame
    public void BringToCam()
    {
        gameObject.name = "THE BALL";
        sCollider.enabled = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.rotation = Quaternion.identity;
        if (transform.position.y < -10 || Mathf.Abs(transform.position.x) > 20)
        {
            transform.position = jumpPos;
        }
        StartCoroutine(BringIt());
    }

    private IEnumerator BringIt()
    {
        while ((transform.position - targetPos).magnitude > .02)
        {
            Vector3 vec = targetPos - transform.position;
            transform.position += vec.normalized * Mathf.Min(vec.magnitude, returnSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void EndIt()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(0f, 4f), UnityEngine.Random.Range(-2f, 2f)), ForceMode.Impulse);
        rb.AddTorque(new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(0f, 4f), UnityEngine.Random.Range(-2f, 2f)), ForceMode.Impulse);
        Destroy(gameObject, 10f);
    }

    public void SetName(string uciemail)
    {
        tm.text = uciemail;
    }
}
