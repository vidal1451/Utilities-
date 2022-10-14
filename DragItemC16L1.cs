using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItemC16L1 : MonoBehaviour
{
    public int index;
    public bool isCorrect;
    public Transform target, target2, target3;
    Vector3 startPos;
    public float distance, distance2, distance3;
    float initialposZ;

    private void Start()
    {
        startPos = (this.transform.position);
        initialposZ = transform.position.z;
    }
    private void OnEnable()
    {
    }
    public void OnDrag()
    {
        distance = Vector3.Distance(this.transform.position, target.position);
        distance2 = Vector3.Distance(this.transform.position, target2.position);
        distance3 = Vector3.Distance(this.transform.position, target3.position);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, initialposZ));
    }
    public void OnDrop()
    {
        if (distance < 20)
        {
            this.transform.position = target.position;
            isCorrect = false;
            if (index == target.GetComponent<ReceptorItemC16L1>().receptorIndex)
            {
                isCorrect = true;
            }
        }
        else if (distance2 < 20){
            this.transform.position = target2.position;
            isCorrect = false;
            if (index == target2.GetComponent<ReceptorItemC16L1>().receptorIndex)
            {
                isCorrect = true;
            }
        }
        else if (distance3 < 20){
            this.transform.position = target3.position;
            isCorrect = false;
            if (index == target3.GetComponent<ReceptorItemC16L1>().receptorIndex)
            {
                isCorrect = true;
            }
        }
        else
        {
            this.transform.position = startPos;
            isCorrect = false;
        }
        QuizManagerC16L1.instance.receptorAns[index] = isCorrect;
        
    }
    public void RestorePosition()
    {
        this.transform.position = startPos;
        isCorrect = false;
    }
}
