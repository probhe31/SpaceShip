using UnityEngine;

public static class PlayerVars
{
    public static float acceleration = 60;
    public static float dessaceleration = 40;
    public static float maxMoveSpeed = 2;
    public static float mouseSmoothTime = 1.5f;
    public static float sensitivity = 100.0f;
    public static float maxFallSpeed = -8f;
    public static int wallsLM = LayerMask.GetMask("Walls");
}