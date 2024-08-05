using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    public GameObject GameScene;
    public Transform parentGameScene;
    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button storeButton;
    [Header("Game Menu Buttons")]
    [SerializeField] private Button backFromGameButton;
    [Header("Store Menu Buttons")]
    [SerializeField] private Button backFromStoreButton;
    private void Awake()
    {
        Instance = this;

        playButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
        storeButton.onClick.RemoveAllListeners();
        // backFromGameButton.onClick.RemoveAllListeners();
        backFromStoreButton.onClick.RemoveAllListeners();


        playButton.onClick.AddListener(OnClickPlayGame);
        quitButton.onClick.AddListener(OnClickQuitGame);
        storeButton.onClick.AddListener(OnClickStoreMenu);
        // backFromGameButton.onClick.AddListener(OnClickBackFromGame);
        backFromStoreButton.onClick.AddListener(OnClickBackFromStore);
    }

    public void OnClickPlayGame()
    {

        GameObject gameScene = Instantiate(GamePlayManager.Instance.GameScene, GamePlayManager.Instance.parentGameScene);
        gameScene.transform.localScale = Vector3.one;
        gameScene.transform.localPosition = Vector3.zero;
        MenuManager.Instance.OpenMenu("game");

    }

    public void OnClickBackFromGame()
    {
        MenuManager.Instance.OpenMenu("main");
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }

    public void OnClickStoreMenu()
    {
        MenuManager.Instance.OpenMenu("store");
    }

    public void OnClickBackFromStore()
    {
        MenuManager.Instance.OpenMenu("main");
    }
}
