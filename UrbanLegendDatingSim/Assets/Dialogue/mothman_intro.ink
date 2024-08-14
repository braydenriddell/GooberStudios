INCLUDE _globals.ink
-> mothman_start

=== mothman_start ===
<i><color="grey">You are hiking with your friends on a weekend vacation atop the Appalachian mountains.#sprite:null #name: 

<i><color="grey">It’s been a tiring experience, and honestly, it hasn’t been fun.

<i><color="grey">Apparently, there’s supposed to be sightings of Mothman, promised by your friends.

<i><color="grey">But it’s been rather…lame.

<i><color="grey">You decide to leave your tent and get some fresh air, as your friends are being loud by the campfire, telling boring horror stories.

<i><color="grey">You know what would be exciting?

<i><color="grey">Actually meeting a folklore being!

<i><color="grey">Suddenly, the ground beneath your feet crumbles, causing you to slip and fall.

<i><color="grey">You tumble down the mountain side, luckily avoiding some trees.

<i><color="grey">As you land back first somewhere, the only light is your flashlight that somehow didn’t break, you force yourself to crawl and lean against a tree.

<i><color="grey">That’s when you see those red eyes.

<i><color="grey">At first, you are scared. What on earth has red eyes?! But as you shine your flashlight on the red eyes, you see…him.#sprite:mothman_hidden

<i><color="grey">You immediately recognize him from the statue of the nearby town.

<i><color="grey">IT’S MOTHMAN!

!!!#name:Mothman #sprite:mothman_covered

<i><color="grey">He seems to be…distressed?#name: 

Woah…#name: You

<i><color="grey">It’s Mothman…staring at you.#name: 

<i><color="grey">You have a weird feeling inside you…

<i><color="grey">It’s…excitement?

<i><color="grey">Excitement!

<i><color="grey">Something interesting has finally happened to you!

Murrr!#name:Mothman

<i><color="grey">He’s frantically waving his wings up and down at you. You don’t understand what he’s implying.#sprite:mothman_open #name: 

<i><color="grey">Maybe it’s your arm injury you just noticed? You know, the one that’s being a bitch and feeling painful right now?

Owwwww!#name: You

Murr! Murr!#name:Mothman

<i><color="grey">He flutters over to you, his hands gently touching your broken arm.#name: 

<i><color="grey">Oh my god, MOTHMAN IS TOUCHING YOU.

<i><color="grey">His hands are surprisingly warm. Soft and fuzzy. You realize that he’s close to a human with wings rather than a monstrosity with insect-like features.

<i><color="grey">Kinda looks hot…

Murr…#name:Mothman

<i><color="grey">He lets go of your arm, much to your dismay. Instead, he motions for you to follow him. Maybe he’s bringing you back to your camp.#name: 

<i><color="grey">You might be able to show him to the others! To scare them!

<i><color="grey">Or maybe he’s bringing you to a hospital? Does he even know what a hospital is?

<i><color="yellow">Anyways, do you even follow him?
+ [YES!!!]
        -> mothman_follow
+ [Yes...]
        -> mothman_follow

=== mothman_follow ===
<i><color="grey">The answer is yes.

<i><color="grey">Yes you do.

<i><color="grey">You trail behind Mothman, holding your flashlight in your left hand. Mothman seems…focused?

<i><color="grey">Focused on what?

<i><color="grey">Focused on you…

<i><color="grey">You? Worthy of Mothman’s focus?

Murr?#name:Mothman

<i><color="grey">He seems to have noticed you staring at him. And now he looks very confused.#name: 

<i><color="yellow">QUICK. DISTRACT HIM SO HE DOESN’T THINK YOU’RE WEIRD!
+ [Distract with flashlight]
        -> mothman_distract



=== mothman_distract ===
<i><color="grey">Moths like light, right? Maybe he’ll enjoy chasing down your flashlight.

<i><color="grey">You partially cover your flashlight, making the light source much more concentrated and compact.

<i><color="grey">His eyes widen and stare at the tiny circle on the ground.

<i><color="grey">He flutters over and tries to catch it, to no avail.

<i><color="grey">This goes on for a whopping 2 hours until you hear footsteps.

<i><color="grey">You turn to look over, and see your friends!

<i><color="grey">Wow, you completely forgot they’ve probably been freaking out.

<i><color="grey">Yet they seem…disgusted? It’s hard to tell in the dark.

<i><color="grey">Your flashlight did run out of batteries 0_0#sprite:null

Hey guys! Guess what I saw-#name: You

<i><color="grey">Suddenly, you feel a sharp pain in your abdomen.#sprite:mothman_hidden #name: 

<i><color="grey">A knife.

<i><color="grey">And before you know it, you collapse to the ground.

<i><color="grey">Dead.

<i><color="grey">Dead?

<i><color="grey">Well, you don’t feel dead…whatever that means?

<i><color="grey">Wow, your vision is so much clearer and brighter–HOLY SHIT IS THAT YOUR CORPSE?

<i><color="grey">You look down and…yeah, that’s your own dead body.

<i><color="grey">But then what are you?

Murr :(#sprite:mothman_covered #name:Mothman

<i><color="grey">Mothman seems to be staring at you, and then back at your corpse.#name: 

<i><color="grey">Awww, he seems sad about failing to protect you.

<i><color="yellow">But you know how to make him feel better!
+ [Revenge!]
        -> mothman_revenge
+ [Kiss him!]
        -> mothman_kiss

=== mothman_revenge ===
<i><color="grey">You decide to get revenge on your friends, with the help of Mothman.
~ end = true
-> END

=== mothman_kiss ===
<i><color="grey">THIS IS GONNA BE AWESOMEEEEEE!!!!

<i><color="grey">He is SO WARM. 

<i><color="grey">Like, surprisingly warm.

<i><color="grey">He doesn’t seem to know how to react.

<i><color="grey">Mothman’s just standing there awkwardly.

Mothman: Murr.

<i><color="grey">He gestures over to a street nearby the forest, pointing at a building.#sprite:mothman_open  #name: 

<i><color="grey">A hospital, to be specific.

<i><color="grey">But you continue hugging him.

Murr!#name:Mothman

Won’t you come with?#name:You

<i><color="grey">He shakes his head.#name: 

<i><color="grey">He’s probably too shy towards humans to want to go with you.

<i><color="grey">…wait but you’re a human…

<i><color="grey">Eh, maybe you’re an exception.

<i><color="yellow">A fucking awesome exception, duh!

+ [Fuck the hospital.]
        -> mothman_die
+ [Go to the hospital.]
        -> mothman_healHospital

=== mothman_healHospital ===
<i><color="grey">Your hearts beat in sync as he holds you in his arms.

~ end = true
-> END

=== mothman_die ===
<i><color="grey">The doctors do fix your broken bones.
~ end = true
-> END