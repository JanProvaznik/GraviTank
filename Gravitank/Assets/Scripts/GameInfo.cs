public static class GameInfo
{   //Constants
// shooting
    public const float SHOT_COOLDOWN = 3; //seconds
    public const float SHOT_MIN_POWER = 2; 
    public const float SHOT_MAX_POWER = 5; 
    public const float SHOT_POWER_INCREMENT = 0.05f; 

    //Movement
    public const float MOVEMENT_FORCE_MAGNITUDE = 1;
    public const float MOVEMENT_MAX_VELOCITY_MAGNITUDE = 0.5f;


    //Aiming
    public const float BARREL_MAX_ANGLE = 90;
    public const float BARREL_ANGLE_DELTA = 1;

    //Health
    public const float MAX_HEALTH = 100;

    //shot damage

    public const float SHOT_BASE_DAMAGE = 1;
    public const float SHOT_DAMAGE_TIME_COEFFICIENT = 0.01f;
    public const float SHOT_DAMAGE_POWER_COEFFICIENT = 1;
    public const float SHOT_MAX_DAMAGE= 40;


    // planet gravity
    public const float PLANET_GRAVITY = 30;
    public const float GRAVITY_EXPONENT = 2;

    // Meteor generation
    public const float BASE_METEOR_FREQUENCY = 0.0001f;
    public const float TIME_METEOR_FREQUENCY_COEFFICIENT = 0.00001f;
    
    public const float METEOR_MIN_DISTANCE= 5;
    public const float METEOR_MAX_DISTANCE= 10;
    public const float METEOR_MAX_FORCE = 3;

    //Meteor
    public const float METEOR_MAX_VELOCITY_MAGNITUDE = 2;
    public const float METEOR_DAMAGE = 25;

   public static string Player1Name = "Player1";
   public static string Player2Name = "Player2";
   public static bool Player1Won;
}
