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
        };
    }
}
