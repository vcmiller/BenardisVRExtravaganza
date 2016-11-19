using UnityEngine;
using System.Collections;

public class HorseControl : MonoBehaviour {

    Transform cam;
    Rigidbody rb;

    public float sensitivity = 1f;
    public float speed = 1f;
    public float jumpSpeed = 10f;
    public float featherFactor = 0.1f;
    public float groundDetectDist = 1f;

    public bool isAirborne { get; private set; }

    Vector3 camAngles = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<Camera>().transform;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame]
    void Update()
    {
        CameraControls();
        JumpControls();
        rb.AddForce(Vector3.ProjectOnPlane(cam.transform.forward, transform.up) * speed * Input.GetAxis("Vertical"), ForceMode.VelocityChange);

    }

    void CameraControls()
    {
        cam.eulerAngles = camAngles;
        Vector3 v = cam.localEulerAngles;
        v.x = 0;
        v.y += Input.GetAxis("Mouse X") * Time.deltaTime * 120;
        v.z = 0;
        cam.localEulerAngles = v;
        cam.position = transform.position - cam.transform.forward * 10;
        v = cam.localPosition;
        v.y = 3.25f;
        cam.localPosition = v;

        camAngles = cam.eulerAngles;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.ProjectOnPlane(cam.forward, Vector3.up), Vector3.up), sensitivity * Mathf.Abs(Input.GetAxis("Vertical")));

    }

    void JumpControls()
    {
        isAirborne = !Physics.Raycast(transform.position, -transform.up, groundDetectDist);

        if (!isAirborne && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y, jumpSpeed), rb.velocity.z);
        }

        if(isAirborne)
        {
            rb.AddForce((Input.GetButton("Jump")? -(1 - featherFactor) : -1) * transform.up * jumpSpeed /2, ForceMode.Acceleration);
        }
    }
  


}
