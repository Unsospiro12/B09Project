using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject startBlock;
    public GameObject[] blocks;

    public GameObject nowBlock;

    const int blockDistance = 60;
    private float updateDelayDistance = 0.05f;

    private int nowIdx;

    private void Awake()
    {
        Instantiate(startBlock, this.transform);

        CreateBlock(0);
    }

    private void Update()
    {
        if(nowBlock.transform.position.z <= 0)
        {
            // 오차 범위 적용
            CreateBlock(nowBlock.transform.position.z - updateDelayDistance);
        }
    }

    public void CreateBlock(float nowBlcokPosZ)
    {
        // 블록의 position.z 값이 마이너스가 되는 시점에 다음 블록을 미리 생성해 주어야 한다. (블록 중 랜덤으로)
        // 블록의 종류는 배열에서 랜덤한 종류를 생성하도록 한다. (단, 이전에 나왔던 블록은 연속으로 등장하지 않는다.)
        int randomIdx = Random.Range(0, blocks.Length);

        while (nowIdx == randomIdx)
        {
            randomIdx = Random.Range(0, blocks.Length);
        }
        nowIdx = randomIdx;

        nowBlock = Instantiate(blocks[randomIdx], this.transform);

        // 고정 값 만큼 이동시켜 블록이 연결되도록.
        nowBlock.transform.position += new Vector3(0, 0, nowBlcokPosZ + blockDistance);
    }
}
