using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGameObject : MonoBehaviour
{
    public float SpinSpeed = 1f;
    public Transform GameObjectToSpin;
    public bool SpinXAxis = false;
    public bool SpinYAxis = false;
    public bool SpinZAxis = false;

    private void Start()
    {
        if (GameObjectToSpin == null)
            GameObjectToSpin = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpinXAxis)
        GameObjectToSpin.RotateAround(GameObjectToSpin.position, GameObjectToSpin.right, SpinSpeed * Time.deltaTime);
        if (SpinYAxis)
            GameObjectToSpin.RotateAround(GameObjectToSpin.position, GameObjectToSpin.up, SpinSpeed * Time.deltaTime);
        if (SpinZAxis)
            GameObjectToSpin.RotateAround(GameObjectToSpin.position, GameObjectToSpin.forward, SpinSpeed * Time.deltaTime);
    }
}
