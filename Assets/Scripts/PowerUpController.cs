using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public int value = 2;
    // Time To Double in seconds
    public int ttd = 6;
    private float timePassed = 0.0f;
    private GameObject leader;
    public TextMeshPro textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leader != null) {
            // transform.position = Vector3.MoveTowards(transform.position, leader.transform.position, .03f);
        }
        
    }

    void LateUpdate()
    {
        timePassed += Time.deltaTime;
        if (leader == null && timePassed > ttd) {
            timePassed = 0;
            value *= 2;
            textBox.text = value.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        PowerUpSpawner spawner = this.GetComponentInParent<PowerUpSpawner>();
        if (spawner != null && player != null) {
            spawner.ClaimPowerup();
            this.transform.SetParent(other.transform);
            leader = other.gameObject;
            player.AddTail(this.gameObject);
        }
        
        

        // Destroy(this.gameObject);
    }
}
