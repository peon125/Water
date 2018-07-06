using System;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float rotating_sensitivity;
    [SerializeField]
    float clampValue;

    Touch[] touches;

    private void Update()
    {
        AddFakeTouch();

        TouchInput();
    }

    private void AddFakeTouch()
    {
        touches = new Touch[Input.touchCount + (FakeTouch.ciop.gotNewTouch ? 1 : 0)];

        for (int i = 0; i < Input.touchCount; i++)
        {
            touches[i] = Input.GetTouch(i);
        }

        if (FakeTouch.ciop.gotNewTouch)
        {
            touches[touches.Length - 1] = FakeTouch.ciop.fakeTouch;
        }
    }

    private void TouchInput()
    {
        if (touches.Length > 0)
        {
            float delta = Mathf.Clamp(touches[0].deltaPosition.x, -clampValue, clampValue);

            rb.transform.eulerAngles += delta * Vector3.forward * rotating_sensitivity;
        }
    }
}