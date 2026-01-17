using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public bool isSolved = false;
    public bool isChaosGoal = false;

    private int chaosStep = 0;

    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;

        // ===== CHAOS GOAL =====
        if (isChaosGoal)
        {
            if (chaosStep == 0 && collidedWith.tag == "Yellow Chaos 1")
            {
                chaosStep = 1;
                GetComponent<Light>().color = Color.white;
                Destroy(collidedWith);
                return;
            }

            if (chaosStep == 1 && collidedWith.tag == "White Chaos")
            {
                chaosStep = 2;
                GetComponent<Light>().color = Color.yellow;
                Destroy(collidedWith);
                return;
            }

            if (chaosStep == 2 && collidedWith.tag == "Yellow Chaos 2")
            {
                isSolved = true;
                GetComponent<Light>().enabled = false;
                Destroy(collidedWith);
                return;
            }
        }

        // ===== NORMAL GOALS =====
        if (!isChaosGoal && collidedWith.tag == gameObject.tag)
        {
            isSolved = true;
            GetComponent<Light>().enabled = false;
            Destroy(collidedWith);
        }
    }
}
