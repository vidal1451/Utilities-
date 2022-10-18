using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace UI
{
public class UIEvents : MonoBehaviour
{
    [Header("# To Animate")]
    [SerializeField] Transform[] objectsToScale;
    [SerializeField] Transform[] objectsToRotate;
    [SerializeField] Transform[] objectsToMove;

    [Header("# Events")]
    [SerializeField] protected UnityEvent[] events;

    [Header("# Parameters To Scale")]
    [Range(0,2)]
    [SerializeField] float timeToSpawn;
    [Range(0,1)]
    [SerializeField] float timeToNormalize;
    [Range(0,2)]
    [SerializeField] float scaleMaxSize;

    [Header("# Parameters To Rotate")]
    [SerializeField] protected Vector3 toRotateStart;
    [SerializeField] protected Vector3 toRotateEnd;
    [Range(0,2)]
    [SerializeField] float timeToRotate;

    [Header("# Parameters To Move")]
    protected Sequence mySequence;

    public virtual void Start() {
        DOTween.Init();
    }

    public virtual void AnimateObjects(){
        mySequence = DOTween.Sequence();
    }
    public void ToScale(){
        foreach (Transform obj in objectsToScale)
        {
            obj.DOScaleY(0,0);
            obj.gameObject.SetActive(true);
            mySequence.Append(obj.DOScaleY(scaleMaxSize,timeToSpawn)).Append(obj.DOScaleY(1f,timeToSpawn));
        }
    }
    public void ToRotate(Vector3 _rotation){
        print("To Rotate");
        foreach (Transform obj in objectsToRotate)
        {
            mySequence.Append(obj.DORotate(_rotation,timeToRotate));
        }

    }
    public void ToMove(){

    }

    public void StartEvents(){
        foreach (UnityEvent item in events)
        {
            item.Invoke();
        }
    }
    public virtual void ResetSequence(){
        foreach (Transform obj in objectsToScale)
        {
            obj.gameObject.SetActive(false);
        }
    }

}
}

