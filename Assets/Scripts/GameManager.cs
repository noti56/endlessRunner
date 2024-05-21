using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int BonusPoints = 0;
    private float Health = 100;
    private int Score = 0;

    public UnityEvent<int> OnPointsChanged;
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent<int> OnScoreChanged;

    [SerializeField] private TextMeshProUGUI cofeePowerText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Animator animator;


    void Start()
    {
        OnPointsChanged ??= new UnityEvent<int>();
        OnHealthChanged ??= new UnityEvent<float>();
        OnScoreChanged ??= new UnityEvent<int>();

        OnPointsChanged.AddListener(UpdatePointsText);
        UpdatePointsText(BonusPoints);

        OnHealthChanged.AddListener(UpdateHealthText);
        OnHealthChanged.AddListener(CheckForEndGame);
        UpdateHealthText(Health);

        OnScoreChanged.AddListener(HandleScoreChange);
        HandleScoreChange(Score);




    }

    public void AddCofeePower(int points)
    {
        BonusPoints += points;
        OnPointsChanged.Invoke(BonusPoints);
    }

    public void ChangeHealth(float health)
    {
        Health += health;
        OnHealthChanged.Invoke(Health);
    }
    public void AddScore(int score)
    {
        Score += score;
        OnScoreChanged.Invoke(Score);
    }

    public void HandleObstacleEvent(EnemyData enemyData)
    {
        print("Met: " + enemyData.enemyName);

        if (BonusPoints > enemyData.health)
        {
            animator.SetTrigger("score");
            AddCofeePower(-enemyData.health);
            AddScore(enemyData.score);
        }
        else
        {
            animator.SetTrigger("gotHit");
            ChangeHealth(-enemyData.damage);
        }
    }

    public void CheckForEndGame(float health)
    {
        if (health > 0) return;
        print("Game Over");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdatePointsText(int points)
    {
        cofeePowerText.text = "Cofee Power: " + points.ToString();
    }

    void UpdateHealthText(float health)
    {
        healthText.text = "Health: " + health.ToString();
    }
    void HandleScoreChange(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
