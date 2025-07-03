using Unity.Netcode;
using UnityEngine;

namespace ThikkGames.TeamDeepSea
{
    /// <summary>
    /// Add this component to the same GameObject as
    /// the NetworkManager component.
    /// </summary>
    public class HelloWorldManager : MonoBehaviour
    {
        public static HelloWorldManager Instance { get; private set; }

        private NetworkManager m_NetworkManager;

        private string playerType = "diver";
        public string PlayerType { get { return playerType; } }

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;

            m_NetworkManager = GetComponent<NetworkManager>();
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (!m_NetworkManager.IsClient && !m_NetworkManager.IsServer)
            {
                StartButtons();
            }
            else
            {
                StatusLabels();

                SubmitNewPosition();
            }

            GUILayout.EndArea();
        }

        private void StartButtons()
        {
            if (GUILayout.Button("Host"))
            {
                playerType = "submarine";
                m_NetworkManager.StartHost();
            }
            if (GUILayout.Button("Client"))
            {
                playerType = "diver";
                m_NetworkManager.StartClient();
            }
            if (GUILayout.Button("Server")) m_NetworkManager.StartServer();
        }

        private void StatusLabels()
        {
            var mode = m_NetworkManager.IsHost ?
                "Host" : m_NetworkManager.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                m_NetworkManager.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

        private void SubmitNewPosition()
        {
            if (GUILayout.Button(m_NetworkManager.IsServer ? "Move" : "Request Position Change"))
            {
                if (m_NetworkManager.IsServer && !m_NetworkManager.IsClient)
                {
                    foreach (ulong uid in m_NetworkManager.ConnectedClientsIds)
                        m_NetworkManager.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<HelloWorldPlayer>().Move();
                }
                else
                {
                    var playerObject = m_NetworkManager.SpawnManager.GetLocalPlayerObject();                        
                    var player = playerObject.GetComponent<HelloWorldPlayer>();
                    player.Move();
                }
            }
        }
        
        public void MovePlayer(Direction direction)
        {
            Debug.Log("Move it, Baby");
            var playerObject = m_NetworkManager.SpawnManager.GetLocalPlayerObject();
            var player = playerObject.GetComponent<HelloWorldPlayer>();

            player.Move(direction);
        }

    }
}
