using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
    
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string nextSceneName; // The name of the scene to load when the player enters the door
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the next scene or perform any other action you want when the player enters the door
            Debug.Log("Player entered the door!");
            SceneManager.LoadScene(nextSceneName); // Replace "NextSceneName" with the actual name of the scene you want to load
        }
    }
}
