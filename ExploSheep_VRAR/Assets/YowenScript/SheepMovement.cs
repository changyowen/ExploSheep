using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    public ScoreHandler script;
    public HPScript loseHealth;
    //access
    public GameObject player_gameObj;
    public Transform player_transform;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AnsGeneration ansGeneration;
    public AudioSource correctSound;
    public AudioSource explodeSound;

    //editable data
    public float distanceToStop;
    public float speed;
    public float gravity = -9.81f;
    public float flyingTime = 2f;

    //system use
    Vector3 velocity;
    bool isGrounded;
    bool correctAnswer = false;
    bool reachTarget = false;

    void Start()
    {
        script = GameObject.Find("ScoreText").GetComponent<ScoreHandler>();
        loseHealth = GameObject.Find("HP").GetComponent<HPScript>();
        player_gameObj = GameObject.Find("Player");
        player_transform = player_gameObj.GetComponent<Transform>();
        correctSound = GameObject.Find("correct").GetComponent<AudioSource>();
        explodeSound = GameObject.Find("boom").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(reachTarget == false && WaveManager.instance.startGame == true)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
            GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
            FollowTargetWithRotation(player_transform, distanceToStop, speed);
        }
    }

    void Update()
    {
        correctAnswer = ansGeneration.IsThisCorrect();
        if (correctAnswer)
        {
            this.transform.tag = "Sheep";
        }
        else
        {
            this.transform.tag = "InfectedSheep";
        }
    }

    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    {
        Vector3 realTargetPosition = new Vector3(target.position.x, transform.position.y + 1, target.position.z);
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(realTargetPosition);
            transform.position = Vector3.MoveTowards(transform.position, realTargetPosition, speed * Time.deltaTime);
        }
        else
        {
            reachTarget = true;
            ReachPlayer(correctAnswer);
        }
    }

    void ReachPlayer(bool correctAnswer)
    {
        if(correctAnswer)
        {
            script.AddScore();
            StartCoroutine(Flying(flyingTime));
        }
        else
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Flying(float time)
    {
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
        correctSound.Play();
        float elapsedTime = 0;
        Vector3 destination = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z);
        while (elapsedTime <= time)
        {
            float step = time * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }

    IEnumerator Explode()
    {
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("stun");
        transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.SetActive(false);
        explodeSound.Play();
        loseHealth.DeductHP();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
