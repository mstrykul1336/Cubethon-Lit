using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public int Jewels;
    public TextMeshProUGUI jewel_score;
    public TextMeshProUGUI speed_Text;
    public GameObject speed_Texts;


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    void onScreenScore()
    {
        speed_Texts.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Jewel")
        {
            Jewels += 1;
            forwardForce += 100;
            sidewaysForce += 10;
            Debug.Log("Collected");
            jewel_score.text = Jewels.ToString();
            speed_Texts.SetActive(true);
            Invoke("onScreenScore", 1.0f);
            
        }
    }
}
