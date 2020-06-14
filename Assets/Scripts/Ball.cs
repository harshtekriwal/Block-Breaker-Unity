using UnityEngine;

public class Ball : MonoBehaviour
{   
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    //state
    Vector2 paddleToballVector;
    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    bool hasStarted = false;
    void Start()
    {
        paddleToballVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPedal();
            LaunchOnMouseClick();

        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPedal()
    {
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToballVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
                myRigidBody.velocity += new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
            
        }
    }
}
