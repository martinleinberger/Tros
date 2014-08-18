module Character


[<AbstractClass>]
type Maneuver(tn, verb) =
    member __.Verb = verb 
    member __.TN = tn

[<AbstractClass>]
type OffensiveManeuver(tn, verb) = 
    inherit Maneuver(tn, verb)

[<AbstractClass>]
type DefensiveManeuver(tn, verb) = 
    inherit Maneuver(tn, verb)

type Swing(tn) = 
    inherit OffensiveManeuver(tn, "swings")

type Thrust(tn) = 
    inherit OffensiveManeuver(tn, "thrusts")

type Parry(tn) = 
    inherit DefensiveManeuver(tn, "parries")

type Longsword() = class
    member __.Damage = ":BRAWN: + 1"
    member __.OffensiveManeuvers = [new Swing(7) :> OffensiveManeuver; new Thrust(8) :> OffensiveManeuver]
    member __.DefensiveManeuvers = [new Parry(6) :> DefensiveManeuver]
end

type Fighter(c:Character) = 
    let mutable initiativeOver : Fighter option = None
    let mutable remainingCombatPool : int  = 0
    
    member __.Character = c
    member __.InitiativeOver = initiativeOver
    member __.RemainingCombatPool = remainingCombatPool
    

and Body() =
    member __.TargetZones = []

and Character(name, brawn, agility, wits, presence) = 
    member __.Body = new Body()

    member __.Name = name
    member __.Brawn = brawn
    member __.Agility = agility
    member __.Wits = wits
    member __.Presence = presence

    member __.Coordination = (__.Agility + __.Wits) / 2
    member __.Resistence = (__.Brawn + __.Presence) / 2

    // Generic Weapon proficiency for brevity
    member __.WeaponProficiency = 4

    member __.CombatPool = __.Coordination + __.WeaponProficiency

    member __.MakeFighter = new Fighter(__)
    member __.Items = [new Longsword()]


let std1 = Character("1", 5, 5, 4, 4)
let std2 = Character("2", 5, 5, 4, 4)