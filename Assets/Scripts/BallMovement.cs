using UnityEngine;

public class BallMovement : MonoBehaviour
{
    int failCheck = 0;

    [HideInInspector]
    public int score = 0;

    Rigidbody gravRig;

    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        gravRig = GetComponent<Rigidbody>();

        if (Input.GetMouseButtonDown(0) && failCheck == 0)
        {
            RaycastHit hit;

            Rigidbody rb;

            Vector3 forceDir;

            gravRig.useGravity = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (rb = hit.transform.gameObject.GetComponent<Rigidbody>())
                {
                    //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    //Debug.Log(rb.transform.position);
                    //Debug.Log(PlayerPrefs.GetInt("BestScore", 0));

                    SoundManager.PlaySound("Hit");

                    score++;

                    forceDir = rb.transform.localPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    rb.AddForce(new Vector3(forceDir.x * 5f, 10f, 0), ForceMode.VelocityChange);
                    rb.AddTorque(new Vector3(0f, 0f, forceDir.x * -30f));
                }
            }

            FindObjectOfType<GameManager>().UpdateBestScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LowerBound"))
        {
            transform.position = initPos;
            gravRig.useGravity = false;
            gravRig.velocity = Vector3.zero;
      
            SoundManager.PlaySound("Fail");
            failCheck = 1;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
