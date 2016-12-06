using System;
using System.Windows.Forms;

namespace MortaraMonster
{
    class Monster
    {
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
        }

        private int _maxHp;
        public int maxHp
        {
            get
            {
                return _maxHp;
            }
        }

        private int _curHp;
        public int curHp
        {
            set
            {
                if (value < 0)
                    value = 0;

                else if (value > _maxHp)
                    value = _maxHp;

            }

            get
            {
                return _curHp;
            }
        }

        private int _damage;
        public int damage
        {
            get
            {
                return _damage;
            }
        }

        private int _healfactor;
        public int healfactor
        {
            get
            {
                return _healfactor;
            }
        }


        public Monster(string name, int maxHp, int damage, TextBox t, int healfactor = 0)//creazione parametro opzionale//solo dopo quelli obbligatori!
        {
            _name = name;
            _maxHp = maxHp;
            _curHp = maxHp;
            _damage = damage;
            _healfactor = healfactor;
            describe(t);
        }

        public string describe()
        {
            string output = "Questo è " + _name + "\r\n";
            output += "HP: " + _curHp + "\r\n";
            output += "DAMAGE: " + _damage + "\r\n";
            output += "PC: " + _healfactor + "\r\n";
            output += "_____________________________________" + "\r\n";


            return output;
        }

        public void describe(TextBox t)
        {
            t.Text += describe();
        }

        public void attack(Monster target, TextBox t)
        {
            if (target._curHp <= 0)
            {
                t.Text += (target._name + "non può attacare, è gia esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }
            if (target.curHp <= 0)
            {
                t.Text += (target._name + " è già esausto, non infierire." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }

            t.Text += (_name + " attacca " + target._name + "\r\n");
            t.Text += (_name + " fa " + _damage + " danni a " + target._name + "\r\n");
            target._curHp -= _damage;
            
            if (target._curHp <= 0 )
            {
                target._curHp = 0;
                t.Text += (target._name + " è esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
            } else
            {
                t.Text += ("a " + target._name + " rimangono " + target._curHp + " hp" + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
            }
        }

        public void heal(Monster target, TextBox t)
        {
            if (_healfactor == 0)
            {
                t.Text += (_name + " non ha potere di cura" +"\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }
            if (_curHp <= 0)
            {
                t.Text += ("Non puoi curare nessuno, sei già esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }

            if (target._curHp <= 0)
            {
                t.Text += ("Non puoi curare" + target._name + " , è già esausto." + "\r\n");
                t.Text += ("_____________________________________" + "\r\n");
                return;
            }

            target._curHp += target._healfactor;

            if (target._curHp >= target._maxHp)
            {
                target._curHp = target._maxHp;
            }

            t.Text += (_name + " usa cura su " + target._name + "\r\n");
            t.Text += (target._name + " è stato curato e adesso ha " + target._curHp + "/" + target._maxHp + "HP");

        }
    }
}