using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetail", menuName = "ScriptableObject/Player/Player Detail")]
public class PlayerDetailSO : ScriptableObject
{
    [Header("PLAYER RUN INFORMATION")]
    [SerializeField] float runAcceleration;  //奔跑加速度
    [SerializeField] float runMaxSpeed;      //奔跑最大速度

    [Header("PLAYER WALK INFORMATION")]
    [SerializeField] float walkAcceleration;  //正常加速度
    [SerializeField] float walkMaxSpeed;      //正常最大速度

    [Header("PLAYER AIR ACCELERATION INFORMATION")]
    [SerializeField] float airAcceleration;  //空中加速度

    [Header("PLAYER DECELERATION INFORMATION")]
    [SerializeField] float deceleration; //减速信息

    [Header("PLAYER ROTATE SPEED")]
    [SerializeField] float rotateSpeed; //旋转速率

    [Header("PLAYER JUMP FORCE")]
    [SerializeField] float jumpForce; //跳跃力
    [SerializeField] float slightJumpForce; //轻微的跳跃力
    [SerializeField] float bounceJumpForce; //强大的弹力

    [Header("PLAYER GRAVITY INFORMATION")]
    [SerializeField] float normalGravity; //标准重力

    [Header("PLAYER FLOAT FORCE INFORMATION")]
    [SerializeField] float waterFloatForce; //水中所受浮力
    [SerializeField] float windFloatForce; //吹风的浮力

    [Header("PLAYER ENTER WATER INFORMATION")]
    [SerializeField] float waterBufferForce; //入水中缓冲力
    [SerializeField] float swimRotateSpeed; //水中旋转速率
    [SerializeField] float swimAcceleration; //游泳加速度
    [SerializeField] float swimDeceleration; //游泳减速
    [SerializeField] float swimeMaxSpeed; //游泳最大速度

    [Header("PLAYER INVINCIBLE TIME")]
    [SerializeField] float invincibleTime; //无敌时间

    [Header("PLAYER SPIN DURAION")]
    [SerializeField] float spinDuration; //玩家旋转状态持续时间

    [Header("PLAYER STOMP INFORMATION")]
    [SerializeField] float stompDuration; //玩家翻滚持续时间
    [SerializeField] float stompMinSpeed; //玩家翻滚最低速度
    [SerializeField] float stompMaxSpeed; //玩家翻滚最高速度

    [Header("PLAYER AIR STOMP INFORMATION")]
    [SerializeField] float airStompRotateDuration; //玩家空中下砸向上运动持续时间
    [SerializeField] float stompGroundDuration; //玩家空中下砸向下运动持续时间
    [SerializeField] float airStompDownSpeed; //玩家空中下砸向下加速运动初速度速度

    [Header("PLAYER BACK FLIP INFORMATION")]
    [SerializeField] float backFlipInvertalTime; //玩家向后跳间隔时间
    [SerializeField] Vector2 backFlipForce; //玩家后跳的力

    [Header("PLAYER HANG CLIMB DURATION")]
    [SerializeField] float huangClimbDuration; //玩家悬挂攀爬持续时间

    [Header("PLAYER HURT TIME")]
    [SerializeField] float hurtTime; //玩家受伤持续时间

    [Header("PLAYER RAIL GRID")]
    [SerializeField] float railGridOffset; //玩家导轨y轴偏移量
    [SerializeField] float railGridScaleMultiple; //玩家导轨滑行延时倍数
    [SerializeField] float railGridExitInertiaSpeed; //玩家退出滑行状态的向前惯性速度

    [Header("PLAYER MODE ROTATE INDORMATION")]
    [SerializeField] float modeInclineMaxAngle; //模型旋转最大角度
    [SerializeField] float modeInclineSmoothness; //模型旋转平滑倾斜系数

    [Header("PLAYER CRAW INFORMATION")]
    [SerializeField] float crawAcceleration; //玩家攀爬加速度
    [SerializeField] float crawDeceleration; //玩家爬行减速度
    [SerializeField] float crawMaxSpeed; //玩家爬行最大速度
    [SerializeField] float crawRotateSpeed; //玩家爬行旋转速度

