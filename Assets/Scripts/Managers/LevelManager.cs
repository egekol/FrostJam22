using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        private GameState _gameState;

        public GameState GameState
        {
            get => _gameState;
            set
            {
                UIManager.instance.ShowLoseScreen();
                UpdateState(value);
                _gameState = value;
            }
        }

        private void UpdateState(GameState value)
        {
            switch (value)
            {
                // case GameState.Start:
                //     allowToMove = true;
                //     break;
                case GameState.Lose:
                    Debug.Log("GameState.Lose");
                    // allowToMove = false;
                    break;
                case GameState.Playing:
                    // allowToMove = true;
                    break;
                // case GameState.Win:
                //     allowToMove = false;
                //     break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        private void Update()
        {
            if (GameState == GameState.Lose && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                EnemyManager.instance.GameStart();
                GameState = GameState.Playing;
                UIManager.instance.CLoseLoseScreen();
            }
        }
    }

    public enum GameState
    {
        Playing,
        Lose
    }
}

