INCLUDE _globals.ink
-> mothman_start

=== mothman_start ===
<i>You are hiking with your friends on a weekend vacation atop the Appalachian mountains.#sprite:null #name: 

<i>It’s been a tiring experience, and honestly, it hasn’t been fun.

<i>Apparently, there’s supposed to be sightings of Mothman, promised by your friends.

<i>But it’s been rather…lame.

<i>You decide to leave your tent and get some fresh air, as your friends are being loud by the campfire, telling boring horror stories.

<i>You know what would be exciting?

<i>Actually meeting a folklore being!

<i>Suddenly, the ground beneath your feet crumbles, causing you to slip and fall.

<i>You tumble down the mountain side, luckily avoiding some trees.

<i>As you land back first somewhere, the only light is your flashlight that somehow didn’t break, you force yourself to crawl and lean against a tree.

<i>That’s when you see those red eyes.

<i>At first, you are scared. What on earth has red eyes?! But as you shine your flashlight on the red eyes, you see…him.#sprite:mothman_hidden

<i>You immediately recognize him from the statue of the nearby town.

<i>IT’S MOTHMAN!

!!!#name:Mothman #sprite:mothman_covered

<i>He seems to be…distressed?#name: 

Woah…#name: You

<i>It’s Mothman…staring at you.#name: 

<i>You have a weird feeling inside you…

<i>It’s…excitement?

<i>Excitement!

<i>Something interesting has finally happened to you!

Murrr!#name:Mothman

<i>He’s frantically waving his wings up and down at you. You don’t understand what he’s implying.#sprite:mothman_open #name: 

<i>Maybe it’s your arm injury you just noticed? You know, the one that’s being a bitch and feeling painful right now?

Owwwww!#name: You

Murr! Murr!#name:Mothman

<i>He flutters over to you, his hands gently touching your broken arm.#name: 

<i>Oh my god, MOTHMAN IS TOUCHING YOU.

<i>His hands are surprisingly warm. Soft and fuzzy. You realize that he’s close to a human with wings rather than a monstrosity with insect-like features.

<i>Kinda looks hot…

Murr…#name:Mothman

<i>He lets go of your arm, much to your dismay. Instead, he motions for you to follow him. Maybe he’s bringing you back to your camp.#name: 

<i>You might be able to show him to the others! To scare them!

<i>Or maybe he’s bringing you to a hospital? Does he even know what a hospital is?

<i>Anyways, do you even follow him?
+ [Yes...]
        -> mothman_follow
+ [YES!!!]
        -> mothman_follow

=== mothman_follow ===
<i>The answer is yes.

<i>Yes you do.

<i>You trail behind Mothman, holding your flashlight in your left hand. Mothman seems…focused?

<i>Focused on what?

<i>Focused on you…

<i>You? Worthy of Mothman’s focus?

~ end = true
-> END