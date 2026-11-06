using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class 镜头脚本 : MonoBehaviour
{
    public Transform Target;//读取人物的坐标
    public float SmoothSpeed=5;//平滑度,越大跟越紧;
    public Vector3 offset=new Vector3(0,0,-10);//offset是偏移量
    
    void LateUpdate()//LateUpdate保证摄像头的移动放在每帧最后再进行
    {
        Vector3 desiredPos = Target.position + offset;//算出摄像头往哪里走
        transform.position = Vector3.Lerp(transform.position, desiredPos, SmoothSpeed * Time.deltaTime);
        //让摄像头以平滑的速度移动到从原来的位置运动到要去的位置之间的一个点,每帧执行一次
        //去到那个点后,再向剩余距离的中的一个点前进,一直不断前进.
        //接近要去位置时,前进距离变小,由此变慢;前进距离变大,由此变快
    }
}
