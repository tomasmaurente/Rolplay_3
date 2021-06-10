using System.Collections.Generic;
namespace RoleplayGame
{
    public class Avenger : AbstractEnemy
    {
        public override int Points
        {
            get
            {
                return 45;
            }
        }
        public Avenger(string name)
        :base(name)
        {
        }
    }
}