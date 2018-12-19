using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public float speed;
    private Rigidbody2D rg2d;
    public Text CountText;
    public Text WinText;
    private int _counts;
	// Use this for initialization
	void Start () {
        rg2d = GetComponent<Rigidbody2D>();
        CountText.text = "Counts:";
        _counts = 0;
    }
	
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");
        Vector2 moveForce = new Vector2(moveHorizontal, moveVertical);
        rg2d.AddForce(moveForce*speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _counts = _counts + 1;
            SetCountText();
        }

    }
    void SetCountText()
    {
        CountText.text = "Counts:" + _counts.ToString();
        if (_counts == 12)
        {
            WinText.gameObject.SetActive(true);
        }
    }
}
