namespace RoleplayGame
{
    public abstract class AbstractHeroe : AbstractCharacter
    {
        public virtual int Points {get; private set; }

        public AbstractHeroe(string name)
        :base(name)
        {
            this.Points = 0;
        }

        public void AddPoints(int toAdd)
        {
            Points += toAdd;
        }
    }
}