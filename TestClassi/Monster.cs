using System;
using System.Windows.Forms;

namespace MortaraMonster
{
    class Monster
    {
        public string name;
        public int maxHp;
        public int curHp;
        public int damage;
        
        public Monster(string name, int maxHp, int damage, TextBox t)
        {
            this.name = name;
            this.maxHp = maxHp;
            curHp = maxHp;
            this.damage = damage;
            describe(t);
        }

        public string describe()
        {
            string output = "Questo è " + name + "\r\n";
            output += "HP: " + curHp + "\r\n";
            output += "DAMAGE: " + damage + "\r\n";
            output += "_____________________________________" + "\r\n";


            return output;
        }

        public void describe(TextBox t)
        {
            t.Text += describe();
        }

        public void attack(Monster target, TextBox t)
        {
            if (target.curHp <= 0)
            {
                t.Text += (target.name + " è già esausto, non infierire." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }

            t.Text += (name + " attacca " + target.name + "\r\n");
            t.Text += (name + " fa " + damage + " danni a " + target.name + "\r\n");
            target.curHp -= damage;
            
            if (target.curHp <= 0 )
            {
                target.curHp = 0;
                t.Text += (target.name + " è esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
            } else
            {
                t.Text += ("a " + target.name + " rimangono " + target.curHp + " hp" + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
            }
        }
    }
}