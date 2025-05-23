using UnityEngine;

public class Chase : State
{
    //[Header]
    public float speed;
    public Vector3 movement;
    private GameObject playerObject;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StartChase();
    }

    public void StartChase()
    {
        // Cari posisi player
        // Gerak ke posisi player dengan speed yg udh ditentuin
    }
}
