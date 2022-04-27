using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MammalData{

public class Mammal{
    public string order, family, genus, species, commonName, hint, description;
    public Mammal(){}
    public Mammal(string order, string family, string genus, string species, string commonName, string hint, string description){
        this.order = order.ToLower();
        this.family = family.ToLower();
        this.genus = genus.ToLower();
        this.species = species.ToLower();
        this.commonName = commonName;
        this.hint = hint;
        this.description = description;
    }
}

}