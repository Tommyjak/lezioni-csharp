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
        public int healfactor;
        
        public Monster(string name, int maxHp, int damage, TextBox t, int healfactor = 0)//creazione parametro opzionale//solo dopo quelli obbligatori!
        {
            this.name = name;
            this.maxHp = maxHp;
            curHp = maxHp;
            this.damage = damage;
            this.healfactor = healfactor;
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
                t.Text += (target.name + "non può attacare, è gia esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }
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

        public void heal(Monster target, TextBox t)
        {
            if (target.healfactor == 0)
            {
                t.Text += (target.name + "non ha potere di cura" +"\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }
            if (target.curHp <= 0)
            {
                t.Text += ("Non puoi curare" + target.name + " , è già esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }

            target.curHp += target.healfactor;

            if (target.curHp >= target.maxHp)
            {
                t.Text += (target.name + "si è curato." + "\r\n");
                t.Text += (target.name + "adesso ha " + target.curHp + "/" + target.maxHp + "HP");
                t.Text += ("_____________________________________" + "\r\n");
            }

        }
    }
}