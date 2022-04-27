using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MammalData{

public class Mammal{
    public string order, family, genus, species, commonName, hint, description;

    public Mammal(){}
    public Mammal(string order, string family, string genus, string species){
        this.order = order;
        this.family = family;
        this.genus = genus;
        this.species = species;
    }
    public Mammal(string order, string family, string genus, string species, string commonName, string hint, string description){
        this.order = order.ToLower();
        this.family = family.ToLower();
        this.genus = genus.ToLower();
        this.species = species.ToLower();
        this.commonName = commonName;
        this.hint = hint;
        this.description = description;
    }
    public bool match(Mammal other){
        return matchOrder(other) && matchFamily(other) && matchGenus(other) && matchSpecies(other);
    }
    public bool matchOrder(Mammal other){
        return this.order == other.order;
    }
    public bool matchFamily(Mammal other){
        return this.family == other.family;
    }
    public bool matchGenus(Mammal other){
        return this.genus == other.genus;
    }
    public bool matchSpecies(Mammal other){
        if(this.species == other.species) return true;
        string[] wordsInThis = this.species.Split(" ");
        string[] wordsInOther = other.species.Split(" ");
        if(wordsInThis[wordsInThis.Length-1] == wordsInOther[wordsInOther.Length-1]) return true;
        return false;
    }

    public bool isValid(){
        return isOrderValid() && isFamilyValid() && isGenusValid() && isSpeciesValid();
    }

    public bool isOrderValid(){
        for(int i=0;i<allOrder.Length;i++){
            if(matchOrder(new Mammal(allOrder[i], "", "", ""))) return true;
        }
        return false;
    }

    public bool isFamilyValid(){
        for(int i=0;i<allFamily.Length;i++){
            if(matchFamily(new Mammal("", allFamily[i], "", ""))) return true;
        }
        return false;
    }

    public bool isGenusValid(){
        for(int i=0;i<allGenus.Length;i++){
            if(matchGenus(new Mammal("", "", allGenus[i], ""))) return true;
        }
        return false;
    }

    public bool isSpeciesValid(){
        for(int i=0;i<allSpecies.Length;i++){
            if(matchSpecies(new Mammal("", "", "", allSpecies[i]))) return true;
        }
        return false;
    }


    public static Mammal[] mammals;
    public static string[] allOrder, allFamily, allGenus, allSpecies;
}

}