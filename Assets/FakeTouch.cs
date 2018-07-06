using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTouch : MonoBehaviour
{
    public static FakeTouch ciop;

    public Touch fakeTouch;
    public bool gotNewTouch;

    Vector3 lastMousePosition;

    private void Awake()
    {
        ciop = this;
    }

    void Update()
    {
        gotNewTouch = Input.GetMouseButton(0);

        if (gotNewTouch)
        {
            fakeTouch = new Touch();
            fakeTouch.fingerId = 10;
            fakeTouch.position = Input.mousePosition;
            fakeTouch.deltaTime = Time.deltaTime;
            fakeTouch.deltaPosition = Input.mousePosition - lastMousePosition;
            fakeTouch.phase = (Input.GetMouseButtonDown(0) ? TouchPhase.Began :
                                (fakeTouch.deltaPosition.sqrMagnitude > 1f ? TouchPhase.Moved : TouchPhase.Stationary));
            fakeTouch.tapCount = 1;
        }

        lastMousePosition = Input.mousePosition;
    }
}
