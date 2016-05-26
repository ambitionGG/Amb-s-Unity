using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    public  float speed;
    private int count;
    private TextMesh counttext;
    private TextMesh winText;
    //private GUIText gt;
    
    void Start()
    {
        count = 0;
        counttext = GameObject.Find("Main Camera/CountText").GetComponent<TextMesh>();
        winText  = GameObject.Find("Main Camera/winText").GetComponent<TextMesh>();
        counttext.text = "";
        setCount();
        winText.text = "";
    }
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);

    }


    void setCount()
    {
        counttext.text = "count:" + count.ToString();
        if (count >= 17)
        {
            winText.text = "傻逼嫖哥";        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            setCount();
        }
    }
}
