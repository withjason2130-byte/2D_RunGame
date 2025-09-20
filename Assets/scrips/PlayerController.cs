using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathAudio;  // 오디오 세팅
    public AudioClip jumpAudio;  // 오디오 세팅

    public float jumpForce = 500f; // 500의 점프힘 설정
    private int jumpCnt = 0; //점프의 횟수
    private bool inGrounded = false;//플레이어가 땅에 닿았는지 판별
    private bool isDead = false; //플레이어가 죽었는지 판별

    private Rigidbody2D rb; // 리지드바디 컴포넌트

    private Animator animator; // 애니메이션 처리
    private AudioSource PlayerAudio; // 오디오 소스 처리


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 리지드바이 컴포넌트 적용
        animator = GetComponent<Animator>(); // 애니메이션 컴포넌트 적용
        PlayerAudio = GetComponent<AudioSource>(); //오디오 소스 적용
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) // 플레이어가 죽었을 경우 , Update 탈출
            return;
        Jump(); 
    }

    public void Jump()
    {
        //마우스 왼쪽 버튼을 눌렀을 때 ,그리고 점프 횟수가 2회 미만일 경우 실행
        if (Input.GetMouseButtonDown(0) && jumpCnt < 2)
        {
            jumpCnt++;  //점프 횟수 증가 
            rb.velocity = Vector2.zero;  //점프 전 기존 속도를 초기화
            rb.AddForce(new Vector2(0, jumpForce)); // 위쪽으로 점프 힘 500만큼 추가

            PlayerAudio.clip = jumpAudio;
            PlayerAudio.Play();        //점프 사운드 재생(추후 처리)
            animator.SetBool("Jump", true);
        }
        //마우스 왼쪽 버튼을 뗏을 때 , 캐릭터가 상승 중인 경우
        else if (Input.GetMouseButtonUp(0) && rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity * 0.5f; //속도를 절반으로 줄여 점프를 부드럽게 멈춤
        }
        //animator.SetBool("Grounded", isGrounded); //애니메이션 처리
    }

    private void Die()
    {
        //Player Death 처리 부분
        animator.SetTrigger("Die");

        PlayerAudio.clip = deathAudio;
        PlayerAudio.Play();

        rb.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.Dead_Trigger();
        Invoke("GameOver", 3f);
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 콜라이더를 가진 obs와 충돌 감지 부분
        if(collision.tag == "Dead" && !isDead)
        {
            Die();
        }
        if(collision.tag == "Enemy" && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //땅과의 닿았음 감지
        //두 물체 사이의 여러 충돌 지점 중 첫 번째 충돌 정보를 가져옴 충돌
        //표면이 위쪽 방향일때 1에 가까움
        if (collision.contacts[0].normal.y > 0.7f)
        {
            Debug.Log("충돌상태");
            inGrounded = true;  //땅에 닿았으면 참으로 변경
            jumpCnt = 0;    //점프를 0으로 변경 
            animator.SetBool("Jump", false); //애니메이션 처리

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //땅에 떨어졌음 감지
        inGrounded = false;
    }
}
