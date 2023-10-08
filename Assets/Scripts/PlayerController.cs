using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 195.0f;
    private int points = 2;
    private int factor = 0;
    private int consumed = 0;
    private string[] factors = {"", "K", "M", "B", "T", "Z", "Z2", "Z3"};
    [SerializeField]
    private List<GameObject> tail;
    public TextMeshPro textBox1;
    public TextMeshProUGUI scoreBox;
    private Rigidbody p_rbody;
    
    // Start is called before the first frame update
    void Start()
    {
        p_rbody = GetComponent<Rigidbody>();
        tail = new List<GameObject>();
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 lastPosition = transform.position;

        // Go forward
        Vector3 m_Input =  transform.forward * Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        p_rbody.MovePosition(lastPosition + m_Input);

        // Rotate
        Vector3 m_EulerAngleV = Vector3.up * Time.fixedDeltaTime * turnSpeed * horizontalInput;
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleV * Time.fixedDeltaTime * turnSpeed);
        Quaternion lastRotation = p_rbody.rotation;
        p_rbody.MoveRotation(p_rbody.rotation * deltaRotation);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        textBox1.text = points.ToString() + factors[factor];
        for (var i = 0; i < tail.Count ; i++) {
            PowerUpController tailBit = tail[i].GetComponent<PowerUpController>();
            Vector3 temp_location = tailBit.getLocation();
            Quaternion temp_rotation = tailBit.getRotation();
            tailBit.followLeader(lastPosition, lastRotation);
            lastPosition = temp_location;
            lastRotation = temp_rotation;
        }
    }

    // ENCAPSULATION
    public void UpdatePoints(int p)
    {
        points += p;
        if (points > 1024) {
            factor += 1;
        }
    }

    // ENCAPSULATION
    public int GetPoints()
    {
        return points;
    }

    public void AddTail(GameObject t)
    {
        // if (t == null) {
        //     Debug.Log("T is null???");
        // }
        tail.Add(t);
        tail.Sort(ComparePowerUp);
        // Debug.Log("AddTail: " + DebugTail());
        CompressTail();
        consumed++;
        scoreBox.text = "Consume: " + consumed;
    }

    public GameObject GetTail()
    {
        GameObject lastTail = tail.DefaultIfEmpty(null).Last();
        if (lastTail == null ) {
            return this.gameObject;
        }
        return lastTail;
    }

    private string DebugTail()
    {
        string printOut = this.points.ToString();
        for (var i = 0; i < tail.Count ; i++) {
            PowerUpController tc_1 = tail[i].GetComponent<PowerUpController>();
            printOut += " -> " + tc_1.value.ToString();
        }
        return printOut;
    }

    public void CompressTail()
    {
        if (tail.Count == 0) {
            return;
        }
        // Always check the first and head elements
        if (tail.Count >= 1) {
            PowerUpController tc = tail[0].GetComponent<PowerUpController>();
            if (tc.value >= points) {
                points += tc.value;
                Destroy(tail[0]);
                tail.RemoveAt(0);
            }
        }
        // Need to stop at the NEXT to last element
        for (var i = 0; i < tail.Count - 1; i++) {
            
            if (tail[i] == null || tail[i + 1] == null ) {
                continue;
            }
            PowerUpController tc_1 = tail[i].GetComponent<PowerUpController>();
            PowerUpController tc_2 = tail[i + 1].GetComponent<PowerUpController>();
            if (tc_1.value <= tc_2.value) {
                tc_1.updateValue(tc_1.value + tc_2.value);
                Destroy(tail[i + 1]);
                tail.RemoveAt(i + 1);
                // We removed an element, so go back 1 step.
                i -= 1;
            }
        }
        // Debug.Log("CompressTail: " + DebugTail());
    }

    private static int ComparePowerUp(GameObject b, GameObject a) 
    {
        if (a == null) {
            if (b == null) {
                return 0;
            } else {
                return -1;
            }
        } else {
            if (b == null) {
                return 1;
            } else {
                PowerUpController tc_1 = a.GetComponent<PowerUpController>();
                PowerUpController tc_2 = b.GetComponent<PowerUpController>();
                return tc_1.value - tc_2.value;
                
            }
        }
    }

    // Gets the players position.
    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }

}
