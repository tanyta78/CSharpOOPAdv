﻿using Blobs.Interfaces;
using System;

namespace Blobs.Entities
{
    public class Blob
    {
        private int health;
        private IAttack attack;
        private IBehavior behavior;
        private int initialHealth;
        private bool behaviourTriggeredInThisTurn;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.attack = attack;
            this.behavior = behavior;

            this.initialHealth = health;
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.health < 0)
                {
                    this.health = 0;
                }

                this.CheckForBehaviorTrigger();
            }
        }

        private void CheckForBehaviorTrigger()
        {
            if (this.Health <= this.initialHealth / 2 && !this.behavior.IsTriggered)
            {
                this.TriggerBehavior();
            }
        }

        private void TriggerBehavior()
        {
            if (this.behavior.IsTriggered)
            {
                throw new ArgumentException();
            }

            this.behavior.Trigger(this);
            this.behaviourTriggeredInThisTurn = true;
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }

        public void Attack(Blob target)
        {
            if (target.IsAlive() && this.IsAlive())
            {
                this.attack.Execute(this, target);
            }
        }

        public void MoveToNextTurn()
        {
            if (this.behavior.IsTriggered && !this.behaviourTriggeredInThisTurn)
            {
                this.behavior.ApplyPostTriggerEffect(this);
            }

            this.behaviourTriggeredInThisTurn = false;
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }

        public string Name { get; set; }
    }
}