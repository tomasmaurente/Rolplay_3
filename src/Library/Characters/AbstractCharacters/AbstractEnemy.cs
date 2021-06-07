namespace RoleplayGame
{
    public abstract class AbstractEnemy : AbstractCharacter
    {
        public abstract int Points { get;}
        public AbstractEnemy(string name)
        :base(name)
        {
            
        }
    }
}