using UnityEngine;
using System.Collections;

public class CubeRotator : MonoBehaviour
{
    private Transform mCachedTransform;

    [SerializeField]
    private float mSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        mCachedTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
