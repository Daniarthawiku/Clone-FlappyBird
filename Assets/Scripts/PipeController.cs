using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float pipeSpeed = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * pipeSpeed * Time.deltaTime);
    }
}
