using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard: AbstractMagicalCharacter
    {
        public Wizard(string name)
        :base(name)
        {
            this.AddItem(new Staff());
        }
    }
}