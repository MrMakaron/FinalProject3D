using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject Water;
    public List <GameObject> WaterList = new List<GameObject>();
    public float speed = 6f; // Целевая высота, до которой объект должен подняться

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
           // other.transform.rotation = Quaternion.Euler(-90, 0, 0);
            Vector3 leftSidePosition = other.transform.position - other.transform.right * 20;
            Vector3 RightSidePosition = other.transform.position + other.transform.right * 20;
            Vector3 ForwardSidePosition = other.transform.position - other.transform.forward * 20;
            Vector3 BackSidePosition = other.transform.position + other.transform.forward * 20;

            SpawnWaterLeft(leftSidePosition);
            SpawnWaterRight(RightSidePosition);
            SpawnWaterForward(ForwardSidePosition);
            SpawnWaterBack(BackSidePosition);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            if (other.transform.position.y < 0)
            {
                other.GetComponent<Rigidbody>().velocity = Vector3.up * speed;
            }
            else if (other.transform.position.y >= 0)
            {
                other.GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log("должно остановиться");
            }
        }
        Ray ray = new Ray(other.transform.position, -other.transform.up);
        RaycastHit hit;
        Debug.DrawRay(other.transform.position, -other.transform.up);      
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Water"))
            {
                Destroy(hit.collider.gameObject); 
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().velocity = - Vector3.up * speed;
        }
    }
    public void SpawnWaterLeft(Vector3 leftSidePosition)
    {
        // Создаем новый куб на позиции левой стороны
        Instantiate(Water, leftSidePosition, Quaternion.identity);
    }
    public void SpawnWaterRight(Vector3 RightSidePosition)
    {
        // Создаем новый куб на позиции левой стороны
        Instantiate(Water, RightSidePosition, Quaternion.identity);
    }
    public void SpawnWaterForward(Vector3 ForwardSidePosition)
    {
        // Создаем новый куб на позиции левой стороны
        Instantiate(Water, ForwardSidePosition, Quaternion.identity);
    }
    public void SpawnWaterBack(Vector3 BackSidePosition)
    {
        // Создаем новый куб на позиции левой стороны     
        Instantiate(Water, BackSidePosition, Quaternion.identity);
    }
}
