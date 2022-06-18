using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ThiefAnimatorController
{
    public static class Params
    {
        public static string IsFalling = nameof(IsFalling);
    }

    public static class States
    {
        public static string Idle = nameof(Idle);
        public static string Run = nameof(Run);
    }
}