    [Header("PLAYER GLIDER INFOMEATION")]
    [SerializeField] float gliderAcceleration; //玩家滑翔伞状态加速度
    [SerializeField] float gliderMaxSpeed; //玩家滑翔伞最大速度
    [SerializeField] float gliderRotateSpeed; //玩家旋转最大速度
    [SerializeField] float gliderFallSpeed; //玩家滑翔伞下落速度;

    [Header("PLAYER DASH INFORMATION")]
    [SerializeField] float dashSpeed; //玩家冲刺速度
    [SerializeField] float dashDuration; //玩家冲刺状态持续时间
    [SerializeField] float dashCD; //玩家冲刺CD

    [Header("PLAYER CLIMB POLE INFORMATION")]
    [SerializeField] float climbPoleUpSpeed; //玩家向上爬杆速度
    [SerializeField] float climbPoleDownSpeed; //玩家向下爬杆速度
    [SerializeField] float climbPoleRotateSpeed; //玩家绕杆子旋转速度

    [Header("PLAYER WALL SLIDER INFORMATION")]
    [SerializeField] float wallSliderSpeed; //玩家滑墙速度

    [Header("PLAYER WALL JUMP INFORMATION")]
    [SerializeField] Vector2 wallJumpForce; //玩家跳墙力

    [Header("PLAYER AIR DIVE INFORMATION")]
    [SerializeField] float airDiveRotateSpeed; //玩家空中冲刺旋转速度
    [SerializeField] float airDiveInvertalTime; //玩家空中冲刺间隔时间
    [SerializeField] Vector2 airDiveForce; //玩家空中冲刺力

    [Header("PLAYER CAPSULE COLLIDER INFORMATION")]
    [SerializeField] float capsuleColliderNormalHeight;  //玩家正常碰撞箱高度
    [SerializeField] Vector3 capsuleColliderNormalCenter; //玩家正常碰撞箱中心
    [SerializeField] float capsuleColliderSquatHeight;  //玩家蹲下状态碰撞箱高度
    [SerializeField] Vector3 capsuleColliderSquatCenter;  //玩家蹲下状态碰撞箱中心

    [Header("PLAYER HURT BACKOFF FORCE")]
    [SerializeField] Vector2 hurtForce; //玩家受伤后收到的击退的力

