using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip button_switch, button_press, gameover, start, damage, jetpack, grab, correct_drop, alert_meteor_shower, life_up, shoot, eat, push_planet, meteor_shield, draw_shield, blackhole_death, suck, flash,
    typing, rumble1, enter_ship, teleport, ship_sounds, flyout, cutscene_rumble, ship_explosion;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {

        button_press = Resources.Load<AudioClip>("button_press");
        button_switch = Resources.Load<AudioClip>("button_switch");
        gameover = Resources.Load<AudioClip>("gameover");
        start = Resources.Load<AudioClip>("start");
        damage = Resources.Load<AudioClip>("damage");
        jetpack = Resources.Load<AudioClip>("jetpack");
        grab = Resources.Load<AudioClip>("grab");
        correct_drop = Resources.Load<AudioClip>("correct_drop");
        alert_meteor_shower = Resources.Load<AudioClip>("alert_meteor_shower");
        life_up = Resources.Load<AudioClip>("life_up");
        shoot = Resources.Load<AudioClip>("shoot");
        eat = Resources.Load<AudioClip>("eat");
        push_planet = Resources.Load<AudioClip>("push_planet");
        meteor_shield = Resources.Load<AudioClip>("meteor_shield");
        draw_shield = Resources.Load<AudioClip>("draw_shield");
        blackhole_death = Resources.Load<AudioClip>("blackhole_death");
        suck = Resources.Load<AudioClip>("suck");
        flash = Resources.Load<AudioClip>("flash");
        typing = Resources.Load<AudioClip>("typing");
        rumble1 = Resources.Load<AudioClip>("rumble1");
        enter_ship = Resources.Load<AudioClip>("enter_ship");
        teleport = Resources.Load<AudioClip>("teleport");
        ship_sounds = Resources.Load<AudioClip>("ship_sounds");
        flyout = Resources.Load<AudioClip>("flyout");
        cutscene_rumble = Resources.Load<AudioClip>("cutscene_rumble");
        ship_explosion = Resources.Load<AudioClip>("ship_explosion");

        audioSrc = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "button_press":
                audioSrc.PlayOneShot(button_press);
                break;
            case "button_switch":
                audioSrc.PlayOneShot(button_switch);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameover);
                break;
            case "start":
                audioSrc.PlayOneShot(start);
                break;
            case "damage":
                audioSrc.PlayOneShot(damage);
                break;
            case "jetpack":
                audioSrc.PlayOneShot(jetpack);
                break;
            case "grab":
                audioSrc.PlayOneShot(grab);
                break;
            case "correct_drop":
                audioSrc.PlayOneShot(correct_drop);
                break;
            case "alert_meteor_shower":
                audioSrc.PlayOneShot(alert_meteor_shower);
                break;
            case "life_up":
                audioSrc.PlayOneShot(life_up);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;
            case "eat":
                audioSrc.PlayOneShot(eat);
                break;
            case "push_planet":
                audioSrc.PlayOneShot(push_planet);
                break;
            case "meteor_shield":
                audioSrc.PlayOneShot(meteor_shield);
                break;
            case "draw_shield":
                audioSrc.PlayOneShot(draw_shield);
                break;
            case "blackhole_death":
                audioSrc.PlayOneShot(blackhole_death);
                break;
            case "suck":
                audioSrc.PlayOneShot(suck);
                break;
            case "flash":
                audioSrc.PlayOneShot(flash);
                break;
            case "typing":
                audioSrc.PlayOneShot(typing);
                break;
            case "rumble1":
                audioSrc.PlayOneShot(rumble1);
                break;
            case "enter_ship":
                audioSrc.PlayOneShot(enter_ship);
                break;
            case "teleport":
                audioSrc.PlayOneShot(teleport);
                break;
            case "ship_sounds":
                audioSrc.PlayOneShot(ship_sounds);
                break;
            case "flyout":
                audioSrc.PlayOneShot(flyout);
                break;
            case "cutscene_rumble":
                audioSrc.PlayOneShot(cutscene_rumble);
                break;
            case "ship_explosion":
                audioSrc.PlayOneShot(ship_explosion);
                break;
        }
    }

    public static void StopSound()
    {
        audioSrc.Stop();
    }
}
