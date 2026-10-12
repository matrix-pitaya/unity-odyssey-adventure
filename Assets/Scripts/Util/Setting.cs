using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Setting
{
    public const int GameDataSlotNum = 5;
    public const int PlayerDefaulHurtNum = 3;
    public const int PlayerDefaultRetrieNum = 3;
    public const int LevelMaxStarNum = 3;
    public const float MiniDistance = 0.1f;
    public const float MinDistance = 1f;
    public const float CatreColldierCreateDamageMinSpeed = 20.0f;

    public const string DateFront = "yy/mm/dd hh:mm";
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";

    public const string Movement = "Movement";
    public const string Run = "Run";


    public const string Idle = "Idle";
    public const string Move = "Move";
    public const string Jump = "Jump";
    public const string Fall = "Fall";
    public const string Break = "Break";
    public const string Hurt = "Hurt";
    public const string Dead = "Dead";
    public const string Spin = "Spin";
    public const string Hold = "Hold";
    public const string Stomp = "Stomp";
    public const string AirStomp = "AirStomp";
    public const string Hang = "Hang";
    public const string HangClimb = "HangClimb";
    public const string RailGrind = "RailGrind";
    public const string Swim = "Swim";
    public const string BackFlip = "BackFlip";
    public const string Squat = "Squat";
    public const string Craw = "Craw";
    public const string AirDive = "AirDive";
    public const string Glider = "Glider";
    public const string Dash = "Dash";
    public const string WallSlider = "WallSlider";
    public const string WallJump = "WallJump";
    public const string ClimbPole = "ClimbPole";


    public const float RailGridCheckRadius = 0.85f;
    public const float HangCheckDistance = 0.55f;
    public const float WaterCheckRadius = 0.5f;
    public const float GroundCheckDistance = 0.55f;
    public const float PoleCheckRadius = 0.8f;
    public const float PoleCheckPositionOffset = 1.0f;
    public const string Ground = "Ground";
    public const string Wall = "Wall";
    public const string Crate = "Crate";
    public const string Rail = "Rail";
    public const string Water = "Water";
    public const string Pole = "Pole";


    public const string TagCrate = "Crate";
    public const string TagSlime = "Slime";
    public const string TagGress = "Gress";
    public const string TagWood = "Wood";
    public const string TagMetal = "Metal";
    public const string TagCoin = "Coin";
    public const string TagHeart = "Heart";
  

    public const string Player = "Player";


    public const string FileSelectScene = "FileSelectScene";
    public const string LevelSelectScene = "LevelSelectScene";


    public static readonly int State = Animator.StringToHash("State");
    public static readonly int LastState = Animator.StringToHash("Last State");
    public static readonly int LateralSpeed = Animator.StringToHash("Lateral Speed");
    public static readonly int VerticalSpeed = Animator.StringToHash("Vertical Speed");
    public static readonly int LateralAnimationSpeed = Animator.StringToHash("Lateral Animation Speed");
    public static readonly int Health = Animator.StringToHash("Health");
    public static readonly int JumpCounter = Animator.StringToHash("Jump Counter");
    public static readonly int IsGrounded = Animator.StringToHash("Is Grounded");
    public static readonly int IsHolding = Animator.StringToHash("Is Holding");
    public static readonly int OnStateChanged = Animator.StringToHash("On State Changed");

    public static readonly int Show = Animator.StringToHash("Show");
    public static readonly int Hide = Animator.StringToHash("Hide");
    public static readonly int Normal = Animator.StringToHash("Normal");
}
