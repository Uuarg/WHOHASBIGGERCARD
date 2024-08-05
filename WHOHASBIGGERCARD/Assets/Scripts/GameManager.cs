using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Win Panel")]
    public GameObject WinnerScreen;
    public TMP_Text winningCoinsText;
    public int turn = 0;
    public bool isPlayer1Ready = false;
    public bool isPlayer2Ready = false;
    public bool isFinalSetuped = false;
    [Header("References")]
    public List<CardsManager> cardsManagers = new List<CardsManager>();
    [SerializeField] private TMP_Text turnText;
    [SerializeField] private TMP_Text last_leftAbilityText;
    [SerializeField] private TMP_Text last_rightAbilityText;
    [SerializeField] private Button pickCardButton;
    public Button backButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() =>
        {
            DOTween.KillAll();
            Destroy(gameObject);
            MenuManager.Instance.OpenMenu("main");
        });
    }

    private void Start()
    {
        for (int i = 0; i < cardsManagers.Count; i++)
        {
            cardsManagers[i].id = i;
            StartCoroutine(cardsManagers[i].GenerateCards(cardsManagers[i].totalCards));
        }
    }

    private void Update()
    {
        if (isPlayer1Ready && isPlayer2Ready && !isFinalSetuped)
        {
            isFinalSetuped = true;
            ManageTurn();
        }
    }

    public void ManageTurn()
    {
        turn = (turn + 1) % cardsManagers.Count;
        if (turn == 0)
        {
            turnText.text = "YOUR TURN";
            turnText.DOColor(new Color32(0, 255, 0, 255), 0.5f);
        }
        else if (turn == 1)
        {
            turnText.text = "OPPONENT TURN";
            turnText.DOColor(new Color32(255, 0, 0, 255), 0.5f);
        }
        ManagePickCard();
    }

    public void LastCardSetup(string leftAbilityText, string rightAbilityText)
    {
        last_leftAbilityText.text = leftAbilityText;
        last_rightAbilityText.text = rightAbilityText;
    }

    public void ManagePickCard()
    {
        pickCardButton.onClick.RemoveAllListeners();
        pickCardButton.onClick.AddListener(() =>
        {
            cardsManagers[turn].PickCards();
        });
    }

    public bool isMyTurn(int id)
    {
        return id == turn;
    }

    public void OnClickContinue()
    {
        DOTween.KillAll();
        Destroy(gameObject);
        MenuManager.Instance.OpenMenu("main");
    }
}
