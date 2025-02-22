using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject ball;
    private Vector3 startposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startposition = ball.transform.position;
        Debug.Log(startposition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Ball ist von der Plattform gerollt");
        ball.transform.position = startposition;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ball ist an der Kante");
    }
}
