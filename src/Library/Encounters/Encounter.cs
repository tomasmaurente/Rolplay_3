using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounter
    {
        public int DoEncounter(List<AbstractEnemy> enemies, List<AbstractHeroe> heroes)
        {
            int attack = 0;
            while (enemies.Count > 0 && heroes.Count > 0)
            {
                int i = 0;
                // Los enemigos atacan primero.
                // Todos los enemigos atacan.
                foreach (AbstractEnemy enemy in enemies)
                {
                    heroes[i].ReceiveAttack(enemy.AttackValue);
                    attack ++;
                    if (heroes[i].Health == 0)
                    {
                        heroes.RemoveAt(i);
                    }
                    else
                    {
                        i = i + 1;
                        i = i % heroes.Count;
                    }
                }

                i = 0;
                foreach (AbstractHeroe heroe in heroes)
                {
                    if (i == enemies.Count)
                    {
                        break;
                    }

                    enemies[i].ReceiveAttack(heroe.AttackValue);
                    attack ++;

                    if (enemies[i].Health == 0)
                    {
                        heroe.AddPoints(enemies[i].Points);
                        if (enemies[i].Points >= 5)
                        {
                            heroe.Cure();
                        }
                        enemies.Remove(enemies[i]);
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }
            return attack;
        }
    }
}