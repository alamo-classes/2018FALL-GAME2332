using UnityEngine;

public class Direction : MonoBehaviour
{
   public enum Facing { Up, Down, Left, Right};

   Facing myDirection = Facing.Down;

   public const Facing right = Facing.Right;

   public void SetFacing ( Facing dir )
   {
      myDirection = dir;
   }

   public Facing GetFacing ( )
   {
      return myDirection;
   }

}
