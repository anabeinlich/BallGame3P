using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BallControll : MonoBehaviour

{
    [SerializeField] private float force;

    [SerializeField] Rigidbody rb;
    [SerializeField] SphereCollider sphereCollider;

    [SerializeField] private int score;

    private int totalItems;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI maxItemsText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        sphereCollider = GetComponent<SphereCollider>();

        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        UpdateScore();

        winText.text = "";

        maxItemsText.text = "";
    }

    void Update() 
    {
        if (score >= totalItems)
        {
            maxItemsText.text = "High score!";
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);

        rb.AddForce(direction.normalized * force, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choque contra:" + collision.gameObject.name);

        
        if (collision.gameObject.CompareTag("Item"))
        {
            ScoreUp(collision);

        }
        

        if (collision.gameObject.CompareTag("Kill"))
        {

            SceneManager.LoadScene(0);

        }

        if (collision.gameObject.CompareTag("Meta"))
        {
            MostrarMensajeMeta();
            Time.timeScale = 0;
        }

    }

    void MostrarMensajeMeta()
    {
        winText.text = "YOU WIN";
    }

    private void ScoreUp(Collision collision)
    {
        Debug.Log("ITEM");
        Destroy(collision.gameObject);
        score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString() + " / " + totalItems.ToString();
    }
}
