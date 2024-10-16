using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharaController))]
public class PhysicsInput : MonoBehaviour
{
    CharaController charaCon;

    void Start()
    {
        charaCon = GetComponent<CharaController>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A, Dキー、または左右キーの入力を取得
        float z = Input.GetAxisRaw("Vertical"); // W, Sキー、または上下キーの入力を取得
        Vector2 direction = new Vector2(x, z).normalized; // 入力をベクトルにする

        charaCon.Move(direction); // 入力に応じてキャラクターを移動させる

        if (Input.GetKey(KeyCode.LeftShift))
        {
            charaCon.Sprint(); // 左Shiftキーが押されている場合はダッシュする
        }
    }
}
