using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayersShouldDie : MonoBehaviour {

    public float maxHealth = 5;
    public float healthRegen = 0.2f;
    float health;

    // Use this for initialization
    void Start() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (health < maxHealth)
        {
            health = Mathf.Min(health + healthRegen * Time.deltaTime, maxHealth);
        }

        if (health <= 0)
        {
            DoTheThingYouDoWhenYouDie();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet"))
        {
            health -= 1;
        }
    }

    void DoTheThingYouDoWhenYouDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
