using UnityEngine;


namespace VladB.ZigZag.MainPlayer
{
    [RequireComponent(typeof(PlayerComponents))]
    public class Player : MonoBehaviour
    {
        public PlayerComponents PlayerComponents { get; private set; }

        public void Init()
        {
            PlayerComponents = GetComponent<PlayerComponents>();

            PlayerComponents.Mover.Init(PlayerComponents.MainRigidBody);
        }

        public void StartMoving()
        {
            PlayerComponents.Mover.StartMoving();
        }

        public void ResetPlayer()
        {
            PlayerComponents.Mover.ResetMoving();
        }
    }
}