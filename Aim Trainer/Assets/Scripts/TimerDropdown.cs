using UnityEngine;
using UnityEngine.UI;

public class TimerDropdown : MonoBehaviour
{
    public int time;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            time = 60;
            Debug.Log(time);
        }
        if (val == 1)
        {
            time = 600;
            Debug.Log(time);
        }
        if (val == 2)
        {
            time = 1200;
            Debug.Log(time);
        }
    }


}
