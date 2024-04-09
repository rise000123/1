using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절 변수
    public Animator animator;

    private float moveInput; // 사용자 입력 저장 변수
    private bool facingRight = true; // 캐릭터가 오른쪽을 바라보고 있는지 여부를 저장하는 변수

    void Update()
    {
        // 사용자 입력 받기
        moveInput = Input.GetAxis("Horizontal");

        // 캐릭터 방향 전환
        if ((moveInput > 0 && !facingRight) || (moveInput < 0 && facingRight))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // 캐릭터 이동
        transform.Translate(new Vector3(moveInput * moveSpeed * Time.fixedDeltaTime, 0, 0));
        if(moveInput != 0) 
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
       
    }

    // 캐릭터 방향 전환 메서드
    void Flip()
    {
        facingRight = !facingRight; // 방향 변경

        // 캐릭터 스케일 변경하여 뒤집기
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
