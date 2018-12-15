# AbilitySystem

A Unity project to model an combat ability system.

Abilities are implemented with a generalized and modular template system using Scriptable Objects. This allows developers to create and configure abilities with minimal coding. The system utilizes an event system to enable effects that observe certain events.

## Sample Abilities
#### Heavy Attack
Attack the target for 20 damage.

#### Block
Attacks against the target for the next 5 seconds will be defended and will deal 50% less damage.

#### Dodge
The next attack against the caster within 1 second are defended and will miss.
Passive Effect: Defended attacks against the caster resets the cooldown of Dodge.

#### Flamestrike
An attack which deals 15 Fire damage and sets the target on fire. While on fire, the target will burn and take 10 Fire damage every second. Being hit by an attack while on fire will also incur burn damage. Lasts 10 seconds.

#### Freeze
Freezes the target, making them unable to act. The next attack that hits this target will shatter the target, dealing 100 Ice damage and end the effect. If the attack was a critical hit, shatter damage is doubled. Lasts a maximum of 8 seconds. 10 second cooldown.






