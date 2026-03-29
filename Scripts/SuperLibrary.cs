using System.Collections.Generic;
using Godot;
using GTNHTC;

namespace SuperLibrary
{
    public class AspectLibrary
    {
        public static readonly Dictionary<Aspect, string> AspTexPathDict = new()
        {
            {Aspect.Ordo, "res://Images/Aspect Icons/Ordo.webp"}, // primal-1
            {Aspect.Perditio, "res://Images/Aspect Icons/Perditio.webp"},
            {Aspect.Aqua, "res://Images/Aspect Icons/Aqua.webp"},
            {Aspect.Ignis, "res://Images/Aspect Icons/Ignis.webp"},
            {Aspect.Terra, "res://Images/Aspect Icons/Terra.webp"},
            {Aspect.Aer, "res://Images/Aspect Icons/Aer.webp"},
            {Aspect.Permutatio, "res://Images/Aspect Icons/Permutatio.webp"}, // compound-2
            {Aspect.Potentia, "res://Images/Aspect Icons/Potentia.webp"},
            {Aspect.Vitreus, "res://Images/Aspect Icons/Vitreus.webp"},
            {Aspect.Motus, "res://Images/Aspect Icons/Motus.webp"},
            {Aspect.Venenum, "res://Images/Aspect Icons/Venenum.webp"},
            {Aspect.Gelum, "res://Images/Aspect Icons/Gelum.webp"},
            {Aspect.Vacuos, "res://Images/Aspect Icons/Vacuos.webp"},
            {Aspect.Victus, "res://Images/Aspect Icons/Victus.webp"},
            {Aspect.Tempestas, "res://Images/Aspect Icons/Tempestas.webp"},
            {Aspect.Lux, "res://Images/Aspect Icons/Lux.webp"},
            {Aspect.Tempus, "res://Images/Aspect Icons/Tempus.webp"}, // compound-3
            {Aspect.Sano, "res://Images/Aspect Icons/Sano.webp"},
            {Aspect.Vinculum, "res://Images/Aspect Icons/Vinculum.webp"},
            {Aspect.Mortuus, "res://Images/Aspect Icons/Mortuus.webp"},
            {Aspect.Limus, "res://Images/Aspect Icons/Limus.webp"},
            {Aspect.Metallum, "res://Images/Aspect Icons/Metallum.webp"},
            {Aspect.Iter, "res://Images/Aspect Icons/Iter.webp"},
            {Aspect.Herba, "res://Images/Aspect Icons/Herba.webp"},
            {Aspect.Volatus, "res://Images/Aspect Icons/Volatus.webp"},
            {Aspect.Arbor, "res://Images/Aspect Icons/Arbor.webp"}, // compound-4
            {Aspect.Praecantatio, "res://Images/Aspect Icons/Praecantatio.webp"},
            {Aspect.Radio, "res://Images/Aspect Icons/Radio.webp"},
            {Aspect.Bestia, "res://Images/Aspect Icons/Bestia.webp"},
            {Aspect.Primordium, "res://Images/Aspect Icons/Primordium.webp"},
            {Aspect.Tenebrae, "res://Images/Aspect Icons/Tenebrae.webp"}, 
            {Aspect.Fames, "res://Images/Aspect Icons/Fames.webp"},
            {Aspect.Vitium, "res://Images/Aspect Icons/Vitium.webp"}, // compound-5
            {Aspect.Infernus, "res://Images/Aspect Icons/Infernus.webp"},
            {Aspect.Auram, "res://Images/Aspect Icons/Auram.webp"},
            {Aspect.Caelum, "res://Images/Aspect Icons/Caelum.webp"}, 
            {Aspect.Exanimis, "res://Images/Aspect Icons/Exanimis.webp"},
            {Aspect.Superbia, "res://Images/Aspect Icons/Superbia.webp"},
            {Aspect.Spiritus, "res://Images/Aspect Icons/Spiritus.webp"},
            {Aspect.Cognitio, "res://Images/Aspect Icons/Cognitio.webp"}, // compound-6
            {Aspect.Sensus, "res://Images/Aspect Icons/Sensus.webp"}, 
            {Aspect.Alienis, "res://Images/Aspect Icons/Alienis.webp"},
            {Aspect.Gula, "res://Images/Aspect Icons/Gula.webp"},
            {Aspect.Astrum, "res://Images/Aspect Icons/Astrum.webp"},
            {Aspect.Magneto, "res://Images/Aspect Icons/Magneto.webp"},
            {Aspect.Aequalitas, "res://Images/Aspect Icons/Aequalitas.webp"}, // compound-7
            {Aspect.Strontio, "res://Images/Aspect Icons/Strontio.webp"}, 
            {Aspect.Corpus, "res://Images/Aspect Icons/Corpus.webp"},
            {Aspect.Desidia, "res://Images/Aspect Icons/Desidia.webp"}, // compound-8
            {Aspect.Humanus, "res://Images/Aspect Icons/Humanus.webp"}, // compound-10
            {Aspect.Invidia, "res://Images/Aspect Icons/Invidia.webp"},
            {Aspect.Instrumentum, "res://Images/Aspect Icons/Instrumentum.webp"}, // compound-11
            {Aspect.Perfodio, "res://Images/Aspect Icons/Perfodio.webp"},
            {Aspect.Luxuria, "res://Images/Aspect Icons/Luxuria.webp"},
            {Aspect.Vesania, "res://Images/Aspect Icons/Vesania.webp"},
            {Aspect.Telum, "res://Images/Aspect Icons/Telum.webp"}, // compound-12
            {Aspect.Tutamen, "res://Images/Aspect Icons/Tutamen.webp"}, 
            {Aspect.Ira, "res://Images/Aspect Icons/Ira.webp"}, // compound-13
            {Aspect.Machina, "res://Images/Aspect Icons/Machina.webp"},
            {Aspect.Messis, "res://Images/Aspect Icons/Messis.webp"},
            {Aspect.Gloria, "res://Images/Aspect Icons/Gloria.webp"},
            {Aspect.Lucrum, "res://Images/Aspect Icons/Lucrum.webp"}, // compound-14
            {Aspect.Electrum, "res://Images/Aspect Icons/Electrum.webp"}, // compound-15
            {Aspect.Tabernus, "res://Images/Aspect Icons/Tabernus.webp"},
            {Aspect.Pannus, "res://Images/Aspect Icons/Pannus.webp"},
            {Aspect.Terminus, "res://Images/Aspect Icons/Terminus.webp"}, // compound-20
            {Aspect.Fabrico, "res://Images/Aspect Icons/Fabrico.webp"}, // compound-21
            {Aspect.Meto, "res://Images/Aspect Icons/Meto.webp"}, // compound-24
            {Aspect.Nebrisum, "res://Images/Aspect Icons/Nebrisum.webp"}, // compound-25
        };

