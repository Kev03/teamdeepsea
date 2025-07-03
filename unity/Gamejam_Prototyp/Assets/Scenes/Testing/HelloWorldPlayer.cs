using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace ThikkGames.TeamDeepSea
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public UnityEvent OnSubmarineJoined;
        public UnityEvent OnDiverJoined;

        [SerializeField]
        private float speed = 1.0f;

        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }

            if(HelloWorldManager.Instance.PlayerType == "diver")
            {
                //OnDiverJoined?.Invoke();
            }else if(HelloWorldManager.Instance.PlayerType == "submarine")
            {
                //OnSubmarineJoined?.Invoke();
            }

        }

        public void Move()
        {
            SubmitPositionRequestRpc(Vector3.zero);
        }

        public void Move(Direction direction)
        {
            if (!IsOwner) return;

            Vector3 movement = Vector3.zero;
            switch (direction)
            {
                case Direction.up: { movement += new Vector3(0, -1, 0); break; }
                case Direction.down: { movement += new Vector3(0, 1, 0); break; }
                case Direction.left: { movement += new Vector3(-1, 0, 0); break; }
                case Direction.right: { movement += new Vector3(1, 0, 0); break; }
                default: { break; }
            }

            SubmitPositionRequestRpc(movement);
        }

        [Rpc(SendTo.Server)]
        private void SubmitPositionRequestRpc(Vector3 direction, RpcParams rpcParams = default)
        {
            Position.Value += Time.deltaTime * speed * direction;
        }

        private void Update()
        {
            transform.position = Position.Value;
        }

        public void OnMovementInput(Direction direction)
        {
            HelloWorldManager.Instance.MovePlayer(direction);
        }

    }
}

