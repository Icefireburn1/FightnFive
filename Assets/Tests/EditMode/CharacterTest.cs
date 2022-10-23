using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterTest
{
    [Test]
    public void TestCharacterDead()
    {
        var chara = new GameObject();
        var ability = ScriptableObject.CreateInstance<Ability>();
        ability.baseDamage = 1000;
        var hero = chara.AddComponent<Hero>();
        hero.Health = 10;
        hero.ApplyAbilityToSelf(ability, 1);

        Assert.IsTrue(!hero.IsAlive);
    }

    [Test]
    public void TestCharacterDamageCalculation()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();
        hero.Health = 100;

        var ability = ScriptableObject.CreateInstance<Ability>();
        ability.baseDamage = 10;
        
        hero.ApplyAbilityToSelf(ability, 10);

        Assert.IsTrue(hero.Health == 80);
    }

    [Test]
    public void TestCharacterMaxHealthHealCalculation()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();
        hero.Health = 100;

        var ability = ScriptableObject.CreateInstance<Ability>();
        ability.healAmt = 10;

        hero.ApplyAbilityToSelf(ability, 10);

        Assert.IsTrue(hero.Health == 100);
    }

    [Test]
    public void TestCharacterHealCalculation()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();
        hero.MaxHealth = 100;
        hero.Health = 80;

        var ability = ScriptableObject.CreateInstance<Ability>();
        ability.healAmt = 10;

        hero.ApplyAbilityToSelf(ability, 10);

        Assert.IsTrue(hero.Health == 90);
    }

    [Test]
    public void TestCharacterFullHealCalculation()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();
        hero.MaxHealth = 100;
        hero.Health = 80;

        hero.HealToFull();

        Assert.IsTrue(hero.Health == hero.MaxHealth);
    }
}
