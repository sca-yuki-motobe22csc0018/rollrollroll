using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public Text winText;

    private Rigidbody rb;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal=Input.GetAxis("Horizontal");
        var moveVertical=Input.GetAxis("Vertical");

        var movement=new Vector3(moveHorizontal,0,moveVertical);

        rb.AddForce(movement*speed);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        // すべての収集アイテムを獲得した場合
        if (score >= 32)
        {
            // リザルトの表示を更新
            winText.text = "You Win!";
        }
    }
}
