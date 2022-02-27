using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Mod
{
    public class Mod
    {
        public static void Main()
        {
CategoryBuilder.Create("Wtf dude?", "items and more all", ModAPI.LoadSprite("icons/category.png"));
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
        NameOverride = "Android)))))", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "not people.", //new item description
        CategoryOverride = ModAPI.FindCategory("Wtf dude?"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("dude/icon.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            //load textures for each layer (see Human textures folder in this repository)
            var skin = ModAPI.LoadTexture("dude/skin.png");
            var flesh = ModAPI.LoadTexture("dude/meet.png");
            var bone = ModAPI.LoadTexture("dude/bone.png");
            //get person
            var person = Instance.GetComponent<PersonBehaviour>();

            //use the helper function to set each texture
            //parameters are as follows: 
            //  skin texture, flesh texture, bone texture, sprite scale
            //you can pass "null" to fall back to the original texture
            person.SetBodyTextures(skin, flesh, bone, 1);

            //change procedural damage colours if they interfere with your texture (rgb 0-255)
            person.SetBruiseColor(86, 62, 130); //main bruise colour. purple-ish by default
            person.SetSecondBruiseColor(154, 0, 7); //second bruise colour. red by default
            person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
            person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
            person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered

        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Revolver"), //item to derive from
        NameOverride = "banan gun", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "banan? dont eat.", //new item description
        CategoryOverride = ModAPI.FindCategory("Wtf dude?"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("icons/icon.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            //setting the sprite
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("items/banangun.png");

            //getting the FirearmBehaviour for later manipulation
            var firearm = Instance.GetComponent<FirearmBehaviour>();

            //creating a custom cartridge for the gun
            Cartridge customCartridge = ModAPI.FindCartridge("9mm"); //load a copy of the 9mm cartridge
            customCartridge.name = "7.63×25mm Mauser"; //set a name
            customCartridge.Damage *= 0.8f; //change the damage however you like
            customCartridge.StartSpeed *= 1.5f; //change the bullet velocity
            customCartridge.PenetrationRandomAngleMultiplier *= 0.5f; //change the accuracy when the bullet travels through an object
            customCartridge.Recoil *= 0.7f; //change the recoil
            customCartridge.ImpactForce *= 0.7f; //change how much the bullet pushes the target

            //set the cartridge to the FirearmBehaviour
            firearm.Cartridge = customCartridge;

            //set the new gun sounds. this is an array of AudioClips that is picked from at random when shot
            firearm.ShotSounds = new AudioClip[]
            {
                ModAPI.LoadSound("audio/babanana.mp3")
            };

            // set the collision box to the new sprite shape
            // this is the easiest way to fix your collision shape, but it also the slowest.
            Instance.FixColliders();
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Revolver"), //item to derive from
        NameOverride = "MicroGun", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "he mini, and this well, sweet.", //new item description
        CategoryOverride = ModAPI.FindCategory("Wtf dude?"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("icons/icon2.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            //setting the sprite
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("items/microgun.png");

            //getting the FirearmBehaviour for later manipulation
            var firearm = Instance.GetComponent<FirearmBehaviour>();

            //creating a custom cartridge for the gun
            Cartridge customCartridge = ModAPI.FindCartridge("120mm"); //load a copy of the 9mm cartridge
            customCartridge.name = "7.63×25mm Mauser"; //set a name
            customCartridge.Damage *= 0.8f; //change the damage however you like
            customCartridge.StartSpeed *= 1.5f; //change the bullet velocity
            customCartridge.PenetrationRandomAngleMultiplier *= 0.5f; //change the accuracy when the bullet travels through an object
            customCartridge.Recoil *= 0.7f; //change the recoil
            customCartridge.ImpactForce *= 0.7f; //change how much the bullet pushes the target

            //set the cartridge to the FirearmBehaviour
            firearm.Cartridge = customCartridge;

            //set the new gun sounds. this is an array of AudioClips that is picked from at random when shot
            firearm.ShotSounds = new AudioClip[]
            {
                ModAPI.LoadSound("audio/BAM.mp3")
            };

            // set the collision box to the new sprite shape
            // this is the easiest way to fix your collision shape, but it also the slowest.
            Instance.FixColliders();
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
        NameOverride = "skeletik", //new item name with a suffix to assure it is globally unique
        DescriptionOverride = "yes.", //new item description
        CategoryOverride = ModAPI.FindCategory("Wtf dude?"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("dude2/icon1.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            //load textures for each layer (see Human textures folder in this repository)
            var skin = ModAPI.LoadTexture("dude2/bone.png");
            var flesh = ModAPI.LoadTexture("dude2/bone.png");
            var bone = ModAPI.LoadTexture("dude2/bone.png");
            //get person
            var person = Instance.GetComponent<PersonBehaviour>();

            //use the helper function to set each texture
            //parameters are as follows: 
            //  skin texture, flesh texture, bone texture, sprite scale
            //you can pass "null" to fall back to the original texture
            person.SetBodyTextures(skin, flesh, bone, 1);

            //change procedural damage colours if they interfere with your texture (rgb 0-255)
            person.SetBruiseColor(86, 62, 130); //main bruise colour. purple-ish by default
            person.SetSecondBruiseColor(154, 0, 7); //second bruise colour. red by default
            person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
            person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
            person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered

        }
    }
);



        }
    }
}