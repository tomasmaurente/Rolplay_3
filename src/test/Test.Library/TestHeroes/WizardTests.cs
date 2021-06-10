using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class WizardTests
    {
        private Wizard merlin;
        public ISpell wingardiumLeviosa;
        private SpellsBook deathNote;
        private Staff grandpaStick;

        [SetUp]
        public void Setup()
        { 
            // Arrange.
            this.merlin = new Wizard("Merlin");
            this.wingardiumLeviosa = new SpellOne();
            this.deathNote = new SpellsBook();
            this.grandpaStick = new Staff();
        }

        // Se testea valor de ataque.
        [Test]
        public void TestAttackValue()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Assert.
            Assert.AreEqual(170,merlin.AttackValue);
        }


        // Se testea valor de defensa con libro de encantamientos y bastón, ya que el codigo no permite tener uno y no otro, o ninguno.
        [Test]
        public void TestDefenseValue()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Assert.
            Assert.AreEqual(170,merlin.DefenseValue);
        }

        // Se testea el metodo ReceiveAttack.
        // Caso de numero negativo, se espera que no se modifique la salud.
        [Test]
        public void TestReceiveNegativeAttack()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Act.
            int healthBeforeAttack = merlin.Health;
            merlin.ReceiveAttack(-10000);
            int healthAfterAttack = merlin.Health;

            // Assert.
            Assert.AreEqual(healthBeforeAttack,healthAfterAttack);
        }

        // Se testea la salud despues de un ataque.
        // La vida sigue intacta debido a que su defensa es mayor que el ataque.
        [Test]
        public void TestHealthWithLittleAttack()
        {
            // Arrange.
            Knight knight = new Knight("Batman");
            knight.AddItem(new Sword());

            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);
            
            // Act.
            merlin.ReceiveAttack(knight.AttackValue);

            // Assert.
            Assert.AreEqual(100, merlin.Health);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque.
        [Test]
        public void TestHealthWithBigAttack()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);
            
            // Act.
            merlin.ReceiveAttack(180);

            // Assert.
            Assert.Less(merlin.Health,100);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque, y ademas en este caso deberia ser 0 y no menor.
        [Test]
        public void TestHealthWithEnourmousAttack()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Act.
            merlin.ReceiveAttack(10000);

            // Assert.
            Assert.Zero(merlin.Health);
        }

        // Se testea la salud despues de un ataque que mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Act.
            merlin.ReceiveAttack(10000);
            merlin.Cure();

            // Assert.
            Assert.AreEqual(100, merlin.Health);   
        }

        // Se testea la salud despues de un ataque que no mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure2()
        {
            // Arrange.
            deathNote.AddSpell(this.wingardiumLeviosa);
            merlin.AddItem(deathNote);
            merlin.AddItem(grandpaStick);

            // Act.
            merlin.ReceiveAttack(220);
            merlin.Cure();

            // Assert.
            Assert.AreEqual(100, merlin.Health);   
        }
    }
}