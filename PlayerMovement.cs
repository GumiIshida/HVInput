using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PlayerMovement : MonoBehaviour
{
    private IHVInput HVinput;
    [SerializeField] private float MoveSpeed;
    private ReactiveProperty<Vector3> position;
    public IObservable<Vector3> OnPositionChanged => position.SkipLatestValueOnSubscribe();


    void Awake()
    {
        var input = GetComponent<WASDinput>();
        HVinput = input != null ? input : gameObject.AddComponent<WASDinput>();
        position = new ReactiveProperty<Vector3>(transform.position);
    }

    public void SetSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (HVinput == null) return;

        transform.position += new Vector3(HVinput.GetHorizontalAxis(), 0, HVinput.GetVerticalAxis()) * MoveSpeed * Time.deltaTime;
        position.Value = transform.position;
    }
}