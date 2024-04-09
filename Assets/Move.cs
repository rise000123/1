using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ���� ����
    public Animator animator;

    private float moveInput; // ����� �Է� ���� ����
    private bool facingRight = true; // ĳ���Ͱ� �������� �ٶ󺸰� �ִ��� ���θ� �����ϴ� ����

    void Update()
    {
        // ����� �Է� �ޱ�
        moveInput = Input.GetAxis("Horizontal");

        // ĳ���� ���� ��ȯ
        if ((moveInput > 0 && !facingRight) || (moveInput < 0 && facingRight))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // ĳ���� �̵�
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

    // ĳ���� ���� ��ȯ �޼���
    void Flip()
    {
        facingRight = !facingRight; // ���� ����

        // ĳ���� ������ �����Ͽ� ������
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
