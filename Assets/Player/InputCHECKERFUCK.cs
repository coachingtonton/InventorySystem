using UnityEngine;

public class InputCHECKERFUCK : MonoBehaviour
{
    public float inputAxis;
    public bool hKeyPressed;
    public bool gKeyPressed;
    public bool jumpPressed;
    public bool rKeyPressed;
    public bool tKeyPressed;
    public bool oneKeyPressed;
    public bool twoKeyPressed;
    public bool iKeyPressed;


    public bool ePressed;

    private void Update()
    {
        inputAxis = Input.GetAxisRaw("Horizontal");
        hKeyPressed = Input.GetKeyDown(KeyCode.H);
        rKeyPressed = Input.GetKeyDown(KeyCode.R);
        jumpPressed = Input.GetKey(KeyCode.Space);
        gKeyPressed = Input.GetKeyDown(KeyCode.G);
        tKeyPressed = Input.GetKeyDown(KeyCode.T);
        oneKeyPressed = Input.GetKeyDown(KeyCode.Alpha1);
        twoKeyPressed = Input.GetKeyDown(KeyCode.Alpha2);
        iKeyPressed = Input.GetKeyDown(KeyCode.I);


        ePressed = Input.GetKeyDown(KeyCode.E);
    }


}