        public static readonly Dictionary<Aspect, int> AspComplexity = new()
        {
            {Aspect.Ordo, 1},
            {Aspect.Perditio, 1},
            {Aspect.Aqua, 1},
            {Aspect.Ignis, 1},
            {Aspect.Terra, 1},
            {Aspect.Aer, 1},
            {Aspect.Permutatio, 2}, // compound-2
            {Aspect.Potentia, 2},
            {Aspect.Vitreus, 2},
            {Aspect.Motus, 2},
            {Aspect.Venenum, 2},
            {Aspect.Gelum, 2},
            {Aspect.Vacuos, 2},
            {Aspect.Victus, 2},
            {Aspect.Tempestas, 2},
            {Aspect.Lux, 2},
            {Aspect.Tempus, 3}, // compound-3
            {Aspect.Sano, 3},
            {Aspect.Vinculum, 3},
            {Aspect.Mortuus, 3},
            {Aspect.Limus, 3},
            {Aspect.Metallum, 3},
            {Aspect.Iter, 3},
            {Aspect.Herba, 3},
            {Aspect.Volatus, 3},
            {Aspect.Arbor, 4}, // compound-4
            {Aspect.Praecantatio, 4},
            {Aspect.Radio, 4},
            {Aspect.Bestia, 4},
            {Aspect.Primordium, 4},
            {Aspect.Tenebrae, 4}, 
            {Aspect.Fames, 4},
            {Aspect.Vitium, 5}, // compound-5
            {Aspect.Infernus, 5},
            {Aspect.Auram, 5},
            {Aspect.Caelum, 5}, 
            {Aspect.Exanimis, 5},
            {Aspect.Superbia, 5},
            {Aspect.Spiritus, 5},
            {Aspect.Cognitio, 6}, // compound-6
            {Aspect.Sensus, 6}, 
            {Aspect.Alienis, 6},
            {Aspect.Gula, 6},
            {Aspect.Astrum, 6},
            {Aspect.Magneto, 6}, 
            {Aspect.Aequalitas, 7}, // compound-7
            {Aspect.Strontio, 7}, 
            {Aspect.Corpus, 7},
            {Aspect.Desidia, 8}, // compound-8
            {Aspect.Humanus, 10}, // compound-10
            {Aspect.Invidia, 10},
            {Aspect.Instrumentum, 11}, // compound-11
            {Aspect.Perfodio, 11},
            {Aspect.Luxuria, 11},
            {Aspect.Vesania, 11},
            {Aspect.Telum, 12}, // compound-12
            {Aspect.Tutamen, 14}, 
            {Aspect.Ira, 13}, // compound-13
            {Aspect.Machina, 13},
            {Aspect.Messis, 13},
            {Aspect.Gloria, 13},
            {Aspect.Lucrum, 14}, // compound-14
            {Aspect.Electrum, 15}, // compound-15
            {Aspect.Tabernus, 15},
            {Aspect.Pannus, 15},
            {Aspect.Terminus, 20}, // compound-20
            {Aspect.Fabrico, 21}, // compound-21
            {Aspect.Meto, 24}, // compound-24
            {Aspect.Nebrisum, 25}, // compound-25
            
        };
    }
}
