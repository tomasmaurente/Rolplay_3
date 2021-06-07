using System.Collections.Generic;
namespace RoleplayGame
{
    public class Dwarf: AbstractCharacter
    {
        public Dwarf(string name)
        :base(name)
        {
            this.AddItem(new Axe());
            this.AddItem(new Helmet());
        }
    }
}