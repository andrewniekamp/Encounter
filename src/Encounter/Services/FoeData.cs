using Encounter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encounter.Services
{
    public interface IFoeData
    {
        IEnumerable<Foe> GetAll();
        Foe Get(int id);
        void Add(Foe newFoe);
        void Generate();
    }

    public class SqlFoeData : IFoeData
    {
        private EncounterDbContext _context;

        public SqlFoeData(EncounterDbContext context)
        {
            _context = context;
        }
        public void Add(Foe newFoe)
        {
            _context.Add(newFoe);
            _context.SaveChanges();
        }

        public void Generate()
        {
            if (!_context.Foes.Any())
            {
                _context.Add(new Foe { Health = 12, Name = "Friendly Faun", SpriteUrl = "/img/foe/faun.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 16, Name = "Green Troll", SpriteUrl = "/img/foe/green-troll.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 20, Name = "Green Ogre", SpriteUrl = "/img/foe/green-ogre.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 24, Name = "Green Goblin", SpriteUrl = "/img/foe/green-goblin.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Salty Insult"),
                });
                _context.Add(new Foe { Health = 34, Name = "Wyrm of the Wood", SpriteUrl = "/img/foe/forest-dragon.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal 2"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                });
                _context.Add(new Foe { Health = 38, Name = "Emerald Dragon", SpriteUrl = "/img/foe/green-dragon.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Forest"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Claw Attack"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                });

                _context.Add(new Foe { Health = 12, Name = "Desert Dweller", SpriteUrl = "/img/foe/desert-dweller.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 16, Name = "Small Golem", SpriteUrl = "/img/foe/golem.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                });
                _context.Add(new Foe { Health = 20, Name = "Mysterious Creatures", SpriteUrl = "/img/foe/flying-monster.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                });
                _context.Add(new Foe { Health = 24, Name = "Ogre", SpriteUrl = "/img/foe/patchwork-ogre.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal 2"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Salty Insult"),
                });
                _context.Add(new Foe { Health = 34, Name = "Iron Horse", SpriteUrl = "/img/foe/iron-horse.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                });
                _context.Add(new Foe { Health = 38, Name = "Large Golem", SpriteUrl = "/img/foe/large-golem.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Desert"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal 2"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                });

                _context.Add(new Foe { Health = 12, Name = "Tiny Imp", SpriteUrl = "/img/foe/imp.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 16, Name = "Red Monster", SpriteUrl = "/img/foe/red-monster.png", Level = 1,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Shove"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Snide Remark"),
                });
                _context.Add(new Foe { Health = 20, Name = "Minotaur", SpriteUrl = "/img/foe/minotaur.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Rude Remark"),
                });
                _context.Add(new Foe { Health = 24, Name = "Red Troll", SpriteUrl = "/img/foe/red-troll.png", Level = 2,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Stab"),
                });
                _context.Add(new Foe { Health = 34, Name = "Werewolf", SpriteUrl = "/img/foe/werewolf.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Claw Attack"),
                });
                _context.Add(new Foe { Health = 38, Name = "Vampire", SpriteUrl = "/img/foe/vampire.png", Level = 3,
                    Scenario = _context.Scenarios.FirstOrDefault(a => a.Name == "Lair"),
                    Ability1 = _context.Abilities.FirstOrDefault(a => a.Name == "Bite"),
                    Ability2 = _context.Abilities.FirstOrDefault(a => a.Name == "Heal 2"),
                });

                _context.SaveChanges();
            }
        }

        public Foe Get(int id)
        {
            return _context.Foes.FirstOrDefault(c => c.FoeId == id);
        }

        public IEnumerable<Foe> GetAll()
        {
            return _context.Foes.ToList();
        }
    }
}
