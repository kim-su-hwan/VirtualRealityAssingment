using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    void Update()
    {
        Moving();
    }
    void Moving()
    {
        //float hor = Input.GetAxis("Horizontal");        //왼쪽, 오른쪽 키 
        float ver = Input.GetAxis("Vertical");          //앞, 뒤 키

        transform.Translate(Vector3.forward * speed * ver * Time.deltaTime);      //이동
                                                                                  //transform.Rotate(Vector3.up * speed/5 * hor);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0.0f, -1.5f, 0.0f);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0.0f, 1.5f, 0.0f);
    }
}
