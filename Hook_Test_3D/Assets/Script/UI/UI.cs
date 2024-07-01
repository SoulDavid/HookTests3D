using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text ActualScore;
    [SerializeField]
    private Text TotalScore;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        ActualScore.text = gameManager.GetScore().ToString();
        TotalScore.text = gameManager.GetTotalScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        ActualScore.text = gameManager.GetScore().ToString();
        TotalScore.text = gameManager.GetTotalScore().ToString();
    }
}
