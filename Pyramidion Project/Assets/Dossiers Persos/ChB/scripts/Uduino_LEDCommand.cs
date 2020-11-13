using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

/// <summary>
/// CHB -- Contains the commands for the LED head
/// </summary>
public class Uduino_LEDCommand : MonoBehaviour
{
    public enum lightCommand { Reset, Victory, Defeat};
    bool inLightSequence = false;
    
    // Update is called once per frame
    void Update()
    {
        if (!inLightSequence)
        {
            if (WIS_MainManager.instance.ledBlue)
            {
                CommandLED(lightCommand.Victory);
                inLightSequence = true;
            }
            else if (WIS_MainManager.instance.ledRed)
            {
                CommandLED(lightCommand.Defeat);
                inLightSequence = true;
            }
        }
    }

    /// <summary>
    /// CHB -- Select command with lightCommand enum members
    /// </summary>
    /// <param name="command">Victory, Defeat or Reset</param>
    public void CommandLED(lightCommand command)
    {
        switch (command)
        {
            case lightCommand.Victory:
                UduinoManager.Instance.sendCommand("victory");
                break;

            case lightCommand.Defeat:
                UduinoManager.Instance.sendCommand("defeat");
                break;

            case lightCommand.Reset:
                UduinoManager.Instance.sendCommand("reset");
                inLightSequence = false;
                break;
        }
    }
}
