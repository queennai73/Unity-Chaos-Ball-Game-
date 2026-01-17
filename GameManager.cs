using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Goal references
    public GoalScript blue, green, red, orange, chaos;

    // Black objects counter
    public int blackObjectsRemaining;

    private bool isGameOver = false;
    private float elapsedTime = 0f;

    void Update()
    {
        if (!isGameOver)
        {
            // Check if all goals are solved
            bool goalsSolved = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved && chaos.isSolved;

            // Check if all black objects are gone
            bool blackObjectsSolved = blackObjectsRemaining <= 0;

            // End game if both conditions are true
            if (goalsSolved && blackObjectsSolved)
            {
                isGameOver = true;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }

    public void BlackObjectDestroyed()
    {
        blackObjectsRemaining--;
        if (blackObjectsRemaining < 0) blackObjectsRemaining = 0;
    }

    void OnGUI()
    {
        if (isGameOver)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75), "Game Over");
            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 25, 60, 50), "Good Job!");
            GUI.Box(new Rect(Screen.width / 2 - 65, 250, 130, 40), "Your Time was");
            GUI.Label(new Rect(Screen.width / 2 - 10, 265, 20, 30), ((int)elapsedTime).ToString());
        }
        else
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 115, 200, 60), "Your Time Is");
            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 100, 20, 30), ((int)elapsedTime).ToString());
        }
    }
}
