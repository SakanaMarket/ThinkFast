using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    [SerializeField] GameObject GoToThis;
    [SerializeField] GameObject ToDisable;

    public void GoToCanvas()
    {
        GoToThis.SetActive(true);
        ToDisable.SetActive(false);
    }

}
