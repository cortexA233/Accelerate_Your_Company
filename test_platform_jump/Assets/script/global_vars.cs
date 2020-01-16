using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_vars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class glob
{
    public static int isiii = 0;
    public static float cur_life=100f, max_life = 100f;//陪伴值及最大陪伴值
    public static float respawn_posx = -8f, respawn_posy = -0.5f;
    public static int weapon_status = 0;//表示攻击类型，1为前冲鞭打，2为跳跃鞭打
    public static int buddy_dir = 1;//1表示主角在company左边，company会往右边逃跑。-1则相反
    public static int is_key = 0;
    public static int is_switch = 0;
    public static int is_escape = 1;//表示伙伴是否发现彩蛋山脉
    public static int is_rush = 0;//表示伙伴是否处于冲刺状态，0表示否
    public static int is_stranding_player = 0, is_stranding_buddy = 0;//表示是否攀附在绳子上，0表示否
    public static int is_ground = 0, buddy_is_ground = 0;//表示主角/伙伴是否在地表上，0表示否
    public static int iswin_player = 0, iswin_buddy = 0;
    public static int player_direcion = -1;
    public static int buddy_direcion = -1;
    public static void respawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        GameObject buddy = GameObject.FindGameObjectWithTag("buddy");
        player.transform.position = new Vector2(respawn_posx, respawn_posy);
        buddy.transform.position = new Vector2(respawn_posx + 2f, respawn_posy + 0.5f);
        cur_life = 100f;
    }
    
}