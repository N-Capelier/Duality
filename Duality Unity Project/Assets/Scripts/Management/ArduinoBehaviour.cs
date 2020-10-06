using UnityEngine;

public class ArduinoBehaviour : MonoBehaviour
{
    /// <summary>
    /// Suspends the coroutine execution for the given amount of seconds using scaled time.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static YieldInstruction delay(float time)
    {
        return new WaitForSeconds(time);
    }
}