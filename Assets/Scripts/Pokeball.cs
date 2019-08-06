using UnityEngine;
using System.Collections;
 
public class Pokeball : MonoBehaviour
{
    [SerializeField]
    private float throwSpeed = 35f;
    private float speed;
    private float lastMouseX, lastMouseY;

    private bool thrown, holding;

    private Rigidbody _rigidbody;
    private Vector3 newPosition;

    public int inputType = 0; //0pc 1 touch

    void Start()
    {
        #if UNITY_ANDROID
            inputType = 1;
        #endif

        #if UNITY_EDITOR
            inputType = 0;
        #endif

        #if UNITY_EDITOR_WIN
            inputType = 0;
        #endif

        #if UNITY_STANDALONE
            inputType = 0;
        #endif

        _rigidbody = GetComponent<Rigidbody>();
        Reset();
    }

    void Update()
    {
        if (holding)
            OnTouch();

        if (thrown)
            return;

        if (this.inputType == 1)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            { 
              Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, 100f))
              {
                  if (hit.transform == transform)
                  {
                      holding = true;
                      transform.SetParent(null);
                  }
              }
            }

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            { 
              if (lastMouseY < Input.GetTouch(0).position.y)
              {
                  ThrowBall(Input.GetTouch(0).position);
              }
            }

            if (Input.touchCount == 1)
            { 
                lastMouseX = Input.GetTouch(0).position.x;
                lastMouseY = Input.GetTouch(0).position.y;
            }



        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            { 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform == transform)
                    {
                        holding = true;
                        transform.SetParent(null);
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            { 
                if (lastMouseY < Input.mousePosition.y)
                {
                    ThrowBall(Input.mousePosition);
                }
            }

            if (Input.GetMouseButton(0))
            { 
                lastMouseX = Input.mousePosition.x;
                lastMouseY = Input.mousePosition.y;
            }

        }
       

        
    }

    void Reset()
    {
        CancelInvoke();
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, Camera.main.nearClipPlane * 7.5f));
        newPosition = transform.position;
        thrown = holding = false;

        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 200f, 0f);
        transform.SetParent(Camera.main.transform);
    }

    void OnTouch()
    {
        Vector3 mousePos = Vector3.zero;

        if(inputType==0)
            mousePos = Input.mousePosition;
        else
            mousePos = Input.GetTouch(0).position;

        mousePos.z = Camera.main.nearClipPlane * 7.5f;

        newPosition = Camera.main.ScreenToWorldPoint(mousePos);

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 50f * Time.deltaTime);
    }

    void ThrowBall(Vector2 mousePos)
    {
        _rigidbody.useGravity = true;

        float differenceY = (mousePos.y - lastMouseY) / Screen.height * 100;
        speed = throwSpeed * differenceY;

        float x = 0;

        if (inputType == 0)
            x = Mathf.Abs(Input.mousePosition.x - lastMouseX) / Screen.width * 100 * x;
        else
            x = Mathf.Abs(Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100 * x;


        Vector3 direction = new Vector3(x, 0f, 1f);
        direction = Camera.main.transform.TransformDirection(direction);

        _rigidbody.AddForce((direction * speed / 2f) + (Vector3.up * speed));

        holding = false;
        thrown = true;

        Invoke("Reset", 5.0f);
    }
}