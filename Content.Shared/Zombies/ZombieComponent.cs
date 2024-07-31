using Content.Shared.Antag;
using Content.Shared.Chat.Prototypes;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.Damage;
using Content.Shared.FixedPoint;
using Content.Shared.Humanoid;
using Content.Shared.Roles;
using Content.Shared.StatusIcon;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.Zombies;

[RegisterComponent, NetworkedComponent]
public sealed partial class ZombieComponent : Component
{
    /// <summary>
    /// The baseline infection chance you have if you are completely nude
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    public float MaxZombieInfectionChance = 1.00f;

    /// <summary>
    /// The minimum infection chance possible. This is simply to prevent
    /// being invincible by bundling up.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    public float MinZombieInfectionChance = 0.6f; // Sunrise-Edit

    [ViewVariables(VVAccess.ReadWrite)]
    public float ZombieMovementSpeedBuff = 1.05f; // Sunrise-Edit

    /// <summary>
    /// The skin color of the zombie
    /// </summary>
    [DataField("skinColor")]
    public Color SkinColor = new(0.45f, 0.51f, 0.29f);

    /// <summary>
    /// The eye color of the zombie
    /// </summary>
    [DataField("eyeColor")]
    public Color EyeColor = new(0.96f, 0.13f, 0.24f);

    /// <summary>
    /// The base layer to apply to any 'external' humanoid layers upon zombification.
    /// </summary>
    [DataField("baseLayerExternal")]
    public string BaseLayerExternal = "MobHumanoidMarkingMatchSkin";

    /// <summary>
    /// The attack arc of the zombie
    /// </summary>
    [DataField("attackArc", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string AttackAnimation = "WeaponArcBite";

    /// <summary>
    /// The role prototype of the zombie antag role
    /// </summary>
    [DataField("zombieRoleId", customTypeSerializer: typeof(PrototypeIdSerializer<AntagPrototype>))]
    public string ZombieRoleId = "Zombie";

    /// <summary>
    /// The CustomBaseLayers of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeZombifiedCustomBaseLayers")]
    public Dictionary<HumanoidVisualLayers, CustomBaseLayerInfo> BeforeZombifiedCustomBaseLayers = new ();

    /// <summary>
    /// The skin color of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeZombifiedSkinColor")]
    public Color BeforeZombifiedSkinColor;

    /// <summary>
    /// The eye color of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeZombifiedEyeColor")]
    public Color BeforeZombifiedEyeColor;

    [DataField("emoteId", customTypeSerializer: typeof(PrototypeIdSerializer<EmoteSoundsPrototype>))]
    public string? EmoteSoundsId = "Zombie";

    public EmoteSoundsPrototype? EmoteSounds;

    [DataField("nextTick", customTypeSerializer:typeof(TimeOffsetSerializer))]
    public TimeSpan NextTick;

    [DataField("zombieStatusIcon")]
    public ProtoId<StatusIconPrototype> StatusIcon { get; set; } = "ZombieFaction";

    /// <summary>
    /// Healing each second
    /// </summary>
    [DataField("passiveHealing")]
    public DamageSpecifier PassiveHealing = new()
    {
        DamageDict = new ()
        {
            { "Blunt", -5 }, // Sunrise-Edit
            { "Slash", -5 }, // Sunrise-Edit
            { "Piercing", -5 }, // Sunrise-Edit
            { "Heat", -0.02 },
            { "Shock", -0.02 },
        }
    };

    /// <summary>
    /// A multiplier applied to <see cref="PassiveHealing"/> when the entity is in critical condition.
    /// </summary>
    [DataField("passiveHealingCritMultiplier")]
    public float PassiveHealingCritMultiplier = 2f; // Sunrise-Edit

    /// <summary>
    /// Healing given when a zombie bites a living being.
    /// </summary>
    [DataField("healingOnBite")]
    public DamageSpecifier HealingOnBite = new()
    {
        DamageDict = new()
        {
            { "Blunt", -5 }, // Sunrise-Edit
            { "Slash", -5 }, // Sunrise-Edit
            { "Piercing", -5 }, // Sunrise-Edit
        }
    };

    /// <summary>
    ///     Path to antagonist alert sound.
    /// </summary>
    [DataField("greetSoundNotification")]
    public SoundSpecifier GreetSoundNotification = new SoundPathSpecifier("/Audio/Ambience/Antag/zombie_start.ogg");

    /// <summary>
    ///     Hit sound on zombie bite.
    /// </summary>
    [DataField]
    public SoundSpecifier BiteSound = new SoundPathSpecifier("/Audio/Effects/bite.ogg");

    /// <summary>
    /// The blood reagent of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeZombifiedBloodReagent")]
    public string BeforeZombifiedBloodReagent = string.Empty;

    /// <summary>
    /// The blood reagent to give the zombie. In case you want zombies that bleed milk, or something.
    /// </summary>
    [DataField("newBloodReagent", customTypeSerializer: typeof(PrototypeIdSerializer<ReagentPrototype>))]
    public string NewBloodReagent = "ZombieBlood";

    // Sunrise-Start
    [DataField("actionJumpId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionJumpId = "ZombieJump";

    [DataField("actionFlairId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionFlairId = "ZombieFlair";

    [DataField]
    public float ParalyzeTime = 5f;

    [DataField]
    public DamageSpecifier Damage = new()
    {
        DamageDict = new Dictionary<string, FixedPoint2>
        {
            { "Slash", 30 },
        },
    };

    /// <summary>
    /// Нельзя пролететь через толпу и всех переубивать
    /// </summary>
    [DataField]
    public TimeSpan? LastThrowHit;

    [DataField]
    public float MaxThrow = 10f;

    /// <summary>
    /// Зомби не должны чувствовать очень далеко.
    /// </summary>
    [DataField]
    public float MaxFlairDistance = 500f;
    // Sunrise-End
}
