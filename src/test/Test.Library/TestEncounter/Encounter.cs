using NUnit.Framework;
using System;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class EncounterTest
    {
        private Encounter _encounter;
        private int _rounds;
        // Heores.
        private List<AbstractHeroe> _heroes;
        private Archer _archer;
        private Dwarf _dwarf;
        private Knight _knight;
        private Wizard _wizard;

        // Enemies.
        private List<AbstractEnemy> _enemies;
        private Assasin _assasin;
        private Avenger _avenger;
        private Joker _joker;

        [SetUp]
        public void Setup()
        {
            this._encounter = new Encounter();
            this._heroes = new List<AbstractHeroe>();
            this._enemies = new List<AbstractEnemy>();

            this._archer = new Archer(null);
            this._dwarf = new Dwarf(null);
            this._knight = new Knight(null);
            this._wizard = new Wizard(null);

            this._assasin = new Assasin(null);
            this._avenger = new Avenger(null);
            this._joker = new Joker(null);
        }

        [Test]
        public void EmptyEncounter()
        {
            this._rounds = this._encounter.DoEncounter(this._enemies, this._heroes);
            Assert.IsTrue(this._enemies.Count == 0 && this._heroes.Count == 0 && this._rounds == 0);
        }
        [Test]
        public void OneAlone1()
        {
            this._enemies.Add(this._joker);
            this._rounds = this._encounter.DoEncounter(this._enemies, this._heroes);
            Assert.IsTrue(this._enemies.Count == 1 && this._heroes.Count == 0 && this._rounds == 0);
        }
        [Test]
        public void OneAlone2()
        {
            this._heroes.Add(this._archer);
            this._rounds = this._encounter.DoEncounter(this._enemies, this._heroes);
            Assert.IsTrue(this._enemies.Count == 0 && this._heroes.Count == 1 && this._rounds == 0);
        }
        [Test]
        public void OneVsOne()
        {
            this._joker.AddItem(new Axe());
            this._enemies.Add(this._joker);
            this._heroes.Add(this._wizard);

            // Joker: Damage: 25. Defense = 0.
            // Wizard: Damage: 0. Defense = 0.

            this._rounds = this._encounter.DoEncounter(this._enemies, this._heroes);
            Assert.IsTrue(this._enemies.Count == 1 && this._heroes.Count == 0 && this._rounds == 7);
        }

        [Test]
        public void BigParty()
        {
            this._archer.AddItem(new Helmet()); // Defense: 18
            this._dwarf.AddItem(new Bow()); // Damage: 15
            this._knight.AddItem(new Sword()); // Damage: 20
            this._knight.AddItem(new Shield()); // Damage: 14
            this._wizard.AddItem(new Staff()); // Damage: 100 Defense: 100

            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            this._assasin.AddItem(book); // Damage: 70 Defense: 70

            this._avenger.AddItem(new Axe()); // Damage: 25
            this._joker.AddItem(new Armor()); // Defense: 25

            this._heroes.Add(this._archer);
            this._heroes.Add(this._dwarf);
            this._heroes.Add(this._knight);
            this._heroes.Add(this._wizard);

            this._enemies.Add(this._assasin);
            this._enemies.Add(this._avenger);
            this._enemies.Add(this._joker);

            this._rounds = this._encounter.DoEncounter(this._enemies, this._heroes);

            Assert.IsTrue(
                // The enemies lose.
                this._enemies.Count == 0 &&
                // Only one Hero survived.
                this._heroes.Count == 1 &&
                // The Wizard had survived.
                this._heroes[0] == this._wizard
                );

        }
    }
}