using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
   private Vector2 _firstPos;
   private Vector2 _secondPos;
    public Vector2 _currentPos;
    public float _moveSpeed;
    void Start()
    {
        
    }

   
    void Update()
    {
        Swipe();
    }
private void Swipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _currentPos = new Vector2(_secondPos.x - _firstPos.x, _secondPos.y - _firstPos.y);
        }
        _currentPos.Normalize();

        if (_currentPos.y < 0 && _currentPos.x >-0.5f && _currentPos.x<0.5f)
        {
            rb.velocity = Vector3.back * _moveSpeed;


        }
        if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {

            rb.velocity = Vector3.forward * _moveSpeed;
        }
        if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {

            rb.velocity = Vector3.right * _moveSpeed;
        }
        if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {

            rb.velocity = Vector3.left * _moveSpeed;
        }
 }





    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ground")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }



    }

}
