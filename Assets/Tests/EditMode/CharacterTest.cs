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
    [DebugLoggerEnablement(false)]
    public void TestCharacterDamageCalculation()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();

        hero.Health = 100;
        hero.Attack = 0;
        hero.BonusAttack = 0;

        var ability = ScriptableObject.CreateInstance<Ability>();
        ability.baseDamage = 10;
        
        hero.ApplyAbilityToSelf(ability, hero.Damage);
        Assert.AreEqual(90, hero.Health);

        hero.BonusAttack = 10;
        hero.ApplyAbilityToSelf(ability, hero.Damage);
        Assert.AreEqual(70, hero.Health);

        hero.Attack = 10;
        hero.ApplyAbilityToSelf(ability, hero.Damage);
        Assert.AreEqual(40, hero.Health);
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

    [Test]
    public void TestUpgradeBonusAttack()
    {
        var chara = new GameObject();
        var hero = chara.AddComponent<Hero>();
        hero.UpgradeBonusAttack();

        Assert.AreEqual(2, hero.BonusAttack);

        hero.UpgradeBonusAttack();

        Assert.AreEqual(4, hero.BonusAttack);
    }
}
