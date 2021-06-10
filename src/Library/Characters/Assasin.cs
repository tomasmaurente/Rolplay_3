using System.Collections.Generic;
namespace RoleplayGame
{
    public class Assasin : AbstractMagicalEnemy
    {   
        public override int Points 
        {
            get
            {
                return 50;
            }
        }
        
        public Assasin(string name)
        :base(name)
        {            
        }
    }
}