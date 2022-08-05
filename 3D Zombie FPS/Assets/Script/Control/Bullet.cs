using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject character;

    Vector3 dir;
    private void Start()
    {
        //character = GameObject.FindGameObjectWithTag("Character");
        Destroy(gameObject, 3);
    }
    void Update()
    {
        transform.Translate(character.transform.forward * speed * Time.deltaTime);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            other.gameObject.GetComponentInParent<AIControl>().health -= 20;
            Debug.Log("Ãæµ¹");
            Destroy(gameObject);
        }
    }

    
}
