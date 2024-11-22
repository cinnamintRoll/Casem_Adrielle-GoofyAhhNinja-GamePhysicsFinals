using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb; // Reference to the rigidbody component
    private GameManager gameManager;

    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 16;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float xRange = 7;
    [SerializeField] private float ySpawnPos = -4;

    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);

            if (gameObject.CompareTag("Bad"))
            {
                audioManager.PlayRandomBadExplosionSFX();
            }
            else
            {
                audioManager.PlayRandomExplosionSFX();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            audioManager.PlaySFX(audioManager.fall);
            // gameManager.GameOver();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
