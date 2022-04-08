using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StoneMove : MonoBehaviour
{
    public Animation Animation;
    public void Move()
    {
        Animation.Play();
    }
}
