using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField]
    private int TotalScore;
    private int Score;

    [SerializeField]
    private GameObject canvas;
    private Animator animCanvas;

    private InputManager inputManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        animCanvas = canvas.GetComponent<Animator>();
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore()
    {
        Score++;
        animCanvas.Play("UpdateUI");
    }

    public int GetScore() { return Score; }
    public int GetTotalScore() { return TotalScore; }
}
