using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PlayerRotate : MonoBehaviour
{
    private IHVInput HVinput;
    private ReactiveProperty<Vector3> rotation;
    public IObservable<Vector3> OnRotationChanged => rotation.SkipLatestValueOnSubscribe();
    void Awake()
    {
        var input = GetComponent<WASDinput>();
        HVinput = input != null ? input : gameObject.AddComponent<WASDinput>();
        rotation = new(transform.rotation.eulerAngles);
    }

    // ���v����Ŋp�x�����܂�
    void Update()
    {
        if (HVinput == null) return;

        //�E���͂̂Ƃ�
        var horizontal = HVinput.GetHorizontalAxis();
        var vertical = HVinput.GetVerticalAxis();

        //�㉺2�_
        if (horizontal == 0)
        {
            if (vertical == 1) transform.rotation = Quaternion.Euler(0,0,0);
            else if (vertical == -1) transform.rotation = Quaternion.Euler(0, 180, 0);
            else return;
        }

        //�E��3�_
        else if(horizontal == 1)
        {
            if (vertical == 0) transform.rotation = Quaternion.Euler(0, 90, 0);
            else if (vertical == 1) transform.rotation = Quaternion.Euler(0, 45, 0);
            else transform.rotation = Quaternion.Euler(0, 135, 0);
        }

        //����3�_
        else
        {
            if (vertical == 0) transform.rotation = Quaternion.Euler(0, 270, 0);
            else if (vertical == 1) transform.rotation = Quaternion.Euler(0, 315, 0);
            else transform.rotation = Quaternion.Euler(0, 225, 0);
        }

        rotation.Value = transform.rotation.eulerAngles;
    }
}