    public float RunAcceleration
    {
        get
        {
            return runAcceleration;
        }
    }
    public float RunMaxSpeed
    {
        get
        {
            return runMaxSpeed;
        }
    }
    public float WalkAcceleration
    {
        get
        {
            return walkAcceleration;
        }
    }
    public float WalkMaxSpeed
    {
        get
        {
            return walkMaxSpeed;
        }
    }
    public float AirAcceleration
    {
        get
        {
            return airAcceleration;
        }
    }
    public float RotateSpeed
    {
        get
        {
            return rotateSpeed;
        }
    }
    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
    }
    public float SlightJumpForce
    {
        get
        {
            return slightJumpForce;
        }
    }
    public float NormalGravity
    {
        get
        {
            return normalGravity;
        }
    }
    public float Deceleration
    {
        get
        {
            return deceleration;
        }
    }
    public float InvincibleTime
    {
        get
        {
            return invincibleTime;
        }
    }
    public float HurtTime
    {
        get
        {
            return hurtTime;
        }
    }
    public float SpinDuration
    {
        get
        {
            return spinDuration;
        }
    }
    public float StompDuration
    {
        get
        {
            return stompDuration;
        }
    }
    public float StompMinSpeed
    {
        get
        {
            return stompMinSpeed;
        }
    }
    public float StompMaxSpeed
    {
        get
        {
            return stompMaxSpeed;
        }
    }
    public float AirStompRotateDuration
    {
        get
        {
            return airStompRotateDuration;
        }
    }
    public float StompGroundDuration
    {
        get
        {
            return stompGroundDuration;
        }
    }
    public float AirStompDownSpeed
    {
        get
        {
            return airStompDownSpeed;
        }
    }
    public float HangClimbDuration
    {
        get
        {
            return huangClimbDuration;
        }
    }
    public float RailGridOffset
    {
        get
        {
            return railGridOffset;
        }
    }
    public float RailGridScaleMultiple
    {
        get
        {
            return railGridScaleMultiple;
        }
    }
    public float RailGridExitInertiaSpeed
    {
        get
        {
            return railGridExitInertiaSpeed;
        }
    }
    public float WaterBufferForce
    {
        get
        {
            return waterBufferForce;
        }
    }
    public float WaterFloatForce
    {
        get
        {
            return waterFloatForce;
        }
    }
    public float BounceJumpForce
    {
        get
        {
            return bounceJumpForce;
        }
    }
    public float WindFloatForce
    {
        get
        {
            return windFloatForce;
        }
    }
    public float SwimRotateSpeed
    {
        get
        {
            return swimRotateSpeed;
        }
    }
    public float SwimAcceleration
    {
        get
        {
            return swimAcceleration;
        }
    }
    public float SwimDeceleration
    {
        get
        {
            return swimDeceleration;
        }
    }
    public float SwimeMaxSpeed
    {
        get
        {
            return swimeMaxSpeed;
        }
    }
    public float ModeInclineMaxAngle
    {
        get
        {
            return modeInclineMaxAngle;
        }
    }
    public float ModeInclineSmoothness
    {
        get
        {
            return modeInclineSmoothness;
        }
    }
    public float BackFlipInvertalTime
    {
        get
        {
            return backFlipInvertalTime;
        }
    }
    public float AirDiveRotateSpeed
    {
        get
        {
            return airDiveRotateSpeed;
        }
    }
    public float AirDiveInvertalTime
    {
        get
        {
            return airDiveInvertalTime;
        }
    }
    public float CrawAcceleration
    {
        get
        {
            return crawAcceleration;
        }
    }
    public float CrawDeceleration
    {
        get
        {
            return crawDeceleration;
        }
    }
    public float CrawMaxSpeed
    {
        get
        {
            return crawMaxSpeed;
        }
    }
    public float CrawRotateSpeed
    {
        get
        {
            return crawRotateSpeed;
        }
    }
    public float CapsuleColliderNormalHeight
    {
        get
        {
            return capsuleColliderNormalHeight;
        }
    }
    public float CapsuleColliderSquatHeight
    {
        get
        {
            return capsuleColliderSquatHeight;
        }
    }
    public float GliderAcceleration
    {
        get
        {
            return gliderAcceleration;
        }
    }
    public float GliderMaxSpeed
    {
        get
        {
            return gliderMaxSpeed;
        }
    }
    public float GliderRotateSpeed
    {
        get
        {
            return gliderRotateSpeed;
        }
    }
    public float GliderFallSpeed
    {
        get
        {
            return gliderFallSpeed;
        }
    }
    public float DashSpeed
    {
        get
        {
            return dashSpeed;
        }
    }
    public float DashDuration
    {
        get
        {
            return dashDuration;
        }
    }
    public float DashCD
    {
        get
        {
            return dashCD;
        }
    }
    public float WallSliderSpeed
    {
        get
        {
            return wallSliderSpeed; ;
        }
    }
    public float ClimbPoleUpSpeed
    {
        get
        {
            return climbPoleUpSpeed;
        }
    }
    public float ClimbPoleDownSpeed
    {
        get
        {
            return climbPoleDownSpeed;
        }
    }
    public float ClimbPoleRotateSpeed
    {
        get
        {
            return climbPoleRotateSpeed;
        }
    }
    public Vector2 WallJumpForce
    {
        get
        {
            return wallJumpForce;
        }
    }
    public Vector3 CapsuleColliderNormalCenter
    {
        get
        {
            return capsuleColliderNormalCenter;
        }
    }
    public Vector3 CapsuleColliderSquatCenter
    {
        get
        {
            return capsuleColliderSquatCenter;
        }
    }
    public Vector2 HurtForce
    {
        get
        {
            return hurtForce;
        }
    }
    public Vector2 BackFlipForce
    {
        get
        {
            return backFlipForce;
        }
    }
    public Vector2 AirDiveForce
    {
        get
        {
            return airDiveForce;
        }
    }
}
