using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerattack : MonoBehaviour
{
    float timer = 0f;
    LineRenderer line; // line 객체
    Transform ShootPoint; // 발사 지점
    // Start is called before the first frame update
    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>(); // LineRenderer로 객체 생성
        line.enabled = false; // line 보이기
        ShootPoint = GameObject.Find("ShootPoint").GetComponent<Transform>(); // 하이어라키에서 ShootPoint를 찾아 위치값 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (CrossPlatformInputManager.GetButton("Fire1") && timer >= 0.2f)
        {
            Shoot();
            timer = 0f;
        }
        if (timer >= 0.05f) // 발사하고 0.05초가 지나면 라인 사라지기
        {
            line.enabled = false;
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward); // ShootPoint의 위치에서 알 방향으로 ray 객체 생성
        RaycastHit hit; // ray에 닿은 오브젝트는 hit에 저장
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable"))) // ray에 Shootable 레이어가 닿았다면 (ray, out hit, 최대 충돌거리, layermash)
        {
            enemyhealth enemyhealth = hit.collider.GetComponent<enemyhealth>(); // hit(ray에 닿은 오브젝트1의 enemyhealth 함수에서 Damage 함수에 50을 호출
            if (enemyhealth != null)
            {
                enemyhealth.Damage(50);
            }
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, hit.point); // hit의 지점까지 라인 그려지기
        }
        else // ray에 Shootable 레이어가 닿지 않는다면
        {
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, hit.point + ray.direction); // hit의 지점부터 ray의 앞방향으로 100만큼 라인 그려지기
        }
    }
}
