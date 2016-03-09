using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harjoitus_07 {
    public class HockeyPlayer : INotifyPropertyChanged {
        private string number;
        public string Number {
            set { number = value; Notify("Number"); Notify("NameAndNumber"); }
            get { return number; }
        }
        private string name;
        public string Name {
            set { name = value; Notify("Name"); Notify("NameAndNumber"); }
            get { return name; }
        }
        public string NameAndNumber {
            get { return name + "#" + number; }
        }
        //constructors
        public HockeyPlayer(string name, string number) {
            this.name = name;
            this.number = number;
        }
        public HockeyPlayer() {

        }
        //methods
        public override string ToString() {
            return name + "#" + number;
        }
        //INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string propName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    public class HockeyTeam {

    #region PROPERTIES
    //huom public field ei kelpaa WPF:n databindingissä, pitää olla Property
    public string Name { get; set; }
    public string City { get; set; }

    #endregion
    #region CONSTRUCTORS

    public HockeyTeam() {
        Name = "";
        City = "Uknown";
    } 

    public HockeyTeam (string name, string city) {
        Name = name;
        City = city;
    }
    #endregion
    public override string ToString() {
        return Name + "@" + City;
    }
}

    public class HockeyLeague {
        //perustetaan SMLiiga, sisältää x kpl joukkueita
        //HUOM: jos halutaan että databindaus huomaa automaattisesti muutokset kokoelmassa käytä observableCollection -kokoelmaa
        List<HockeyTeam> teams = new List<HockeyTeam>();

        public HockeyLeague() {
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
            teams.Add(new HockeyTeam("Sport", "Vaasa"));
        }
        //metodi joka palauttaa liigan joukkueet
        public List<HockeyTeam> GetTeams() {
            return teams;
        }
    }
}
