using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<State> state;
    public List<Condition> condition;
    void Update()
    {
        for (int i = 0; i < state.count(); i++)
        {
            if (condition[i].CheckCondition())
            {
                state[i].setActive(true);
            }
            else
            {
                state[i].setActive(false);
            }
        }
    }
}
