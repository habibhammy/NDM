using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.ViewModel
{

    
    public class DefintionVIewModel
    {
        private List<Definition> defs;
        public List<Definition> Defs
        {
            get { return defs; }
            set
            {
                defs = value;
                RaisePropertyCHanged();
            }
        }

        public DefintionVIewModel()
        {
            defs = new List<Definition>(new[]
            {
                new Definition
                { Terme="BIO",Def="désigne les produits issus de l’agriculture biologique, autrement dit qui revendique la non-"
                                    +"utilisation totale de produits chimiques. En France, ils doivent contenir au moins 95 % d'ingrédients"
                                    +"issus d'un mode de production biologique « mettant en œuvre des pratiques agronomiques et"
                                    +"d'élevage respectueuses des équilibres naturels de l'environnement et du bien-être animal ». Ils ne"
                                    +"peuvent contenir aucun organisme génétiquement modifié (O.G.M.)" },
                new Definition
                { Terme="Equitable",Def="désigne les marchandises issues du commerce équitable, c’est-à- dire qui sont issues d’un"
                                    +"partenariat commercial fondé sur le dialogue, la transparence et le respect, dont l’objectif est de"
                                    +"parvenir à une plus grande équité dans le commerce mondial. Le commerce équitable contribue au"
                                    +"développement durable en offrant de meilleures conditions commerciales et en garantissant les"
                                    +"droits des producteurs et des travailleurs marginalisés, en particulier ceux du Sud."
                                    +"\n Les organisations du commerce équitable, soutenues par de nombreux consommateurs, s’engagent"
                                    +"activement à soutenir les producteurs, à sensibiliser l’opinion publique et à mener campagne pour"
                                    +"favoriser des changements dans les règles et les pratiques du commerce international conventionnel." },
                new Definition
                { Terme="Vrac",Def="désigne les marchandises qui ne sont pas emballées." }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

    }
}
