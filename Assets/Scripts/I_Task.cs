using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Task : I_Interactable {
    void StartTask();
    void ExitTask();
    void CompleteTask();
}
