using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharaController : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    private float walkSpeed = 3.0f; // 通常時の速度

    [SerializeField]
    private float sprintSpeed = 10f; // ダッシュ時の速度

    private Vector3 moveDir = Vector3.zero; // 移動の方向を計算するための変数
    private Vector3 sprintDir = Vector3.zero; // ダッシュの方向を計算するための変数

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // FixedUpdate は0.02秒ごとに呼び出される関数です。物理演算を行う場合はこちらを使うといいです。
    void FixedUpdate()
    {
        Vector3 direction = (moveDir + sprintDir) * Time.fixedDeltaTime; // 移動方向を計算する

        sprintDir = Vector3.Lerp(sprintDir, Vector3.zero, 5f * Time.fixedDeltaTime); // sprintDirを徐々に0に近づける

        if (cc.isGrounded) // 地面に接地しているかどうか
        {
            direction -= Vector3.up; // 地面に接地している場合は、地面に押し付けるようにする
        }
        else
        {
            direction += Physics.gravity * Time.fixedDeltaTime; // 地面に接地していない場合は、重力をかける
        }

        cc.Move(direction); // キャラクターを移動させる
    }

    public void Move(Vector2 direction)
    {
        moveDir = new Vector3(direction.x, 0, direction.y).normalized; // 方向を計算する
        moveDir = transform.TransformDirection(moveDir); // キャラクターの向きに合わせて方向を変える
        moveDir *= walkSpeed; // 速度をかける
    }

    public void Sprint()
    {
        sprintDir = new Vector3(0, 0, sprintSpeed); // ダッシュの方向を計算する
        sprintDir = transform.TransformDirection(sprintDir); // キャラクターの向きに合わせて方向を変える
    }
}
