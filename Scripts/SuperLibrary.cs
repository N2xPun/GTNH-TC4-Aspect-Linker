using System.Collections.Generic;
using Godot;
using GTNHTC;

namespace SuperLibrary
{
    public class AspectLibrary
    {
        public static readonly Dictionary<Aspectus, string> AspTexPathDict = new()
        {
            {Aspectus.Ordo, "res://Images/Aspect Icons/Ordo.webp"}, // primal-1
            {Aspectus.Perditio, "res://Images/Aspect Icons/Perditio.webp"},
            {Aspectus.Aqua, "res://Images/Aspect Icons/Aqua.webp"},
            {Aspectus.Ignis, "res://Images/Aspect Icons/Ignis.webp"},
            {Aspectus.Terra, "res://Images/Aspect Icons/Terra.webp"},
            {Aspectus.Aer, "res://Images/Aspect Icons/Aer.webp"},
            {Aspectus.Permutatio, "res://Images/Aspect Icons/Permutatio.webp"}, // compound-2
            {Aspectus.Potentia, "res://Images/Aspect Icons/Potentia.webp"},
            {Aspectus.Vitreus, "res://Images/Aspect Icons/Vitreus.webp"},
            {Aspectus.Motus, "res://Images/Aspect Icons/Motus.webp"},
            {Aspectus.Venenum, "res://Images/Aspect Icons/Venenum.webp"},
            {Aspectus.Gelum, "res://Images/Aspect Icons/Gelum.webp"},
            {Aspectus.Vacuos, "res://Images/Aspect Icons/Vacuos.webp"},
            {Aspectus.Victus, "res://Images/Aspect Icons/Victus.webp"},
            {Aspectus.Tempestas, "res://Images/Aspect Icons/Tempestas.webp"},
            {Aspectus.Lux, "res://Images/Aspect Icons/Lux.webp"},
            {Aspectus.Tempus, "res://Images/Aspect Icons/Tempus.webp"}, // compound-3
            {Aspectus.Sano, "res://Images/Aspect Icons/Sano.webp"},
            {Aspectus.Vinculum, "res://Images/Aspect Icons/Vinculum.webp"},
            {Aspectus.Mortuus, "res://Images/Aspect Icons/Mortuus.webp"},
            {Aspectus.Limus, "res://Images/Aspect Icons/Limus.webp"},
            {Aspectus.Metallum, "res://Images/Aspect Icons/Metallum.webp"},
            {Aspectus.Iter, "res://Images/Aspect Icons/Iter.webp"},
            {Aspectus.Herba, "res://Images/Aspect Icons/Herba.webp"},
            {Aspectus.Volatus, "res://Images/Aspect Icons/Volatus.webp"},
            {Aspectus.Arbor, "res://Images/Aspect Icons/Arbor.webp"}, // compound-4
            {Aspectus.Praecantatio, "res://Images/Aspect Icons/Praecantatio.webp"},
            {Aspectus.Radio, "res://Images/Aspect Icons/Radio.webp"},
            {Aspectus.Bestia, "res://Images/Aspect Icons/Bestia.webp"},
            {Aspectus.Primordium, "res://Images/Aspect Icons/Primordium.webp"},
            {Aspectus.Tenebrae, "res://Images/Aspect Icons/Tenebrae.webp"}, 
            {Aspectus.Fames, "res://Images/Aspect Icons/Fames.webp"},
            {Aspectus.Vitium, "res://Images/Aspect Icons/Vitium.webp"}, // compound-5
            {Aspectus.Infernus, "res://Images/Aspect Icons/Infernus.webp"},
            {Aspectus.Auram, "res://Images/Aspect Icons/Auram.webp"},
            {Aspectus.Caelum, "res://Images/Aspect Icons/Caelum.webp"}, 
            {Aspectus.Exanimis, "res://Images/Aspect Icons/Exanimis.webp"},
            {Aspectus.Superbia, "res://Images/Aspect Icons/Superbia.webp"},
            {Aspectus.Spiritus, "res://Images/Aspect Icons/Spiritus.webp"},
            {Aspectus.Cognitio, "res://Images/Aspect Icons/Cognitio.webp"}, // compound-6
            {Aspectus.Sensus, "res://Images/Aspect Icons/Sensus.webp"}, 
            {Aspectus.Alienis, "res://Images/Aspect Icons/Alienis.webp"},
            {Aspectus.Gula, "res://Images/Aspect Icons/Gula.webp"},
            {Aspectus.Astrum, "res://Images/Aspect Icons/Astrum.webp"},
            {Aspectus.Magneto, "res://Images/Aspect Icons/Magneto.webp"}, 
        };

        public static readonly Dictionary<Aspectus, int> AspComplexity = new()
        {
            {Aspectus.Ordo, 1},
            {Aspectus.Perditio, 1},
            {Aspectus.Aqua, 1},
            {Aspectus.Ignis, 1},
            {Aspectus.Terra, 1},
            {Aspectus.Aer, 1},
            {Aspectus.Permutatio, 2}, // compound-2
            {Aspectus.Potentia, 2},
            {Aspectus.Vitreus, 2},
            {Aspectus.Motus, 2},
            {Aspectus.Venenum, 2},
            {Aspectus.Gelum, 2},
            {Aspectus.Vacuos, 2},
            {Aspectus.Victus, 2},
            {Aspectus.Tempestas, 2},
            {Aspectus.Lux, 2},
            {Aspectus.Tempus, 3}, // compound-3
            {Aspectus.Sano, 3},
            {Aspectus.Vinculum, 3},
            {Aspectus.Mortuus, 3},
            {Aspectus.Limus, 3},
            {Aspectus.Metallum, 3},
            {Aspectus.Iter, 3},
            {Aspectus.Herba, 3},
            {Aspectus.Volatus, 3},
            {Aspectus.Arbor, 4}, // compound-4
            {Aspectus.Praecantatio, 4},
            {Aspectus.Radio, 4},
            {Aspectus.Bestia, 4},
            {Aspectus.Primordium, 4},
            {Aspectus.Tenebrae, 4}, 
            {Aspectus.Fames, 4},
            {Aspectus.Vitium, 5}, // compound-5
            {Aspectus.Infernus, 5},
            {Aspectus.Auram, 5},
            {Aspectus.Caelum, 5}, 
            {Aspectus.Exanimis, 5},
            {Aspectus.Superbia, 5},
            {Aspectus.Spiritus, 5},
            {Aspectus.Cognitio, 6}, // compound-6
            {Aspectus.Sensus, 6}, 
            {Aspectus.Alienis, 6},
            {Aspectus.Gula, 6},
            {Aspectus.Astrum, 6},
            {Aspectus.Magneto, 6}, 
        };
    }
}
